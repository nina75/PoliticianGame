using System;

namespace PoliticianCrusade
{
    public class Politician : Character, IMovable
    {
        public const int RowSteps = 11;
        public const int ColSteps = 2;

        public Politician(int x, int y)
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

            base.ClearImg();
            base.CoordX++;
            base.RenderImg();

            if (base.CoordX == Console.WindowWidth - 1)
            {
                base.ClearImg();
                base.CoordX = 0;
            }
        }

        public void MoveBack(int startX, int startY)
        {
            if (isAlive == false)
            {
                return;
            }

            base.ClearImg();
            base.CoordX--;
            base.RenderImg();

            if (base.CoordX == 2)
            {
                base.ClearImg();
                base.CoordX = Console.WindowWidth - 1;
            }
        } 
        #endregion

        #region DrawObjectMethods
        public override char[,] GetImage()
        {
            return new char[,] {
                                 { ' ', '*',' ' }, 
                                 {'|', 'D', '|' }, 
                             
            };
        }

        public override void RenderImg()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            base.RenderImg();
        } 
        #endregion
    }
}
