using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships.Board;
using Battleships.Board.Base;
using FluentAssertions;

namespace Battleships.Tests.BoardTests
{
    public class SymbolsTests
    {
        [Fact]
        public void Symbols_Water()
        {
            Symbols.Water.Should().NotBeNull();
            Symbols.Water.Should().Be('#');
        }

        [Fact]
        public void Symbols_Ship()
        {
            Symbols.Ship.Should().NotBeNull();
            Symbols.Ship.Should().Be('1');
        }

        [Fact]
        public void Symbols_Hit()
        {
            Symbols.Hit.Should().NotBeNull();
            Symbols.Hit.Should().Be('X');
        }

        [Fact]
        public void Symbols_Miss()
        {
            Symbols.Miss.Should().NotBeNull();
            Symbols.Miss.Should().Be('0');
        }
    }
}
