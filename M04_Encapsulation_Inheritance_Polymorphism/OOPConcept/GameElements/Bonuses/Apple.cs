using System;

namespace OOPConcept.GameElements.Bonuses
{
    public class Apple : Bonus, IGameObject
    {
        public Apple(Position position, ConsoleColor color, int score) : base(position, color, score) { }
    }
}