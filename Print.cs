using System;

namespace BattleSea
{
    public class Print
    {
        public static void Text(string text, ConsoleColor color = ConsoleColor.Black)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public static void BattleField(string[][] ships)
        {
            Console.Clear();
            Text("SeaBattle\n".PadLeft(20, ' ') + "\n", ConsoleColor.DarkBlue);

            for (int i = 0; i < ships.Length; i++)
            {
                Text("  ");

                for (int j = 0; j < ships[i].Length; j++)
                    Text(ships[i][j] + " ");
                Text("\n");
            }
        }
    }
}
