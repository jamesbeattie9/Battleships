using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Battleships.Pieces;

namespace Battleships.Board.Base
{
    public class Gameboard
    {
        public const int BOARD_WIDTH = 10;
        public const int BOARD_HEIGHT = 10;

        /// <summary>
        /// Live count of how many total hits board has received
        /// </summary>
        public int HIT_COUNTER = 0;

        /// <summary>
        /// Maximum amount of hits a board can sustain before losing
        /// </summary>
        public int HIT_MAX = 0;

        public List<Ship> Fleet = new List<Ship>();

        /// <summary>
        /// Game board used and displayed to players
        /// # is water
        /// 0 is miss
        /// 1 is boat
        /// X is hit
        /// </summary>
        public char[,] Board = new char[BOARD_WIDTH, BOARD_WIDTH];

        /// <summary>
        /// Hidden placement board used in the placing of Ships in a Fleet
        /// </summary>
        public char[,] FleetPosition = new char[BOARD_WIDTH, BOARD_WIDTH];

        /// Create List of Ships that make up Fleet
        /// Assign win condition HIT_MAX as sum of all possible areas to hit
        /// Initialise board to be BOARD_WIDTH x BOARD_HEIGHT filled with water '#'
        public Gameboard()
        {
            Fleet.Add(new Ship() { Type = ShipType.Battleship, Name = "Battleship", Length = 5, PlaceOrder = 1 });
            Fleet.Add(new Ship() { Type = ShipType.Destroyer, Name = "Destroyer1", Length = 4, PlaceOrder = 2 });
            Fleet.Add(new Ship() { Type = ShipType.Destroyer, Name = "Destroyer2", Length = 4, PlaceOrder = 3 });

            HIT_MAX = Fleet.Sum(x => x.Length);

            InitialiseBoard(Board);
            InitialiseBoard(FleetPosition);
        }

        /// <summary>
        /// Fill char array with water
        /// </summary>
        /// <param name="board"></param>
        private void InitialiseBoard(char[,] board)
        {
            for (int i = 0; i < BOARD_WIDTH; i++)
            {
                for (int j = 0; j < BOARD_HEIGHT; j++)
                {
                    board[i, j] = Symbols.Water;
                }
            }
        }

        /// <summary>
        /// Ship bHit when:
        /// Ship exists in FleetPosition and Board is Water
        /// Update Board with Hit or Miss
        /// Return HitReport detailing result of strike
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        public HitReport CheckHit(Coordinate coordinate)
        {
            HitReport hitReport = new HitReport();

            hitReport.SymbolStruck = Board[coordinate.X, coordinate.Y];
            hitReport.bHit = FleetPosition[coordinate.X, coordinate.Y] == Symbols.Ship &&
                Board[coordinate.X, coordinate.Y] == Symbols.Water ? true : false;

            if (hitReport.bHit)
            {
                HIT_COUNTER++;
                Board[coordinate.X, coordinate.Y] = Symbols.Hit;

                foreach (Ship ship in Fleet)
                {
                    foreach (Coordinate shipCoord in ship.Position)
                    {
                        if (shipCoord.X == coordinate.X &&
                            shipCoord.Y == coordinate.Y)
                        {
                            ship.HitCounter++;

                            hitReport.Ship = ship;
                        }
                    }
                }
            }
            if (!hitReport.bHit && hitReport.SymbolStruck == Symbols.Water)
            {
                Board[coordinate.X, coordinate.Y] = Symbols.Miss;
            }

            return hitReport;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool CheckWin()
        {
            return HIT_COUNTER == HIT_MAX;
        }
    }
}
