using System;
using System.Threading;

namespace BattleSea
{
    public class ShipsCreator
    {
        public string[][] field { get; private set; }

        public ShipsCreator(string[][] field) => this.field = field;

        public string[][] CreateShips(Player player)
        {
            LocateShip(amountOfShips: 1, maxParts: 4,
                       $"Place your \u25A0 \u25A0 \u25A0 \u25A0 ship", player);

            LocateShip(amountOfShips: 2, maxParts: 3,
                       $"Place your \u25A0 \u25A0 \u25A0 ships", player);

            LocateShip(amountOfShips: 3, maxParts: 2,
                       $"Place your \u25A0 \u25A0 ships", player);

            LocateShip(amountOfShips: 4, maxParts: 1,
                       $"Place your \u25A0 ships", player);

            return field;
        }

        private void LocateShip(int amountOfShips, int maxParts, string text, Player player)
        {
            int letter = 0;
            int number = 0;
            int indexOfLetter = 0;
            int remainingParts = maxParts;
            string input = string.Empty;
            bool elementIsFound = false;

            string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            while (amountOfShips != 0)
            {
                while (remainingParts > 0)
                {
                    elementIsFound = false;

                    while (!elementIsFound)
                    {
                        Print.BattleField(field);

                        Print.Text($"\n  {player.name} place your ships\n\n", player.color);
                        Print.Text($"  {text} ({amountOfShips} remaining)\n");
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
                        Print.BattleField(field);

                        Print.Text($"\n  {player.name} place your ships\n\n", player.color);
                        Print.Text($"  {text} ({amountOfShips} remaining)\n");
                        Print.Text($"  Enter the letter: {letters[indexOfLetter]}\n");
                        Print.Text("  Enter the number: ");
                        int.TryParse(Console.ReadLine(), out number);

                        for (int j = 0; j < numbers.Length; j++)
                            if (number == numbers[j])
                                elementIsFound = true;
                    }

                    if (field[number][letter] == "\u25A0")
                    {
                        Print.Text("  this cell is already occupied", ConsoleColor.Red);
                        Thread.Sleep(2000);
                        continue;
                    }

                    else
                    {
                        field[number][letter] = "\u25A0";
                        remainingParts--;
                        Print.BattleField(field);
                    }
                }

                amountOfShips--;
                remainingParts = maxParts;
            }
        }
    }
}
