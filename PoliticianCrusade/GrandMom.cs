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
                    if (true) // constrain
                    {
                        base.ClearImg();
                        base.CoordX ++;
                        base.RenderImg();
                    }
                }

                if (userInput.Key == ConsoleKey.LeftArrow)
                {
                    if (true) // constrain
                    {
                        base.ClearImg();
                        base.CoordX--;
                        base.RenderImg();
                    }
                }
                if (userInput.Key == ConsoleKey.UpArrow)
                {
                    if (true) // constrain
                    {
                        base.ClearImg();
                        base.CoordY--;
                        base.RenderImg();
                    }
                }

                if (userInput.Key == ConsoleKey.DownArrow)
                {
                    if (true) // constrain
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
