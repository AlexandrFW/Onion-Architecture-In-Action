using System;

namespace OOPConcept.GameElements.Bonuses
{
    public class Banana : Bonus, IGameObject
    {
        public Banana(Position position, ConsoleColor color, int score) : base(position, color, score) { }
    }
}