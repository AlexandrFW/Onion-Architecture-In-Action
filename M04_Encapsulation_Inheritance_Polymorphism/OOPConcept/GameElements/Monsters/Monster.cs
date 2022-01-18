using System;

namespace OOPConcept.GameElements.Monsters
{
    public abstract class Monster : IGameObject
    {
        Position _position;

        ConsoleColor _color;

        public Monster(Position position, ConsoleColor color)
        {
            _position = position;
            _color = color;
        }

        public virtual void Eat(Player player) { }
        public Position Position { get => _position; set => _position = value; }
        public ConsoleColor Color { get => _color; }
    }
}