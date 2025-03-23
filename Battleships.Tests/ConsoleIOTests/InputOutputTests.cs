using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships.Board;
using Battleships.ConsoleIO;
using FluentAssertions;


namespace Battleships.Tests.ConsoleIOTests
{
    public class InputOutputTests
    {
        private readonly ComputerGameboard _gameBoard;
        private readonly InputOutput _inputOutput;

        public InputOutputTests()
        {
            _gameBoard = new ComputerGameboard();
            _inputOutput = new InputOutput(ComputerGameboard.BOARD_WIDTH, ComputerGameboard.BOARD_HEIGHT);
        }

        //Alphabet should be 26 chars long
        //AllowedIntegers should be not null/empty
        //AllowedAlphabet should be not null/empty
        //AllowedIntegers should be BOARD_WIDTH count
        //AllowedAlphabet should be BOARD_HEIGHT count

        //ParseInput should return null if input is invalid (outside bounds, language not en-GB specific, not one symbol and one integer)
        //ParseInput shouldnt be case sensitive
        //ParseInput should return a Coordinate if input is valid
        //ParseInput should return a Coordinate with X and Y >= 0 and in BOARD_HEIGHT/BOARD_WIDTH range
        //ParseInput should return a Coordinate with X = 0 and Y = 0 if input is "A0" etc.

        //PrintShotMessage should print "Miss!" if HitReport !bHit
        //PrintShotMessage should print "Direct hit!" if bHit
        //PrintShotMessage should print "You sunk my Battleship!" if bHit and ShipType is Battleship
        //PrintShotMessage should print "You sunk my Destroyer!" if bHit and ShipType is Destroyer
        //PrintShotMessage should print "You've already hit this target!" if SymbolStruck is X/0
    }
}
