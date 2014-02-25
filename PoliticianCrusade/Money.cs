using System;
using System.Collections.Generic;

namespace PoliticianCrusade
{
    public class Money : StaticObject, IResource
    {
        private static int xCoord = 45;
        private static int yCoord = 35;

        public Money() 
                  : base(xCoord, yCoord)
        {
            this.Quantity = 0;
        }

        public int Quantity { get; set; }
        public int RemainingPower
        { 
            get
            {
                return this.Quantity;
            }
        }
        public int CoordXOnScreen
        {
            get { return 10; }
        }

        public int CoordYOnScreen
        {
            get { return 7; }
        }

        public override char[,] GetImage()
        {
            return new char[,] { 
                                 { '|', '$', '|' } ,
                                 { '|', '$', '|' } ,
                                 { '|', '$', '|' } ,
                                 
            };
        }
        public override void RenderImg()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            base.RenderImg();
        }
    }
}
