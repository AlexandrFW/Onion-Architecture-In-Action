using System;

namespace OOPConcept.GameElements.Bonuses
{
    public class Cherry : Bonus, IGameObject
    {
        Position _position;
        ConsoleColor _color;

        public Cherry(Position position, ConsoleColor color, int score) : base(score)
        {
            _position = position;
            _color = color;
        }

        public Position Position { get => _position; set => _position = value; }
        public ConsoleColor Color { get => _color; }
    }
}