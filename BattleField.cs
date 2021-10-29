using System;
using System.Threading;

namespace SeaBattle
{
    public class BattleField
    {
        public static string[][] field { get; private set; }

        public static string[][] CreateNew()
        {
            field = new string[11][];

            //initialization of top letters
            field[0] = new string[11];
            field[0][0] = "  ";

            string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };

            for (int j = 1; j < field[0].Length; j++)
                field[0][j] = letters[j - 1];

            //initialization of first numbers
            for (int i = 1; i < field.Length; i++)
            {
                field[i] = new string[11];
                field[i][0] = i.ToString() + " ";
            }

            field[10][0] = 10.ToString();

            //initializition of fillers
            for (int i = 1; i < field.Length; i++)
                for (int j = 1; j < field[i].Length; j++)
                    field[i][j] = ".";

            Print.BattleField(field);

            return field;
        }

        public static string StartBattle(Player player1, Player player2, string[][] player1Ships, string[][] player2Ships)
        {
            int player1ShipDetails = 4;
            int player2ShipDetails = 4;
            string[][] player1Field = CreateNew();
            string[][] player2Field = CreateNew();
            string exitTheGame = string.Empty;

            while (player1ShipDetails != 0 || player2ShipDetails != 0)
            {
                player2ShipDetails = NextTurn(player1, player1Field, player2Ships, ref player2ShipDetails);
                if (player2ShipDetails == 0)
                {
                    Print.Text($"\n  {player1.Name} won :)\n\n", player1.Color);
                    break;
                }

                player1ShipDetails = NextTurn(player2, player2Field, player1Ships, ref player1ShipDetails);
                if (player1ShipDetails == 0)
                {
                    Print.Text($"\n  {player2.Name} won :)\n\n", player2.Color);
                    break;
                }
            }

            while (exitTheGame.ToLower() != "y" && exitTheGame.ToLower() != "n")
            {
                Print.Text("  Do you want to play again? [y] / [n]: ");
                exitTheGame = Console.ReadLine();
            }

            return exitTheGame;
        }

        private static int NextTurn(Player player, string[][] playerField, string[][] playerShips, ref int playerShipDetails)
        {
            int letter = 0;
            int number = 0;
            int indexOfLetter = 0;
            string input = string.Empty;
            bool elementIsFound = false;

            string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            while (playerShipDetails != 0)
            {
                elementIsFound = false;

                while (!elementIsFound)
                {
                    Print.BattleField(playerField);

                    Print.Text($"\n  {player.Name} turn\n\n", player.Color);
                    Print.Text("  Enter the letter: ");
                    input = Console.ReadLine().ToUpper();

                    for (int j = 0; j < letters.Length; j++)
                    {
                        if (input == letters[j])
                        {
                            elementIsFound = true;
                            indexOfLetter = j;
                            letter = numbers[j];
                            break;
                        }
                    }
                }

                elementIsFound = false;

                while (!elementIsFound)
                {
                    Print.BattleField(playerField);

                    Print.Text($"\n  {player.Name} turn\n\n", player.Color);
                    Print.Text($"  Enter the letter: {letters[indexOfLetter]}\n");
                    Print.Text("  Enter the number: ");
                    int.TryParse(Console.ReadLine(), out number);

                    for (int j = 0; j < numbers.Length; j++)
                    {
                        if (number == numbers[j])
                        {
                            elementIsFound = true;
                            break;
                        }
                    }
                }

                if (playerShips[number][letter] == "\u25A0")
                {
                    playerField[number][letter] = "X";
                    playerShips[number][letter] = "X";
                    playerShipDetails--;

                    Print.Text("  BOOM!", ConsoleColor.DarkRed);
                    Thread.Sleep(1000);

                    Print.BattleField(playerField);
                }

                else if (playerShips[number][letter] == ".")
                {
                    playerField[number][letter] = "o";
                    playerShips[number][letter] = "o";

                    Print.Text("  miss", ConsoleColor.Red);
                    Thread.Sleep(1000);

                    Print.BattleField(playerField);
                    break;
                }

                else
                {
                    Print.Text("  you already shot here", ConsoleColor.Red);
                    Thread.Sleep(2000);
                    continue;
                }
            }

            return playerShipDetails;
        }
    }
}
