using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace PoliticianCrusade
{
    public class Game
    {
        public const int MaxHeight = 40;
        public const int MaxWidth = 100;

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

            Console.SetCursorPosition(0, 34);
            Console.WriteLine("Money: {0, 6} $  Use Arrows: ", baba.Money.Quantity);
            Console.WriteLine("Cane:     {0, 3} %   UP", baba.Cane.RemainingPower);
            Console.WriteLine("Bag:      {0, 3} %  DOWN  ", baba.Bag.RemainingPower);
            Console.WriteLine("Umbrella: {0, 3} %  LEFT ", baba.Umbrella.RemainingPower);
            Console.WriteLine("Gun:      {0, 3} %  RIGHT", baba.Gun.RemainingPower);

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

                Thread.Sleep(100);
            }
        }

        private static void UpdateResource(IResource resource)
        {
            Console.SetCursorPosition(resource.CoordXOnScreen, resource.CoordYOnScreen);
            Console.Write("   ");
            Console.SetCursorPosition(resource.CoordXOnScreen, resource.CoordYOnScreen);
            Console.Write(resource.RemainingPower);
        }
    }
}
