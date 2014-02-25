using System;
using System.Reflection;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace PoliticianCrusade
{
    [Version ("0.82")]
    public class Game
    {
        public const int MaxHeight = 40;
        public const int MaxWidth = 100;
        //static char[,] playerField = new char[MaxHeight, MaxWidth];
        static void Main()
        {
            Console.BufferHeight = Console.WindowHeight = MaxHeight;
            Console.BufferWidth = Console.WindowWidth = MaxWidth;
            DrawScreen.DrawConsoleBottom();

            Engine();
        }

        private static void Engine()
        {

            var baba = new GrandMom(48, 23);
            var parliament = new Parliament(40, 2);
            var garden1 = new Garden(5, 2);
            var garden2 = new Garden(73, 2);
            var policeman1 = new Policeman(76, 4);
            var policeman2 = new Policeman(8, 4);
            var politician1 = new Politician(0, 12);
            var politician2 = new Politician(97, 15);
            var politician3 = new Politician(0, 18);
            var mom = new BGMom(30, 4);
            var walker = new Walker(64, 4);

            Console.SetCursorPosition(0, 33);
            Console.WriteLine("Money:        $  Use Arrows: ");
            Console.WriteLine("Cane:         %  UP");
            Console.WriteLine("Bag:          %  DOWN  ");
            Console.WriteLine("Umbrella:     %  LEFT ");
            Console.WriteLine("Gun:          %  RIGHT");
            Console.WriteLine("Health:       %");
            var objects =
                new List<GameObject>()
                {
                    baba, parliament, garden1, garden2, policeman1, policeman2, politician1,
                    politician2, politician3, mom,walker, baba.Money, baba.Cane, baba.Bag, baba.Umbrella, baba.Gun
                };

            baba.AddEnemies(objects);

            foreach (var obj in objects)
            {
                obj.RenderImg();
            }

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                baba.Move();
                Console.ForegroundColor = ConsoleColor.Yellow;
                policeman1.Move(76, 4);
                policeman2.Move(8, 4);
                politician1.Move(0, 12);
                politician2.MoveBack(97, 15);
                politician3.Move(0, 18);

                UpdateResource(baba);

                Thread.Sleep(100);
            }
        }

        private static void UpdateResource(GrandMom baba)
        {
            var allResources = baba.AllResources();

            int newLiner = 0;

            foreach (var resource in allResources)
            {
                Console.SetCursorPosition(10, 33 + newLiner++);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(resource.RemainingPower);
            }

            Console.SetCursorPosition(10, 33 + newLiner);
            Console.Write(baba.Health);
            
        }
    }
}
