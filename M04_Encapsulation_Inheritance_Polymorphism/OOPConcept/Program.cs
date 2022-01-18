using OOPConcept.Controllers;
using OOPConcept.GameElements;
using OOPConcept.GameElements.Bonuses;
using OOPConcept.GameElements.Monsters;
using OOPConcept.GameElements.Obstacles;
using System;
using System.Threading;

namespace OOPConcept
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("M04. Encapsulation. Inheritance. Polymorphism");

            InitGame();

            Console.Beep();

            StartMonsterLocationChangeThread();
            PlayerLocationUpdate();

            Console.ReadKey();
        }

        private static void StartMonsterLocationChangeThread()
        {
            var thread = new Thread(new ThreadStart(MonsterLocationUpdate));
            thread.IsBackground = true; 
            thread.Start();
        }

        private static void InitGame()
{
            Game.Player = new Player(new Position(5, 10, 2, 2), ConsoleColor.White);

            // Add Player to the game field
            Game.Objects.Add(Game.Player);

            // Add Monsters to the game field
            Game.Objects.Add(new Bear(new Position(10, 10, 3, 2), ConsoleColor.Red));
            Game.Objects.Add(new Wolve(new Position(15, 10, 2, 2), ConsoleColor.Blue));
            Game.Objects.Add(new Wolve(new Position(25, 20, 2, 2), ConsoleColor.Yellow));

            // Add Obstacles to the game field
            Game.Objects.Add(new Stone(new Position(35, 5, 2, 2), ConsoleColor.Gray));
            Game.Objects.Add(new Tree(new Position(40, 3, 3, 3), ConsoleColor.DarkGreen));

            Game.Objects.Add(new Tree(new Position(40, 10, 3, 3), ConsoleColor.DarkGreen));
            Game.Objects.Add(new Tree(new Position(55, 10, 3, 3), ConsoleColor.DarkGreen));
            Game.Objects.Add(new Tree(new Position(65, 15, 3, 3), ConsoleColor.DarkGreen));
            Game.Objects.Add(new Tree(new Position(65, 21, 3, 3), ConsoleColor.DarkGreen));

            // Add Bonuses to the game field
            Game.Objects.Add(new Apple(new Position(45, 10, 2, 2), ConsoleColor.Green, 30));
            Game.Objects.Add(new Cherry(new Position(18, 10, 2, 2), ConsoleColor.DarkMagenta, 25));
            Game.Objects.Add(new Banana(new Position(25, 5, 3, 2), ConsoleColor.Yellow, 45));
        }

        private static void PlayerLocationUpdate()
        {
			ConsoleKeyInfo e;

            while (Game.Play)
            {
                e = Console.ReadKey();

                PlayerLocationController.Controll(e);
            }
		}

        private static void MonsterLocationUpdate()
        {
            var rnd = new Random();

            while (Game.Play)
            {
                GraphicsController.Draw(Game.Objects);

                var nDirection = rnd.Next(1, 4);

                ConsoleKey e = nDirection switch
                {
                    1 => ConsoleKey.UpArrow,
                    2 => ConsoleKey.DownArrow,
                    3 => ConsoleKey.LeftArrow,
                    4 => ConsoleKey.RightArrow,
                    _ => ConsoleKey.UpArrow
                };

                MonstersLocationController.Controll(e);

                Thread.Sleep(1000);
            }
        }

        public static void PrintMessage(string sMsg)
        {
            Console.WriteLine(sMsg);
        }
    }
}