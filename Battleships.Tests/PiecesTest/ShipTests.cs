using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships.Pieces;
using FluentAssertions;

namespace Battleships.Tests.PiecesTest
{
    public class ShipTests
    {
        private readonly Ship _ship;

        public ShipTests()
        {
            _ship = new Ship();
        }

        [Fact]
        public void Ship_IsSunk_ReturnFalse()
        {
            _ship.Length = 5;
            _ship.HitCounter = 0;

            _ship.IsSunk().Should().BeFalse();
        }

        [Fact]
        public void Ship_IsSunk_ReturnTrue()
        {
            _ship.Length = 5;
            _ship.HitCounter = 5;

            _ship.IsSunk().Should().BeTrue();
        }
    }
}
