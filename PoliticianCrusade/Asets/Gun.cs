using System;
using System.Collections.Generic;
using System.Linq;

namespace PoliticianCrusade
{
    public class Gun : StaticObject, IResource
    {
        public readonly int Price = 50;
        private static int xCoord = 92;
        private static int yCoord = 35;

        public Gun() 
                : base(xCoord, yCoord)
        {
            this.RemainingPower = 100;
        }

        #region Properties
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
                return 38;
            }
        }

        public int RemainingPower
        {
            get;
            set;
        } 
        #endregion

        #region DrawImage
        public override char[,] GetImage()
        {
            return new char[,] { 
                                 { '=', '=', '=' , '='} ,
                                 { '=', '=' ,'=', '|'} ,
                                 { ' ', ' ', '|', '|'} ,
                                 
            };
        }

        public override void RenderImg()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            base.RenderImg();
        }   
        #endregion
    }
}
