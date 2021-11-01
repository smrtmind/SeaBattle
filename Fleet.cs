using System;
using System.Threading;

namespace SeaBattle
{
    public class Fleet
    {
        public string[][] Field { get; private set; }
        public string[][] DraftField { get; private set; }
        public int FleetHealth { get; set; }

        //visual representation of a ships. Change it here to change everywhere.
        public static string ShipSymbol = "\u25A0";
        public static string CellFiller = ".";

        public Fleet(string[][] field)
        {
            Field = field;
            //counter of parts to be destroyed to win
            FleetHealth = 20;
            DraftField = Battle.GetNewField();
        }

        public string[][] CreateShips(Player player)
        {
            for (int amountOfShips = 1, maxParts = 4; amountOfShips <= 4; amountOfShips++, maxParts--)
                PlaceShip(amountOfShips, maxParts, player);

            return Field;
        }

        private void PlaceShip(int amountOfShips, int maxParts, Player player)
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
                        PlaceYourShips();
                        Print.Text("  Enter the letter: ");
                        input = Console.ReadLine().ToUpper();

                        for (int i = 0; i < letters.Length; i++)
                        {
                            if (input == letters[i])
                            {
                                elementIsFound = true;
                                indexOfLetter = i;
                                letter = numbers[i];
                                break;
                            }
                        }
                    }

                    elementIsFound = false;
                    while (!elementIsFound)
                    {
                        PlaceYourShips();
                        Print.Text($"  Enter the letter: {letters[indexOfLetter]}\n");
                        Print.Text("  Enter the number: ");
                        int.TryParse(Console.ReadLine(), out number);

                        for (int i = 0; i < numbers.Length; i++)
                            if (number == numbers[i])
                                elementIsFound = true;
                    }

                    if (Field[number][letter] == ShipSymbol)
                    {
                        Print.Text("  this cell is already occupied", ConsoleColor.DarkRed);
                        Thread.Sleep(2000);
                        continue;
                    }

                    else
                    {
                        Field[number][letter] = ShipSymbol;
                        remainingParts--;
                    }
                }

                amountOfShips--;
                remainingParts = maxParts;
            }

            void PlaceYourShips()
            {
                Print.BattleField(Field);
                Print.Text($"\n  {player.Name} place your ships\n\n", player.Color);

                Print.Text($"  Place your ");
                for (int i = 0; i < maxParts; i++)
                    Print.Text($"{ShipSymbol} ");
                Print.Text("ship");

                Print.Text($"({amountOfShips} remaining)\n");
            }
        }
    }
}
