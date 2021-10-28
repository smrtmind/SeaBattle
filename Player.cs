using System;

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
