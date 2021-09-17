using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleSea
{
    public class Gamer
    {
        public string name { get; private set; }
        public ConsoleColor color { get; private set; }

        public Gamer(string name, ConsoleColor color)
        {
            this.name = name;
            this.color = color;
        }

        public static void PrintCurrentField(string[][] ships)
        {
            Console.Clear();

            Console.WriteLine();
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
