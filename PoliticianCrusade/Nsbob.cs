using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticianCrusade
{
    public class Nsbob : Character, IMovable
    {

        //TODO : Attach the class to the main logic.It is similar to Politician.
        public const int RowSteps = 30;
        public const int ColSteps = 20;

        public Nsbob(int x, int y)
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
                                 {'*', '*', '*' },
                                 {'*', '*', '*' },
                             
            };
        }

        public override void RenderImg()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            base.RenderImg();
        }
        #endregion
    }
}