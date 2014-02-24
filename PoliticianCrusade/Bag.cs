using System;
using System.Collections.Generic;
using System.Linq;

namespace PoliticianCrusade
{
    public class Bag : StaticObject, IResource
    {
        private static int xCoord = 68;
        private static int yCoord = 35;

        public const int price = 200;
        public Bag()
            : base(xCoord, yCoord)
        {
            this.RemainingPower = 100;
        }

        public int RemainingPower { get; set; }
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
    }
}
