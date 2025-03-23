using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships.Board;
using Battleships.Board.Base;
using Battleships.Pieces;
using FluentAssertions;

namespace Battleships.Tests.BoardTests
{
    public class GameboardTests
    {
        private readonly ComputerGameboard _gameBoard;

        public GameboardTests()
        {
            _gameBoard = new ComputerGameboard();
        }

        [Fact]
        public void Gameboard_Constructor_Constants()
        {
            Gameboard.BOARD_WIDTH.Should().BeGreaterThan(0);
            Gameboard.BOARD_HEIGHT.Should().BeGreaterThan(0);
        }

        [Fact]
        public void Gameboard_Constructor_HitVariables()
        {
            _gameBoard.HIT_COUNTER.Should().Be(0);

            _gameBoard.HIT_MAX.Should().BeGreaterThan(0);
            _gameBoard.HIT_MAX.Should().Be(_gameBoard.Fleet.Sum(x => x.Length));
        }

        [Fact]
        public void Gameboard_Constructor_Fleet()
        {
            _gameBoard.Fleet.Should().BeOfType<List<Ship>>();
            _gameBoard.Fleet.Should().NotBeNull();
            _gameBoard.Fleet.Should().NotBeEmpty();

            //More tests:
            //OrderNumbers are different
            //All ships have a type, name, length > 0, hitcounter = 0
            //Sum of lengths of the ships should not exceed BOARD_HEIGHT * BOARD_WIDTH
        }

        [Fact]
        public void Gameboard_Constructor_FleetPosition()
        {
            _gameBoard.FleetPosition.Should().NotBeNull();

            //Should be 2d char array of size BOARD_WIDTH x BOARD_HEIGHT (ShouldBeInRange)
            //All elements should be equal to Symbols.Water
        }

        [Fact]
        public void Gameboard_Constructor_Board()
        {
            _gameBoard.Board.Should().NotBeNull();

            //Should be 2d char array of size BOARD_WIDTH x BOARD_HEIGHT (ShouldBeInRange)
            //All elements should be equal to Symbols.Water
        }

        [Theory]
        [InlineData(0, 0)]
        //Initialise some kind of test class such as:
        //[MemberData(nameof(GetCoordinates))]
        public void Gameboard_CheckHit(int x, int y)
        {
            //CheckHit should increment HIT_COUNTER where appropriate
            //CheckHit should increment Ship.HitCounter where appropriate
            //Verify hit is where expected
            //CheckHit should update Board with Hit or Miss
            //CheckHit should return a HitReport
            //CheckHit should return HitReport with Ship struck
            //CheckHit should return HitReport with SymbolStruck
            //CheckHit should return HitReport with bHit
        }

        [Fact]
        public void Gameboard_CheckWin_ShouldReturnFalse()
        {
            _gameBoard.HIT_COUNTER = 5;
            _gameBoard.HIT_MAX = 6;

            _gameBoard.CheckWin().Should().BeFalse();
        }

        [Fact]
        public void Gameboard_CheckWin_ShouldReturnTrue()
        {
            _gameBoard.HIT_COUNTER = 5;
            _gameBoard.HIT_MAX = 5;

            _gameBoard.CheckWin().Should().BeTrue();
        }
    }
}
