using System;

namespace SeaBattle
{
    public class Print
    {
        public static void Text(string text, ConsoleColor color = ConsoleColor.Black)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public static void BattleField(string[][] field)
        {
            Console.Clear();
            Text("SeaBattle\n".PadLeft(20, ' ') + "\n", ConsoleColor.DarkBlue);

            for (int i = 0; i < field.Length; i++)
            {
                Text("  ");

                for (int j = 0; j < field[i].Length; j++)
                    Text(field[i][j] + " ");
                Text("\n");
            }
        }
    }
}
