using System;

namespace OOPConcept.GameElements.Bonuses
{
    public class Apple : Bonus, IGameObject
    {
        Position _position;
        ConsoleColor _color;

        public Apple(Position position, ConsoleColor color, int score) : base(score)
        {
            _position = position;
            _color = color;
        }

        public Position Position { get => _position; set => _position = value; }
        public ConsoleColor Color { get => _color; }
    }
}