using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Battleships.Board.Base;
using Battleships.Board.Interfaces;
using Battleships.Pieces;

namespace Battleships.Board
{
    public class ComputerGameboard : Gameboard, IGameBoard
    {
        /// <summary>
        /// Computer gameboard randomly selects ship positions
        /// direction: 0 - Horiztonal, 1 - Vertical
        /// </summary>
        public void PlaceFleet()
        {
            foreach (Ship ship in Fleet.OrderBy(x => x.PlaceOrder))
            {
                bool bValid = false;
                Random random = new Random();

                while (!bValid)
                {
                    //Can only place line vertically or horizontally
                    int direction = random.Next(0, 1);

                    int randomX = random.Next(0, BOARD_WIDTH - 1);
                    int randomY = random.Next(0, BOARD_HEIGHT - 1);

                    List<Coordinate> coordinates = CheckPotentialPlacement(
                        direction, randomX, randomY, ship);

                    if (coordinates == null)
                    {
                        continue;
                    }

                    ship.Position = coordinates;

                    //Sets boat position temporarily to prevent overlapping
                    foreach (Coordinate coordinate in coordinates)
                    {
                        FleetPosition[coordinate.X, coordinate.Y] = Symbols.Ship;
                    }

                    bValid = true;
                }
            }
        }

        /// <summary>
        /// Check if the proposed random coordinates (x,y) extended in the
        /// random direction will produce a valid set of in-bounds and
        /// non-overlapping squares to place a ship
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="ship"></param>
        /// <returns></returns>
        private List<Coordinate> CheckPotentialPlacement(int direction, int x, int y, Ship ship)
        {
            List<Coordinate> coordinates = new List<Coordinate>();

            if (FleetPosition[x, y] != Symbols.Water)
            {
                return null;
            }

            coordinates.Add(new Coordinate() { X = x, Y = y });

            if (direction == 0)
            {
                //Index out of bounds
                if (x + (ship.Length - 1) > BOARD_WIDTH - 1)
                {
                    return null;
                }

                //Check all co-ordinates are valid
                for (int i = 1; i < ship.Length; i++)
                {
                    //Ship already placed here - reset
                    if (FleetPosition[x + i, y] == Symbols.Ship)
                    {
                        return null;
                    }

                    coordinates.Add(new Coordinate() { X = x + i, Y = y });
                }
            }

            if (direction == 1)
            {
                //Index out of bounds
                if (y + (ship.Length - 1) > BOARD_HEIGHT - 1)
                {
                    return null;
                }

                //Check all co-ordinates are valid
                for (int i = 1; i < ship.Length; i++)
                {
                    //Ship already placed here - reset
                    if (FleetPosition[x, y + i] == Symbols.Ship)
                    {
                        return null;
                    }

                    coordinates.Add(new Coordinate() { X = x, Y = y + i });
                }
            }

            return coordinates;
        }
    }
}
