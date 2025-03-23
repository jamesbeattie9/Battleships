using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships.Board;

namespace Battleships.Pieces
{
    public class Ship
    {
        public string Name { get; set; }
        public ShipType Type { get; set; }
        public int Length { get; set; }
        public List<Coordinate> Position { get; set; } = new List<Coordinate> { };
        public int HitCounter { get; set; }
        public int PlaceOrder { get; set; }
        public bool IsSunk() => HitCounter == Length;
    }
}
