using System;
using System.Collections.Generic;
using System.Linq;

namespace PoliticianCrusade
{
    public class Bag : StaticObject, IResource
    {
        public readonly int Price = 200;
        private static int xCoord = 68;
        private static int yCoord = 35;
        
        public Bag()
            : base(xCoord, yCoord)
        {
            this.RemainingPower = 100;
        }

        #region Properties
        public int RemainingPower
        {
            get;
            set;
        }

        public int CoordXOnScreen
        {
            get
            {
                return 10;
            }
        }

        public int CoordYOnScreen
        {
            get
            {
                return 36;
            }
        } 
        #endregion

        #region DrawImage
        public override char[,] GetImage()
        {
            return new char[,] { 
                                 { ' ', '(', ' ', ')', ' ' } ,
                                 { '-', '-', '-' , '-', '-'} ,
                                 { '_', '_', '_' , '_', '_'} ,
                                 
            };
        }

        public override void RenderImg()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            base.RenderImg();
        } 
        #endregion
    }
}
