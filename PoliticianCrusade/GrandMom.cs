using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace PoliticianCrusade
{
    public class GrandMom : Character
    {
        private List<GameObject> enemyList;

        public Money Money { get; private set; }

        public Cane Cane { get; private set; }

        public Bag Bag { get; private set; }

        public Umbrella Umbrella { get; private set; }

        public Gun Gun { get; private set; }

        public List<GameObject> EnemyList
        {
            get
            {
                return new List<GameObject>(this.enemyList);
            }
        }

        public GrandMom(int x, int y)
            : base(x, y)
        {
            this.enemyList = new List<GameObject>();

            this.Money = new Money();
            this.Cane = new Cane();
            this.Bag = new Bag();
            this.Umbrella = new Umbrella();
            this.Gun = new Gun();
        }
        
        public GrandMom()
        {
        }

        public override void RenderImg()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            base.RenderImg();
        }

        public void Move()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey(true);
                while (Console.KeyAvailable)
                    Console.ReadKey(true);
                
                if (userInput.Key == ConsoleKey.RightArrow)
                {
                    if (base.CoordX < Game.MaxWidth - 4) 
                    {
                        base.ClearImg();
                        base.CoordX ++;
                        base.RenderImg();
                    }
                }

                if (userInput.Key == ConsoleKey.LeftArrow)
                {
                    if (base.CoordX > 0) 
                    {
                        base.ClearImg();
                        base.CoordX--;
                        base.RenderImg();
                    }
                }
              
                if (userInput.Key == ConsoleKey.UpArrow)
                {
                    if (base.CoordY > 0) 
                    {
                        base.ClearImg();
                        base.CoordY--;
                        base.RenderImg();
                    }
                }

                if (userInput.Key == ConsoleKey.DownArrow)
                {
                    if (base.CoordY < Game.MaxHeight - 11) 
                    {
                        base.ClearImg();
                        base.CoordY++;
                        base.RenderImg();
                    }
                }

                if (userInput.Key == ConsoleKey.Spacebar)
                {
                    Character enemy = this.EnemyInRange();
                    if (enemy as Character != null)
                    {
                        if (this.EnemyInRange().Health <= 0)
                        {
                            this.EnemyInRange().isAlive = false;
                            this.Money.Quantity += 100;
                        }
                        else
                        {
                            this.EnemyInRange().Health -= 100;
                        }
                     }
                }
            }
        }

        public void AddEnemies(List<GameObject> objects)
        {
            var enemies = objects
                .Where(o => o.GetType().Name == "Politician" || o.GetType().Name == "Policeman")
                .ToList();

            this.enemyList.AddRange(enemies);
        }

        private Character EnemyInRange()
        {
            const int hitRange = 10;
            int startScanX = this.CoordX - hitRange;
            int endScanX = this.CoordX + hitRange;

            int startScanY = this.CoordY - hitRange;
            int endScanY = this.CoordY + hitRange;

            if (startScanX < 0 || startScanY < 0 ||
                endScanX > Console.WindowWidth ||
                endScanY > Console.WindowHeight)
            {
                return null;
            }

            for (int i = startScanX; i < endScanX; i++)
            {
                for (int j = startScanY; j < endScanY; j++)
                {
                    foreach (var enemy in enemyList)
                    {
                        if (enemy.CoordX == i && enemy.CoordY == j)
                        {
                            var bufferedEnemy = enemy as Character;

                            if (bufferedEnemy != null && bufferedEnemy.isAlive == true)
                            {
                                return enemy as Character;
                            }
                        }
                    }
                }
            }

            return null;
        }

        public override char[,] GetImage()
        {
            return new char[,] {
                                 { '@', '@', '@', '@'}, 
                                 { ' ', 'o', 'o' ,' '},
                                 { '(', ' ', ' ', ')'}
            };
        }

    }
}
