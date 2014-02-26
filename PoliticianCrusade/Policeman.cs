using System;
using System.Collections.Generic;

namespace PoliticianCrusade
{
    public class Policeman : Character, IMovable
    {
        public const int RowSteps = 11;
        public const int ColSteps = 2;
        
        public Policeman(int x, int y) 
                : base(x, y)
        {
        }

        #region Action
        public void Move(int startX, int startY)
        {
            if (isAlive == false)
            {
                return;
            }

            if (base.CoordX < startX + RowSteps && base.CoordY == startY)
            {
                base.ClearImg();
                base.CoordX++;
                base.RenderImg();
            }

            if (base.CoordX == startX + RowSteps && base.CoordY < startY + ColSteps)
            {
                base.ClearImg();
                base.CoordY++;
                base.RenderImg();
            }

            if (base.CoordX > startX && base.CoordY == startY + ColSteps)
            {
                base.ClearImg();
                base.CoordX--;
                base.RenderImg();
            }

            if (base.CoordX == startX && base.CoordY >= startY)
            {
                base.ClearImg();
                base.CoordY--;
                base.RenderImg();
            }

        }
        #endregion

        #region DrawObjectMethods
        public override char[,] GetImage()
        {
            return new char[,] {
                                 { 'o', 'o'}, 
                                 { '|', '|' }, 
                             
            };
        }

        public override void RenderImg()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            base.RenderImg();
        }  
        #endregion
    }
}
