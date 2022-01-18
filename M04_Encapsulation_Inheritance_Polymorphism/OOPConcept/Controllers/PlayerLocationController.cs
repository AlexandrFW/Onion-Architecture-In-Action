using OOPConcept.Enums;
using OOPConcept.GameElements;
using OOPConcept.GameElements.Bonuses;
using OOPConcept.GameElements.Obstacles;
using System;

namespace OOPConcept.Controllers
{
	public static class PlayerLocationController
	{
		public static void Controll(ConsoleKeyInfo e)
		{
			Direction d = Direction.None;

			switch (e.Key)
			{
				case ConsoleKey.UpArrow:
					d = Direction.Up;
					break;

				case ConsoleKey.DownArrow:
					d = Direction.Down;
					break;

				case ConsoleKey.LeftArrow:
					d = Direction.Left;
					break;

				case ConsoleKey.RightArrow:
					d = Direction.Right;
					break;

				case ConsoleKey.Escape:
					Console.SetCursorPosition(0, Game.Height + 1);
					PrintMessage("Are you sure you want to exit? (y/n)");

					e = Console.ReadKey();

					PrintMessage("\nGood Bye!");
					if (e.Key == ConsoleKey.Y)
					{
						Game.Play = false;
					}
					break;
			}

			IGameObject obj = null;

			int dY = 0;
			int dX = 0;

			switch (Game.Player.Position.Direction)
			{
				case Direction.Up:
					dY = -1;
					break;

				case Direction.Down:
					dY = 1;
					break;

				case Direction.Left:
					dX = -1;
					break;

				case Direction.Right:
					dX = 1;
					break;
			}

			int tempX = Game.Player.Position.X + dX;
			int tempY = Game.Player.Position.Y + dY;

			obj = Game.Player.Position.GetCollision(Game.Objects, tempX, tempY);

			if (obj != null)
			{
				// Collect the bonus and check the obstacles
				switch (obj)
				{
					case Banana:
						Game.Player.Use(obj as Banana);
						Game.Objects.Remove(obj as Banana);
						PrintMessage($"Player picked an banana! Current score is { Game.Player.Score }");
						break;

					case Apple:
						Game.Player.Use(obj as Apple);
						Game.Objects.Remove(obj as Apple);
						PrintMessage($"Player picked an apple! Current score is { Game.Player.Score }");
						break;

					case Cherry:
						Game.Player.Use(obj as Cherry);
						Game.Objects.Remove(obj as Cherry);
						PrintMessage($"Player picked an chery! Current score is { Game.Player.Score }");
						break;

					case Tree:
						PrintMessage($"Player met a tree! You cannot go further. Choose another direction.");
						break;

					case Stone:
						PrintMessage($"Player met a stone! You cannot go further. Choose another direction.");
						break;
				}

				// If all bonuses are collected the Player WIN the game
				var nBonusesOnTheField = Game.Objects.FindAll(x => x is Bonus).Count;
				if (nBonusesOnTheField <= 0)
				{
					Game.Player.Win();
				}
			}

			if (d != Direction.None)
			{
				Game.Player.Position.Move(d);
			}
		}

		private static void PrintMessage(string sMsg)
        {
			Console.WriteLine(sMsg);
        }
	}
}