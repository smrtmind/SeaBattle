using System;

namespace BattleSea
{
    class Program
    {
        static void Main(string[] args)
        {
            Gamer gamer1;
            Gamer gamer2;
            string input = string.Empty;
            string yesOrNo = string.Empty;

            Console.Write("Enter first player's name or press ENTER: ");
            input = Console.ReadLine();
            if (input.Length > 0) 
                gamer1 = new Gamer(input, ConsoleColor.Blue);
            else 
                gamer1 = new Gamer("Player 1", ConsoleColor.Blue);

            Console.Write("Enter second player's name or press ENTER: ");
            input = Console.ReadLine();
            if (input.Length > 0) 
                gamer2 = new Gamer(input, ConsoleColor.DarkGreen);
            else 
                gamer2 = new Gamer("Player 2", ConsoleColor.DarkGreen);

            while (yesOrNo.ToLower() != "n")
            {
                ShipsLocator field1 = new ShipsLocator(BattleField.GetField());
                string[][] ships1 = field1.LocateShips(field1.field, gamer1);

                ShipsLocator field2 = new ShipsLocator(BattleField.GetField());
                string[][] ships2 = field2.LocateShips(field2.field, gamer2);

                yesOrNo = BattleField.StartBattle(gamer1, gamer2, ships1, ships2);
            }
        }
    }
}
