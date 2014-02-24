using System;

namespace PoliticianCrusade
{
    public class Politician : Character, IMovable
    {
        public const int RowSteps = 11;
        public const int ColSteps = 2;
        public const int SleepTime = 50;

        public Politician(int x, int y)
            : base(x, y)
        {
        }

        #region Methods
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

        public void Move(int startX, int startY)
        {
            base.ClearImg();
            base.CoordX++;
            base.RenderImg();
            System.Threading.Thread.Sleep(SleepTime);

            if (base.CoordX == Console.WindowWidth - 1)
            {
                base.ClearImg();
                base.CoordX = 0;
            }
        }

        public void MoveBack(int startX, int startY)
        {
            base.ClearImg();
            base.CoordX--;
            base.RenderImg();
            System.Threading.Thread.Sleep(SleepTime);

            if (base.CoordX == 2)
            {
                base.ClearImg();
                base.CoordX = Console.WindowWidth - 1;
            }
        } 
        #endregion
    }
}
