using OOPConcept.Enums;
using System.Collections.Generic;

namespace OOPConcept.GameElements
{
	public class Position
	{
		private int _x;
		private int _y;

		private int _width;
		private int _height;

		private double _widthHalf;
		private double _heightHalf;

		private Direction _direction;

		public Position(int x, int y, int width, int height)
		{
			_x = x;
			_y = y;

			_width = width;
			_height = height;

			_widthHalf = (double)width / 2.0;
			_heightHalf = (double)height / 2.0;

			_direction = Direction.Up;
		}

		public bool Move(Direction d)
		{
			int dX = 0;
			int dY = 0;

			_direction = d;

			switch (d)
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

			int tempX = _x + dX;
			int tempY = _y + dY;

			bool collided = Collide(Game.Objects, tempX, tempY);

			if (collided)
			{
				return false;
			}
			else
			{
				_x = tempX;
				_y = tempY;

				return true;
			}
		}

		public IGameObject GetCollision(List<IGameObject> objects, int tempX, int tempY)
		{
			IGameObject obj = null;

			for (int i = 0; i < objects.Count; i++)
			{
				if (objects[i].Position != this)
				{
					if (Collide(objects[i].Position, tempX, tempY))
					{
						obj = objects[i];
						break;
					}
				}
			}

			return obj;
		}

		public bool Collide(List<IGameObject> objects, int tempX, int tempY)
		{
			IGameObject obj = GetCollision(objects, tempX, tempY);

			if (obj == null)
			{
				if (
					tempX - _widthHalf < 1 ||
					tempX + _widthHalf > Game.Width - 1 ||
					tempY - _heightHalf < 1 ||
					tempY + _heightHalf > Game.Height - 1
					)
				{
					return true;
				}
				else
				{
					return false;
				}

			}
			else
			{
				return true;
			}
		}

		public bool Collide(Position obj, int tempX, int tempY)
		{
			bool collided = false;

			if (
				tempX + _widthHalf > obj.X - obj.WidthHalf &&
				tempX - _widthHalf < obj.X + obj.WidthHalf
				)
			{
				if (
					tempY + _heightHalf > obj.Y - obj.HeightHalf &&
					tempY - _heightHalf < obj.Y + obj.HeightHalf
					)
				{
					collided = true;
				}
			}

			return collided;
		}

		public int X
		{
			get => _x;
		}

		public int Y
		{
			get => _y;
		}

		public int Width
		{
			get => _width;
		}

		public int Height
		{
			get => _height;
		}

		public double WidthHalf
		{
			get =>  _widthHalf;
		}

		public double HeightHalf
		{
			get => _heightHalf;
		}

		public Direction Direction
		{
			get => _direction;
		}
	}
}