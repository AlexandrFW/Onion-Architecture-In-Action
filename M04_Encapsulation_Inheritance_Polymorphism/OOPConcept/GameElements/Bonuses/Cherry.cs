using System;

namespace OOPConcept.GameElements.Bonuses
{
    public class Cherry : Bonus, IGameObject
    {
        public Cherry(Position position, ConsoleColor color, int score) : base(position, color, score) { }
    }
}