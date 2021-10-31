using System;

namespace SeaBattle
{
    public class Player
    {
        public string Name { get; private set; }
        public ConsoleColor Color { get; private set; }

        public Player(string name, ConsoleColor color)
        {
            Name = SetName(name);
            Color = color;
        }

        private string SetName(string name)
        {
            Random random = new Random();

            if (name.Length > 0)
                return name;
            else return $"Soldier {random.Next(50, 300)}";
        }
    }
}
