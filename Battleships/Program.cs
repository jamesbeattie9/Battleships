// See https://aka.ms/new-console-template for more information

using Battleships.Board;
using Battleships.Board.Base;
using Battleships.ConsoleIO;
using Battleships.Pieces;

//Board setup
ComputerGameboard computerPlayer = new ComputerGameboard();
computerPlayer.PlaceFleet();

//IO class setup
InputOutput inputOutput = new InputOutput(ComputerGameboard.BOARD_WIDTH, ComputerGameboard.BOARD_WIDTH);

Console.WriteLine();
Console.WriteLine("Battle those ships!");
Console.WriteLine();

while (!computerPlayer.CheckWin())
{
    inputOutput.PrintBoard(computerPlayer.Board);

    Coordinate coordinate = null;

    //Get user input and validate
    while (coordinate == null)
    {
        string userInput = inputOutput.GetUserInput();

        coordinate = inputOutput.ParseInput(userInput);

        if (coordinate == null)
        {
            inputOutput.InvalidInput();
        }
    }

    HitReport hitReport =  computerPlayer.CheckHit(coordinate);
    inputOutput.PrintShotMessage(hitReport);
}

inputOutput.PrintBoard(computerPlayer.Board);
Console.WriteLine();
Console.Write("You win!");

Environment.Exit(0);