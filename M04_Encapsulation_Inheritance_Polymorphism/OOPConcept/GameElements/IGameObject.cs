using System;

namespace OOPConcept.GameElements
{
	public interface IGameObject
	{
		public Position Position { get; set; }
		public ConsoleColor Color { get; }
	}
}