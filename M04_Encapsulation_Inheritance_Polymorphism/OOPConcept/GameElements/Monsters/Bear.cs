using System;

namespace OOPConcept.GameElements.Monsters
{
    public class Bear : Monster, IGameObject
    {
        Position _position;
        ConsoleColor _color;

        public Bear(Position position, ConsoleColor color)
        {
            _position = position;
            _color = color;
        }
        
        public override void Eat(Player player)
        {
            player.Die();
        }

        public Position Position { get => _position; set => _position = value; }
        public ConsoleColor Color { get => _color; }
    }
}