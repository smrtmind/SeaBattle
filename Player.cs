using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleSea
{
    public class Player
    {
        public string name { get; private set; }
        public ConsoleColor color { get; private set; }

        public Player(string name, ConsoleColor color)
        {
            this.name = name;
            this.color = color;
        }
    }
}
