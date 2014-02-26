using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoliticianCrusade
{
    public static class Engine
    {
        public static void Action()
        {
            DrawScreen.DrawConsoleBottom();
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
                    politician2, politician3, mom, walker, baba.Money, baba.Cane, baba.Bag, baba.Umbrella, baba.Gun
                };

            baba.AddEnemies(objects);

            //Using polumorphism
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

                UpdateResource(allResources, baba);

                //Baba meets the BGMama
                if (baba.CoordX == 31 && baba.CoordY == 6)
                {
                    MeetTheBGMom(baba, mom);
                }

                //Baba meets the walker
                if (baba.CoordX == 64 && baba.CoordY == 6)
                {
                    MeetTheWalker(baba, walker);
                }

                //Handling crashes with politicians and policemen
                HandleCrashes(baba);

                if (!UpdateGrannyStatus(baba))
                {
                    break;
                }

                Thread.Sleep(100);
            }

            Console.SetCursorPosition(47, 20);
            Console.ForegroundColor = ConsoleColor.Red;
            DialogResult res = MessageBox.Show("GAME OVER!\nDo you want to start a new game?", "PoliticianCrusade", MessageBoxButtons.YesNo);

            if (res == DialogResult.Yes)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Gray;
                Action();
                
            }
            else
            {
                Environment.Exit(0);
            }

        }

        private static void HandleCrashes(GrandMom baba)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    foreach (var enemy in baba.EnemyList)
                    {
                        if ((baba.CoordX + i == enemy.CoordX && baba.CoordY + j == enemy.CoordY) ||
                            (baba.CoordX + i == enemy.CoordX + 1 && baba.CoordY + j == enemy.CoordY + 1) ||
                            (baba.CoordX + i == enemy.CoordX + 2 && baba.CoordY + j == enemy.CoordY + 2))
                        {
                            Thread.Sleep(200);

                            if (enemy.GetType().Name == "Politician")
                            {
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
                            else if (enemy.GetType().Name == "Policeman")
                            {
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
                }
            }
        }

        private static void MeetTheBGMom(GrandMom baba, BGMom mom)
        {
            DialogResult result = MessageBox.Show("Want to buy a gun?", "PoliticianCrusade", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                if (baba.Money.Quantity >= baba.Gun.Price)
                {
                    if (true)
                    {
                        baba.Gun.RemainingPower = 100;
                        baba.Money.Quantity -= baba.Gun.Price;
                    }
                    else
                    {
                        MessageBox.Show("You have full gun power");
                    }
                }
                else
                {
                    MessageBox.Show("You don't have enough money");
                }
            }
            baba.ClearImg();
            baba.CoordY += 3;
            baba.RenderImg();
            Console.SetCursorPosition(30, 4);
            mom.RenderImg();
        }

        private static void MeetTheWalker(GrandMom baba, Walker walker)
        {
            DialogResult result = MessageBox.Show("Want to buy a bag?", "PoliticianCrusade", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                if (baba.Money.Quantity >= baba.Bag.Price)
                {
                    if (baba.Bag.RemainingPower < 100)
                    {
                        baba.Bag.RemainingPower = 100;
                        baba.Money.Quantity -= baba.Bag.Price;
                    }
                    else
                    {
                        MessageBox.Show("You have full bag power");
                    }
                }
                else
                {
                    MessageBox.Show("You don't have enough money");
                }
            }
            baba.ClearImg();
            baba.CoordY += 3;
            baba.RenderImg();
            Console.SetCursorPosition(64, 4);
            walker.RenderImg();
        }

        // if baba no weapons , baba become ill
        // if baba health == 0, baba is dead and game over
        private static bool UpdateGrannyStatus(GrandMom baba)
        {
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
                        return false;
                    }
                }

            return true;
        }

        //Using polymorphism
        private static void UpdateResource(IEnumerable<IResource> allResources, GrandMom baba)
        {
            int newLiner = 0;

            foreach (var resource in allResources)
            {
                Console.SetCursorPosition(10, 33 + newLiner++);
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write("{0, 3}", resource.RemainingPower);
            }

            Console.SetCursorPosition(10, 38);
            Console.Write("{0, 3}", baba.Health);
        }
    }
}
