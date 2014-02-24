using System;
using System.Collections.Generic;
using System.Linq;

namespace PoliticianCrusade
{
    public class GrandMom : Character
    {
        public Money Money { get; private set; }

        public Cane Cane { get; private set; }

        public Bag Bag { get; private set; }

        public Umbrella Umbrella { get; private set; }

        public Gun Gun { get; private set; }

        public GrandMom(int x, int y)
            : base(x, y)
        {
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
            }
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
