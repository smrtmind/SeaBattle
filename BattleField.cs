using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleSea
{
    public class BattleField
    {
        static public string[][] field { get; private set; }

        static public string[][] GetField()
        {
            field = new string[11][];

            //initialization of top letters
            field[0] = new string[11];
            field[0][0] = "  ";

            string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };

            for (int j = 1; j < field[0].Length; j++)
            {
                field[0][j] = letters[j - 1];
            }

            //initialization of first numbers
            for (int i = 1; i < field.Length; i++)
            {
                field[i] = new string[11];
                field[i][0] = i.ToString() + " ";
            }

            field[10][0] = 10.ToString();

            //initializition of fillers
            for (int i = 1; i < field.Length; i++)
            {
                for (int j = 1; j < field[i].Length; j++)
                {
                    field[i][j] = ".";//(j + 1).ToString()
                }
            }

            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            Gamer.PrintCurrentField(field);

            return field;
        }

        static public string StartBattle(Gamer gamer1, Gamer gamer2, string[][] ships1, string[][] ships2)
        {
            int player1ShipDetails = 20;
            int player2ShipDetails = 20;
            string[][] player1Field = BattleField.GetField();
            string[][] player2Field = BattleField.GetField();
            string yesOrNo = string.Empty;

            while (player1ShipDetails != 0 || player2ShipDetails != 0)
            {
                player2ShipDetails = Process(gamer1, player1Field, ships2, ref player2ShipDetails);
                if (player2ShipDetails == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"\n\t{gamer1.name} won :)\n");
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                }

                player1ShipDetails = Process(gamer2, player2Field, ships1, ref player1ShipDetails);
                if (player1ShipDetails == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"\n\t{gamer2.name} won :)\n");
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                }
            }

            while (yesOrNo.ToLower() != "y" || yesOrNo.ToLower() != "n")
            {
                Console.Write("  Do you want to play again? [y] / [n]: ");
                yesOrNo = Console.ReadLine();

                if (yesOrNo == "y")
                {
                    Console.Clear();
                    break;
                }

                if (yesOrNo == "n")
                {
                    Console.Clear();
                    break;
                }
            }

            return yesOrNo;
        }

        static public int Process(Gamer gamer, string[][] playerField, string[][] ships, ref int playerShipDetails)
        {
            int letter = 0;
            int number = 0;
            int indexOfLetter = 0;
            string input = string.Empty;
            bool elementFound = false;

            string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            while (playerShipDetails != 0)
            {
                elementFound = false;

                while (!elementFound)
                {
                    Gamer.PrintCurrentField(playerField);

                    Console.ForegroundColor = gamer.color;
                    Console.WriteLine($"\n  {gamer.name} turn");
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write("  Enter the letter: ");
                    input = Console.ReadLine().ToUpper();

                    for (int j = 0; j < letters.Length; j++)
                    {
                        if (input == letters[j])
                        {
                            elementFound = true;
                            indexOfLetter = j;
                            letter = numbers[j];
                            break;
                        }
                    }
                }

                elementFound = false;

                while (!elementFound)
                {
                    Gamer.PrintCurrentField(playerField);

                    Console.ForegroundColor = gamer.color;
                    Console.WriteLine($"\n  {gamer.name} turn");
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine($"  Enter the letter: {letters[indexOfLetter]}");
                    Console.Write("  Enter the number: ");
                    int.TryParse(Console.ReadLine(), out number);

                    for (int j = 0; j < numbers.Length; j++)
                    {
                        if (number == numbers[j])
                        {
                            elementFound = true;
                            break;
                        }
                    }                  
                }

                if (ships[number][letter] == "\u25A0")
                {
                    playerField[number][letter] = "X";
                    ships[number][letter] = "X";
                    playerShipDetails--;

                    Gamer.PrintCurrentField(playerField);
                }

                else if (ships[number][letter] == ".")
                {
                    playerField[number][letter] = "o";
                    ships[number][letter] = "o";

                    Gamer.PrintCurrentField(playerField);
                    break;
                }

                else continue;
            }

            return playerShipDetails;
        }
    }
}
