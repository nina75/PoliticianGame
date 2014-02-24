using System;
using System.Collections.Generic;

namespace PoliticianCrusade
{
    public class Money : StaticObject
    {
        private static int xCoord = 45;
        private static int yCoord = 35;

        public Money() 
                  : base(xCoord, yCoord)
        {
            this.Quantity = 0;
        }

        public int Quantity { get; protected set; }

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
