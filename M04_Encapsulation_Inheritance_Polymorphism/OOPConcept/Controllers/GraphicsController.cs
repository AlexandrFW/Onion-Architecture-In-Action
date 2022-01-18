using OOPConcept.Enums;
using System.Collections.Generic;
using System;
using OOPConcept.GameElements;
using OOPConcept.GameElements.Bonuses;
using OOPConcept.GameElements.Monsters;
using OOPConcept.GameElements.Obstacles;

namespace OOPConcept.Controllers
{
	public static class GraphicsController
	{
		private static string TopLine = "";
		private static string MidLine = "";

		public static void Draw(List<IGameObject> objects)
		{
			Console.Clear();

			DrawBorder();

            foreach (IGameObject obj in objects)
            {
                Draw(obj);
            }

            Console.SetCursorPosition(0, Game.Height + 1);
		}

		public static void Draw(IGameObject obj)
		{
			Console.SetCursorPosition(obj.Position.X - (int)obj.Position.WidthHalf, obj.Position.Y - (int)obj.Position.HeightHalf);
			Console.ForegroundColor = obj.Color;

			string width = "";

			char symbol = ' ';

            switch (obj.Position.Direction)
			{
				case Direction.Up:
					symbol = '↑';
					break;

				case Direction.Down:
					symbol = '↓';
					break;

				case Direction.Left:
					symbol = '←';
					break;

				case Direction.Right:
					symbol = '→';
					break;
			}

			switch (obj)
            {
				case Banana:
					symbol = ')';
					break;

				case Apple:
					symbol = 'O';
					break;

				case Cherry:
					symbol = 'Q';
					break;

				case Bear:
					symbol = '@';
					break;

				case Wolve:
					symbol = '<';
					break;

				case Tree:
					symbol = '*';
					break;

				case Stone:
					symbol = '^';
					break;
			}

			for (int i = 0; i < obj.Position.Width; i++)
			{
				width += symbol;
			}

			for (int i = 0; i < obj.Position.Height; i++)
			{
				Console.SetCursorPosition(obj.Position.X - (int)obj.Position.WidthHalf, obj.Position.Y - (int)obj.Position.HeightHalf + i);
				Console.Write(width);
			}

			Console.ForegroundColor = ConsoleColor.White;
		}

		public static void DrawBorder()
		{
			Console.ForegroundColor = ConsoleColor.White;

			InitLines();

			for (int i = 0; i < Game.Height; i++)
			{
				if (i == 0 || i == Game.Height - 1)
				{
					Console.WriteLine(TopLine);
				}
				else
				{
					Console.WriteLine(MidLine);
				}
			}
		}

		private static void InitLines()
		{
			if (TopLine == "")
			{
				for (int i = 0; i < Game.Width; i++)
				{
					if (i == 0 || i == Game.Width - 1)
					{
						TopLine += "+";
						MidLine += "|";
					}
					else
					{
						TopLine += "=";
						MidLine += " ";
					}
				}
			}
		}
	}
}