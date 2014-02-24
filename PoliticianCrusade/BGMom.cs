using System;
using System.Collections.Generic;
using System.Linq;

namespace PoliticianCrusade
{
    public class BGMom : Character
    {
        public BGMom(int x, int y)
            : base(x, y)
        {
        }

        public override char[,] GetImage()
        {
            return new char[,] {
                                  { ' ', ' ', 'O', 'o', ' ', ' ' }, 
                                  { ' ', ' ', '~', ' ',' ', ' ' }, 
                                  { '(', 'G', 'U', 'N', 'S',')' }, 
                                  {' ', '|', ' ', ' ',  '|', ' '  } 
                               };
        }
        public override void RenderImg()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            base.RenderImg();
        }
    }

}