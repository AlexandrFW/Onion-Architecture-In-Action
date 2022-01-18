using System;

namespace OOPConcept.GameElements.Monsters
{
    public class Bear : Monster
    {
        public Bear(Position position, ConsoleColor color) : base(position, color) { }

        public override void Eat(Player player)
        {
            player.Die();
        }
    }
}