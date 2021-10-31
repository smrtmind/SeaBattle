using System;

namespace SeaBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            string exitTheGame = string.Empty;

            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            Print.Text("SeaBattle\n".PadLeft(20, ' ') + "\n", ConsoleColor.DarkBlue);

            Print.Text("Enter 1-st player's name or press ENTER: ");
            Player P1 = new Player(Console.ReadLine(), ConsoleColor.DarkCyan);

            Print.Text("Enter 2-nd player's name or press ENTER: ");
            Player P2 = new Player(Console.ReadLine(), ConsoleColor.DarkMagenta);

            while (exitTheGame != "n")
            {
                Fleet fleetP1 = new Fleet(BattleField.GetEmpty());
                Fleet fleetP2 = new Fleet(BattleField.GetEmpty());

                fleetP1.CreateShips(P1);
                fleetP2.CreateShips(P2);

                BattleField.StartBattle(P1, P2, fleetP1, fleetP2);

                do
                {
                    Print.Text("  Do you want to play again? [y] / [n]: ");
                    exitTheGame = Console.ReadLine().ToLower();
                }
                while (exitTheGame != "y" && exitTheGame != "n");
            }
        }
    }
}
