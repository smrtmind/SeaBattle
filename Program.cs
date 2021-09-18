using System;

namespace BattleSea
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            Player player1;
            Player player2;
            string playerName = string.Empty;
            string exitTheGame = string.Empty;

            Print("SeaBattle\n".PadLeft(20, ' ') + "\n", ConsoleColor.DarkBlue);

            Print("Enter 1-st player's name or press ENTER: ");
            playerName = Console.ReadLine();

            if (playerName.Length > 0)
                player1 = new Player(playerName, ConsoleColor.DarkCyan);
            else
                player1 = new Player("Player 1", ConsoleColor.DarkCyan);

            Print("Enter 2-nd player's name or press ENTER: ");
            playerName = Console.ReadLine();

            if (playerName.Length > 0)
                player2 = new Player(playerName, ConsoleColor.DarkGreen);
            else
                player2 = new Player("Player 2", ConsoleColor.DarkGreen);

            while (exitTheGame.ToLower() != "n")
            {
                ShipsCreator player1Field = new ShipsCreator(BattleField.GetNewField());
                string[][] player1Ships = player1Field.CreateShips(player1);

                ShipsCreator player2Field = new ShipsCreator(BattleField.GetNewField());
                string[][] player2Ships = player2Field.CreateShips(player2);

                exitTheGame = BattleField.StartBattle(player1, player2, player1Ships, player2Ships);
            }
        }

        public static void Print(string text, ConsoleColor color = ConsoleColor.Black)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public static void PrintBattleField(string[][] ships)
        {
            Console.Clear();
            Print("SeaBattle\n".PadLeft(20, ' ') + "\n", ConsoleColor.DarkBlue);

            for (int i = 0; i < ships.Length; i++)
            {
                Console.Write("  ");

                for (int j = 0; j < ships[i].Length; j++)
                {
                    Console.Write(ships[i][j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
