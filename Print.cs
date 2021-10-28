using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Print.Text("SeaBattle\n".PadLeft(20, ' ') + "\n", ConsoleColor.DarkBlue);

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
