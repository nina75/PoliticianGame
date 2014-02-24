using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticianCrusade
{
    public class GrandMom : Character
    {
        public GrandMom(int x, int y) : base(x, y)
        {
        
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
                {
                    Console.ReadKey(true);
                }
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
