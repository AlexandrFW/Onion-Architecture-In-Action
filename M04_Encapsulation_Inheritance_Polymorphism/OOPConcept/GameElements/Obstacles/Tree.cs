using System;

namespace OOPConcept.GameElements.Obstacles
{
    public class Tree : Obstacle, IGameObject
    {
        Position _position;
        ConsoleColor _color;

        public Tree(Position position,  ConsoleColor color)
        {
            _position = position;
            _color = color;
        }

        public Position Position { get => _position; set => _position = value; }
        public ConsoleColor Color { get => _color; }
    }
}