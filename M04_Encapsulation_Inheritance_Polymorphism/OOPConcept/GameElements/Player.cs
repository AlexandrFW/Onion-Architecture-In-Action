using System.Collections.Generic;
using System;
using OOPConcept.GameElements.Bonuses;

namespace OOPConcept.GameElements
{
	public class Player : IGameObject
	{
		private List<Bonus> _bonuses;

		private int _nScore = 0;

		Position _position;
		ConsoleColor _color;

		public Player(Position position, ConsoleColor color)  
		{
			_position = position;
			_color = color;

			_bonuses = new List<Bonus>();
		}

		public void Use(IGameObject obj)
		{
			if (obj is Bonus bonus)
            {
				_bonuses.Add(bonus);
				_nScore += bonus.Score;
            }
		}

		public void Die()
        {
			Console.WriteLine("Sorry! You have been eaten!");
			Console.WriteLine("GAME OVER!");
			Game.Play = false;
		}

		public void Win()
        {
			Console.WriteLine("Congratulations!");
			Console.WriteLine("You are WIN!");
			Game.Play = false;
		}

		public List<Bonus> Bonuses
		{
			get
			{
				return _bonuses;
			}
		}

		public int Score { get { return _nScore; } }

        public Position Position { get => _position; set => _position = value; }
        public ConsoleColor Color { get => _color; }
    }
}