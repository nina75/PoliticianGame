using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticianCrusade
{
    public class Politician : Character, IMovable
    {
        public const int RowSteps = 11;
        public const int ColSteps = 2;
        public Politician(int x, int y) : base(x, y)
        {
        }

        public override char[,] GetImage()
        {
            return new char[,] {
                                 { ' ', '*',' ' }, 
                                 {'|', 'D', '|' }, 
                             
                               };
        }


        public void Move(int startX, int startY)
        {
            base.ClearImg();
            base.CoordX++;
            base.RenderImg();
            System.Threading.Thread.Sleep(50);

            if (base.CoordX == Console.WindowWidth - 1)
            {
                base.ClearImg();
                 base.CoordX = 0;
            }

            //if ( base.CoordX > startX && base.CoordY == startY + ColSteps)
            //{
            //    base.ClearImg();
            //    base.CoordX--;
            //    base.RenderImg();
            //    System.Threading.Thread.Sleep(200);
            //}

        }


    }
}
