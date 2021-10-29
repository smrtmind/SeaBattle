using System;

namespace SeaBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            string endTheGame = string.Empty;

            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            Print.Text("SeaBattle\n".PadLeft(20, ' ') + "\n", ConsoleColor.DarkBlue);

            Print.Text("Enter 1-st player's name or press ENTER: ");
            Player player1 = new Player(Console.ReadLine(), ConsoleColor.DarkCyan);

            Print.Text("Enter 2-nd player's name or press ENTER: ");
            Player player2 = new Player(Console.ReadLine(), ConsoleColor.DarkGreen);

            while (endTheGame.ToLower() != "n")
            {
                string[][] player1Fleet = Fleet.CreateShips(player1, BattleField.CreateNew());
                string[][] player2Fleet = Fleet.CreateShips(player2, BattleField.CreateNew());

                endTheGame = BattleField.StartBattle(player1, player2, player1Fleet, player2Fleet);
                Console.Clear();
            }
        }
    }
}
