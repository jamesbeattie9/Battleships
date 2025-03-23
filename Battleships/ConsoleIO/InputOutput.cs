using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Battleships.Board;
using Battleships.Board.Base;
using Battleships.Pieces;

namespace Battleships.ConsoleIO
{
    public class InputOutput
    {
        private char[] Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        private char[] AllowedAlphabet = [];
        private int[] AllowedIntegers = [];

        public InputOutput(int BOARD_WIDTH, int BOARD_HEIGHT)
        {
            AllowedAlphabet = Alphabet.Take(BOARD_HEIGHT).ToArray();
            AllowedIntegers = Enumerable.Range(0, BOARD_WIDTH).ToArray();
        }

        public void PrintBoard(char[,] board)
        {
            Console.Write($"|X|" + "\t");

            for (int j = 0; j < AllowedIntegers.Length; j++)
            {
                Console.Write($"{j}" + "\t");
            }

            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < AllowedAlphabet.Length; i++)
            {
                Console.Write($"|{AllowedAlphabet[i]}|" + "\t");

                for (int j = 0; j < AllowedIntegers.Length; j++)
                {
                    Console.Write(board[j, i] + "\t");
                }
                Console.WriteLine();
            }
        }


        public string GetUserInput()
        {
            Console.WriteLine();
            Console.Write("Strike your target!: ");
            return Console.ReadLine();
        }

        public void InvalidInput()
        {
            Console.WriteLine();
            Console.WriteLine("That shot was miles off! Try aiming for the board.");
        }

        /// <summary>
        /// Must be a character followed by a integer
        /// Valid input is:
        /// First BOARD_WIDTH characters of the alphabet (allowedAlphabet)
        /// First BOARD_HEIGHT -1 numbers starting from 0 (allowedIntegers)
        /// If input is invalid, coordinate == null
        /// Culture is en-GB specific
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Coordinate ParseInput(string input)
        {
            Coordinate coordinate = new Coordinate();
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-GB");

            // Regex pattern to match a single letter followed by one or more digits
            string pattern = @"^([A-Za-z])(\d+)$";

            Regex regex = new Regex(pattern);
            Match match = regex.Match(input);

            if (!match.Success)
            {
                return null;
            }

            char character = Char.ToUpper(match.Groups[1].Value[0], culture);
            int integer = int.Parse(match.Groups[2].Value);

            if (!AllowedAlphabet.Contains(character) ||
                !AllowedIntegers.Contains(integer))
            {
                return null;
            }

            coordinate.X = integer;
            coordinate.Y = ConvertCharToIndex(character);

            return coordinate;
        }

        /// <summary>
        /// Subtract the ASCII value of the character from the
        /// ASCII value for A, giving the value of the index of the Board array
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private static int ConvertCharToIndex(char c)
        {
            return c - 'A';
        }

        public void PrintShotMessage(HitReport hitReport)
        {
            Console.Clear();

            switch (hitReport.SymbolStruck)
            {
                case Symbols.Water:
                    if (hitReport.bHit)
                    {
                        Console.WriteLine("Direct hit!");
                    }
                    else
                    {
                        Console.WriteLine("Miss!");
                    }
                    break;
                case Symbols.Hit:
                    Console.WriteLine("You've already hit this target!");
                    break;
                case Symbols.Miss:
                    Console.WriteLine("You've already hit this target!");
                    break;
            }

            if (hitReport.Ship != null && hitReport.Ship.IsSunk())
            {
                Console.WriteLine($"You sunk my {hitReport.Ship.Type.ToString()}!");
            }
        }
    }
}
