using System;
using System.Threading;

namespace SeaBattle
{
    public class BattleField
    {
        public static string[][] GetEmpty()
        {
            string[][] newField = new string[11][];

            //initialization of top letters
            newField[0] = new string[11];
            newField[0][0] = "  ";

            string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };

            for (int j = 1; j < newField[0].Length; j++)
                newField[0][j] = letters[j - 1];

            //initialization of first numbers
            for (int i = 1; i < newField.Length; i++)
            {
                newField[i] = new string[11];
                newField[i][0] = i.ToString() + " ";
            }

            newField[10][0] = 10.ToString();

            //initializition of fillers
            for (int i = 1; i < newField.Length; i++)
                for (int j = 1; j < newField[i].Length; j++)
                    newField[i][j] = ".";

            Print.BattleField(newField);

            return newField;
        }

        public static void StartBattle(Player P1, Player P2, Fleet fleetP1, Fleet fleetP2)
        {
            while (fleetP1.FleetHealth != 0 || fleetP2.FleetHealth != 0)
            {
                fleetP2.FleetHealth = NextTurn(P1, fleetP1.DraftField, fleetP2.Field, fleetP2.FleetHealth);
                if (fleetP2.FleetHealth == 0)
                {
                    Print.Text($"\n  {P1.Name} won :)\n\n", P1.Color);
                    return;
                }

                fleetP1.FleetHealth = NextTurn(P2, fleetP2.DraftField, fleetP1.Field, fleetP1.FleetHealth);
                if (fleetP1.FleetHealth == 0)
                {
                    Print.Text($"\n  {P2.Name} won :)\n\n", P2.Color);
                    return;
                }
            }
        }

        private static int NextTurn(Player player, string[][] playerField, string[][] playerFleet, int fleetHealth)
        {
            int letter = 0;
            int number = 0;
            int indexOfLetter = 0;
            string input = string.Empty;
            bool elementIsFound = false;

            string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            while (fleetHealth != 0)
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

                if (playerFleet[number][letter] == Fleet.ShipSymbol)
                {
                    playerField[number][letter] = "X";
                    playerFleet[number][letter] = "X";
                    fleetHealth--;

                    Print.Text("  BOOM!", ConsoleColor.DarkRed);
                    Thread.Sleep(1000);

                    Print.BattleField(playerField);
                }

                else if (playerFleet[number][letter] == ".")
                {
                    playerField[number][letter] = "o";
                    playerFleet[number][letter] = "o";

                    Print.Text("  miss", ConsoleColor.DarkRed);
                    Thread.Sleep(1000);

                    Print.BattleField(playerField);
                    break;
                }

                else
                {
                    Print.Text("  you already shot here", ConsoleColor.DarkRed);
                    Thread.Sleep(2000);
                    continue;
                }
            }

            return fleetHealth;
        }
    }
}
