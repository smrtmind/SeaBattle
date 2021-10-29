using System;

namespace SeaBattle
{
    public class Player
    {
        public string Name { get; private set; }
        public ConsoleColor Color { get; private set; }
        public string ShipSymbol { get; private set; }

        public Player(string name, ConsoleColor color)
        {
            Name = SetName(name);
            Color = color;
            //visual representation of a ships. Change it here to change everywhere.
            ShipSymbol = "\u25A0";
        }

        private string SetName(string name)
        {
            if (name.Length > 0)
                return name;
            else return "Player";
        }
    }
}
