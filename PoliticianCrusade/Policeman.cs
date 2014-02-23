using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticianCrusade
{
    public class Policeman : Character, IMovable
    {
        public const int RowSteps = 11;
        public const int ColSteps = 2;
        public Policeman(int x, int y) : base(x, y)
        {
        }

        public override char[,] GetImage()
        {
            return new char[,] {
                                 { 'o', 'o'}, 
                                 { '|', '|' }, 
                             
                               };
        }


        public void Move(int startX, int startY)
        {
            if (base.CoordX < startX + RowSteps && base.CoordY == startY)
            {
                base.ClearImg();
                base.CoordX++;
                base.RenderImg();
                System.Threading.Thread.Sleep(50);
            }

            if (base.CoordX == startX + RowSteps && base.CoordY < startY + ColSteps)
            {
                base.ClearImg();
                base.CoordY++;
                base.RenderImg();
                System.Threading.Thread.Sleep(50);
            }

            if ( base.CoordX > startX && base.CoordY == startY + ColSteps)
            {
                base.ClearImg();
                base.CoordX--;
                base.RenderImg();
                System.Threading.Thread.Sleep(50);
            }

            if (base.CoordX == startX && base.CoordY >= startY)
            {
                base.ClearImg();
                base.CoordY--;
                base.RenderImg();
                System.Threading.Thread.Sleep(50);
            }

        }

        public override void RenderImg()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            base.RenderImg();
        }
    }
}
