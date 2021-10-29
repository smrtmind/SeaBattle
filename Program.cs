using System;

namespace BattleSea
{
    class Program
    {
        public static Player player1;
        public static Player player2;
        public static string input = string.Empty;

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            Print.Text("SeaBattle\n".PadLeft(20, ' ') + "\n", ConsoleColor.DarkBlue);

            Print.Text("Enter 1-st player's name or press ENTER: ");
            player1 = new Player(Console.ReadLine(), ConsoleColor.DarkCyan);

            Print.Text("Enter 2-nd player's name or press ENTER: ");
            player2 = new Player(Console.ReadLine(), ConsoleColor.DarkGreen);

            while (input.ToLower() != "n")
            {
                ShipsCreator player1Field = new ShipsCreator(BattleField.GetNewField());
                string[][] player1Ships = player1Field.CreateShips(player1);

                ShipsCreator player2Field = new ShipsCreator(BattleField.GetNewField());
                string[][] player2Ships = player2Field.CreateShips(player2);

                input = BattleField.StartBattle(player1, player2, player1Ships, player2Ships);
                Console.Clear();
            }
        }
    }
}
