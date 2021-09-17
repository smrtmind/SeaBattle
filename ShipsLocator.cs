using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleSea
{
    public class ShipsLocator
    {
        public string[][] field { get; private set; }

        public ShipsLocator(string[][] field)
        {
            this.field = field;
        }

        public string[][] LocateShips(string[][] field, Gamer player)
        {
            GetCells(amountOfShips: 1, partsMax: 4,
                     $"Place your \u25A0 \u25A0 \u25A0 \u25A0 ship",
                     $"{player.name} place your ships", player);

            GetCells(amountOfShips: 2, partsMax: 3,
                     $"Place your \u25A0 \u25A0 \u25A0 ships",
                     $"{player.name} place your ships", player);

            GetCells(amountOfShips: 3, partsMax: 2,
                     $"Place your \u25A0 \u25A0 ships",
                     $"{player.name} place your ships", player);

            GetCells(amountOfShips: 4, partsMax: 1,
                     $"Place your \u25A0 ships",
                     $"{player.name} place your ships", player);

            return field;
        }

        public void GetCells(int amountOfShips, int partsMax, string phrase, string playerName, Gamer gamer)
        {
            int letter = 0;
            int number = 0;
            int indexOfLetter = 0;
            int currentAmountOfParts = partsMax;
            string input = string.Empty;
            bool elementFound = false;

            string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            while (amountOfShips != 0)
            {
                while (currentAmountOfParts > 0)
                {
                    elementFound = false;

                    while (!elementFound)
                    {
                        Gamer.PrintCurrentField(field);

                        Console.ForegroundColor = gamer.color;
                        Console.WriteLine($"\n  {playerName}");
                        Console.ForegroundColor = ConsoleColor.Black;

                        Console.WriteLine($"  {phrase} ({amountOfShips} remaining)");
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
                        Gamer.PrintCurrentField(field);

                        Console.ForegroundColor = gamer.color;
                        Console.WriteLine($"\n  {playerName}");
                        Console.ForegroundColor = ConsoleColor.Black;

                        Console.WriteLine($"  {phrase} ({amountOfShips} remaining)");
                        Console.WriteLine($"  Enter the letter: {letters[indexOfLetter]}");
                        Console.Write("  Enter the number: ");
                        int.TryParse(Console.ReadLine(), out number);

                        for (int j = 0; j < numbers.Length; j++)
                            if (number == numbers[j]) 
                                elementFound = true;
                    }

                    if (this.field[number][letter] == "\u25A0")
                        continue;

                    else
                    {
                        this.field[number][letter] = "\u25A0";
                        currentAmountOfParts--;
                        Gamer.PrintCurrentField(field);
                    }
                }

                amountOfShips--;
                currentAmountOfParts = partsMax;
            }
        }
    }
}
