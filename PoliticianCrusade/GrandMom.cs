using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public List<GameObject> EnemyList 
        {
            get
            {
                return new List<GameObject>(this.enemyList);
            }
        }

         public List<IWeapon> AllWeapons()
        {
            var list = new List<IWeapon>();

            list.Add(this.Cane);
            list.Add(this.Bag);
            list.Add(this.Umbrella);
            list.Add(this.Gun);

            return list;
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

                if (userInput.Key == ConsoleKey.A)
                {
                    this.AttackNearbyEnemy(this.Cane, 5);
                }

                if (userInput.Key == ConsoleKey.S)
                {
                    this.AttackNearbyEnemy(this.Bag, 3);
                }

                if (userInput.Key == ConsoleKey.D)
                {
                    this.AttackNearbyEnemy(this.Umbrella, 7);
                }

                if (userInput.Key == ConsoleKey.F)
                {
                    this.AttackNearbyEnemy(this.Gun, 15);
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

        private void AttackNearbyEnemy(IWeapon weapon, int hitRange)
        {
            if (weapon.RemainingPower <= 0)
            {
                return;
            }

            Character enemy = this.EnemyInRange(hitRange);
            //Character baba = new GrandMom();
            if (enemy as Character != null)
            {
                if (enemy.Health <= 0)
                {
                    enemy.isAlive = false;
                    enemy.ClearImg(true);

                    this.Money.Quantity += 100;
                }
                else
                {
                    enemy.Health -= weapon.Damage;
                    weapon.RemainingPower -= weapon.WearPerUse;

                    if (enemy.Health <= 0)
                    {
                        enemy.isAlive = false;
                        enemy.ClearImg(true);

                        this.Money.Quantity += 100;
                    }
                }
            }
        }

        private Character EnemyInRange(int hitRange)
        {
            //const int hitRange = 5;

            int startScanX = this.CoordX - hitRange;
            int endScanX = this.CoordX + hitRange;

            int startScanY = this.CoordY - hitRange;
            int endScanY = this.CoordY + hitRange;

            if (startScanX < 0)
                startScanX = 0;

            if (endScanX > Console.WindowWidth)
                endScanX = Console.WindowWidth;

            if (startScanY < 0)
                startScanY = 0;

            if (endScanY > Console.WindowHeight)
                endScanY = Console.WindowHeight;

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

        #region DrawObjectMethods
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
