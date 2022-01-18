using System;

namespace OOPConcept.GameElements.Obstacles
{
    public abstract class Obstacle : IGameObject
    {
        Position _position;
        ConsoleColor _color;

        public Obstacle(Position position, ConsoleColor color)
        {
            _position = position;
            _color = color;
        }

        public Position Position { get => _position; set => _position = value; }
        public ConsoleColor Color { get => _color; }
    }
}