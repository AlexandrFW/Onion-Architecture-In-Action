using OOPConcept.GameElements;
using System.Collections.Generic;

namespace OOPConcept
{
    public class Game
    {
		public static bool Play = true;

		public static List<IGameObject> Objects = new List<IGameObject>();
		public static Player Player;

		public const int Width = 100;
		public const int Height = 25;

		public static int Selection = -1;
	}
}