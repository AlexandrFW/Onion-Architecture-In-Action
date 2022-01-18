using System;
using System.Drawing;

namespace OOPConcept.GameElements.Bonuses
{
	public abstract class Bonus : IGameObject
	{
		Position _position;

		ConsoleColor _color;

		private int _score;

		public Bonus(Position position, ConsoleColor color, int score)
		{
			_position = position;
			_color = color;
			_score = score;
		}

		public int Score
		{
			get
			{
				return _score;
			}
		}

		public Position Position { get => _position; set => _position = value; }
		public ConsoleColor Color { get => _color; }
	}
}