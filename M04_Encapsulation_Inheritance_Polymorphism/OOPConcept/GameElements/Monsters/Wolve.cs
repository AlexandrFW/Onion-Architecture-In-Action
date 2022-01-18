using System;

namespace OOPConcept.GameElements.Monsters
{
    public class Wolve : Monster
    {
        public Wolve(Position position, ConsoleColor color) : base(position, color) { }

        public override void Eat(Player player)
        {
            player.Die();
        }
    }
}