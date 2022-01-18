using OOPConcept.Enums;
using OOPConcept.GameElements;
using OOPConcept.GameElements.Monsters;
using OOPConcept.GameElements.Obstacles;
using System;

namespace OOPConcept.Controllers
{
	public static class MonstersLocationController
	{
		public static void Controll(ConsoleKey e)
		{
			Direction d = Direction.None;

			switch (e)
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
			}

			IGameObject obj1;

			foreach (IGameObject obj in Game.Objects)
			{
				int dY = 0;
				int dX = 0;

				int tempX = 0;
				int tempY = 0;

				switch (obj)
				{
					case Bear:
						switch (obj.Position.Direction)
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

						tempX = obj.Position.X + dX;
						tempY = obj.Position.Y + dY;

						obj1 = obj.Position.GetCollision(Game.Objects, tempX, tempY);

						if (obj1 != null)
						{
                            switch (obj1)
                            {
								case Player:
									Program.PrintMessage($"You are picked by { obj.GetType() }");
									(obj as Bear).Eat(obj1 as Player);
									break;

								case Tree:
									Program.PrintMessage($"Player met a tree! You cannot go further. Choose another direction.");
									break;

								case Stone:
									Program.PrintMessage($"Player met a stone! You cannot go further. Choose another direction.");
									break;
							}
						}

						if (d != Direction.None)
						{
							obj.Position.Move(d);
						}
						break;

					case Wolve:
						switch (obj.Position.Direction)
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

						tempX = obj.Position.X + dX;
						tempY = obj.Position.Y + dY;

						obj1 = obj.Position.GetCollision(Game.Objects, tempX, tempY);

						if (obj1 != null)
						{
							switch (obj1)
							{
								case Player:
									Program.PrintMessage($"You are picked by { obj.GetType() }");
									(obj as Wolve).Eat(obj1 as Player);
									break;

								case Tree:
									Program.PrintMessage($"Player met a tree! You cannot go further. Choose another direction.");
									break;

								case Stone:
									Program.PrintMessage($"Player met a stone! You cannot go further. Choose another direction.");
									break;
							}
						}

						if (d != Direction.None)
						{
							obj.Position.Move(d);
						}
						break;
				}

			}

		}

	}
}