using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace PoliticianCrusade
{
    [Version ("000.820")]
    public class Game
    {
        public const int MaxHeight = 40;
        public const int MaxWidth = 100;

        //static char[,] playerField = new char[MaxHeight, MaxWidth]; //Dinko:
        
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

            var allResources = baba.AllResources();

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

                UpdateResource(allResources);

                Console.SetCursorPosition(10, 38);
                Console.Write("{0, 3}", baba.Health);

                //crash with policemen
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if ((baba.CoordX + i == policeman1.CoordX && baba.CoordY + j == policeman1.CoordY) ||
                            (baba.CoordX + i == policeman1.CoordX + 1 && baba.CoordY + j == policeman1.CoordY + 1) ||
                            (baba.CoordX + i == policeman1.CoordX + 21 && baba.CoordY + j == policeman1.CoordY + 2) || 
                            (baba.CoordX + i == policeman2.CoordX && baba.CoordY + j == policeman2.CoordY) || 
                            (baba.CoordX + i == policeman2.CoordX + 1 && baba.CoordY + j == policeman2.CoordY + 1)|| 
                            (baba.CoordX + i == policeman2.CoordX + 2 && baba.CoordY + j == policeman2.CoordY + 2)) 
                        {
                            Thread.Sleep(500);
                            if (baba.Bag.RemainingPower > 0)
                            {
                                 baba.Bag.RemainingPower -= 20;
                            }

                            if (baba.Cane.RemainingPower > 0)
                            {
                                baba.Cane.RemainingPower -= 10;
                            }
                            baba.RenderImg();
                        }
                    }
                }

                //crash with politicians
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if ((baba.CoordX + i == politician1.CoordX && baba.CoordY + j == politician1.CoordY) ||
                            (baba.CoordX + i == politician1.CoordX + 1 && baba.CoordY + j == politician1.CoordY + 1) ||
                            (baba.CoordX + i == politician1.CoordX + 2 && baba.CoordY + j == politician1.CoordY + 2) ||
                            (baba.CoordX + i == politician2.CoordX && baba.CoordY + j == politician2.CoordY) ||
                            (baba.CoordX + i == politician2.CoordX + 1 && baba.CoordY + j == politician2.CoordY + 1) ||
                            (baba.CoordX + i == politician2.CoordX + 2 && baba.CoordY + j == politician2.CoordY + 2) ||
                            (baba.CoordX + i == politician3.CoordX && baba.CoordY + j == politician3.CoordY) ||
                            (baba.CoordX + i == politician3.CoordX + 1 && baba.CoordY + j == politician3.CoordY + 1) ||
                            (baba.CoordX + i == politician3.CoordX + 2 && baba.CoordY + j == politician3.CoordY + 2))
                        {
                            Thread.Sleep(500);
                            if (baba.Umbrella.RemainingPower > 0)
                            {
                                baba.Umbrella.RemainingPower -= 10;
                            }

                            if (baba.Gun.RemainingPower > 0)
                            {
                                baba.Gun.RemainingPower -= 20;
                            }
                            baba.RenderImg();
                        }

                        
                    }
                }
            // if baba no weapons , baba become ill
            // if baba health == 0, baba dead and game over
                if (baba.Cane.RemainingPower == 0 &&
                    baba.Bag.RemainingPower == 0 &&
                    baba.Umbrella.RemainingPower == 0 &&
                    baba.Gun.RemainingPower == 0)
                {
                    if (baba.Health > 0)
                    {
                        baba.Health -= 20;
                    }

                    if (baba.Health == 0)
                    {
                        break;
                    }
                }


                Thread.Sleep(100);
            }
            Console.SetCursorPosition(47, 20);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("GAME OVER");

        }

        private static void UpdateResource(IEnumerable<IResource> allResources)
        {
            int newLiner = 0;

            foreach (var resource in allResources)
            {
                Console.SetCursorPosition(10, 33 + newLiner++);
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write("{0, 3}", resource.RemainingPower);
            }  
        }

       
    }
}
