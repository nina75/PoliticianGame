using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

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

        static bool restartGame = false; // Още го размишлявам! Недейте да триете закоментираните редове!
        
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

        public GrandMom() { } //AN: празен конструктор? явно не е необходим щом работи без него :)

        public List<GameObject> EnemyList 
        {
            get
            {
                return new List<GameObject>(this.enemyList);
            }
        }

        #region Action
        public void Move()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey(true);
                while (Console.KeyAvailable)
                    Console.ReadKey(true);


                if (userInput.Key == ConsoleKey.RightArrow)
                {
                    if (base.CoordX < Game.MaxWidth - 4 && base.CoordY > 8) 
                    {
                        base.ClearImg();
                        base.CoordX++;
                        base.RenderImg();
                    }
                }

                if (userInput.Key == ConsoleKey.LeftArrow)
                {
                    if (base.CoordX > 0 && base.CoordY > 8) 
                    {
                        base.ClearImg();
                        base.CoordX--;
                        base.RenderImg();
                    }
                }
              
                if (userInput.Key == ConsoleKey.UpArrow)
                {
                    if (base.CoordY > 9) 
                    {
                        base.ClearImg();
                        base.CoordY--;
                        base.RenderImg();
                    }

                    if (base.CoordY == 9 && this.IsSpaceAvailable())
                    {
                        base.ClearImg();
                        base.CoordY -= 3;
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
                    Character baba = new GrandMom();
                    if (enemy as Character != null)
                    {
                        if (enemy.Health <= 0)
                        {
                            enemy.isAlive = false;
                            enemy.ClearImg();

                            //this.Health -= 5;               testing purposes
                            //this.Bag.RemainingPower -= 10;  testing purposes

                            this.Money.Quantity += 100;
                            
                        }
                        else
                        {
                            
                            this.EnemyInRange().Health -= 100;

                            if (baba.Health == 0)
                            {
                                DialogResult res = MessageBox.Show("GAME OVER!\nDo you want to start a new game?", "PoliticianCrusade", MessageBoxButtons.YesNo);

                                if (res == DialogResult.Yes)
                                {
                                    restartGame = true;
                                }
                                else
                                {
                                    Environment.Exit(0);
                                }
                            }
                            
                            
                            
                        }
                     }
                }
            }
        }

        public void AddEnemies(List<GameObject> objects)
        {
            var enemies = 
                        objects.Where(o => o.GetType().Name == "Politician" 
                                   || o.GetType().Name == "Policeman").ToList();

            this.enemyList.AddRange(enemies);
        }

        private Character EnemyInRange()
        {
            const int hitRange = 5;

            int startScanX = this.CoordX - hitRange;
            int endScanX = this.CoordX + hitRange;

            int startScanY = this.CoordY - hitRange;
            int endScanY = this.CoordY + hitRange;

            if (startScanX < 0)
            {
                startScanX = 0;
            }

            if (endScanX > Console.WindowWidth)
            {
                endScanX = Console.WindowWidth;
            }

            if (startScanY < 0)
            {
                startScanY = 0;
            }

            if (endScanY > Console.WindowHeight)
            {
                endScanY = Console.WindowHeight;
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
        #endregion

        public List<IResource> AllResources()
        {
            var list = new List<IResource>();

            list.Add(this.Money);
            list.Add(this.Bag);
            list.Add(this.Cane);
            list.Add(this.Gun);
            list.Add(this.Umbrella);

            return list;
        }

        #region DrawImage
        public override void RenderImg()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            base.RenderImg();
        }

        private bool IsSpaceAvailable()
        {
            return (CoordX > 7 && CoordX < 18) ||
                   (CoordX > 75 && CoordX < 86) ||
                    CoordX == 31 ||
                    CoordX == 64 
                   ;
        }
               
         
      
      
        public override char[,] GetImage()
        {
            return new char[,] {
                                 { '@', '@', '@', '@'}, 
                                 { ' ', 'o', 'o' ,' '},
                                 { '(', ' ', ' ', ')'}
            };
        }
        #endregion
    }
}
