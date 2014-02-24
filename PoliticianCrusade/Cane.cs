using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticianCrusade
{
    public class Cane : StaticObject, IResource
    {
        private static int xCoord = 57;
        private static int yCoord = 34;

        public const int price = 100;
       
        public Cane() 
            : base(xCoord, yCoord)
        {
            this.RemainingPower = 100;
        }

        public int RemainingPower { get; set; }

        public override char[,] GetImage()
        {
            return new char[,] { 
                                 { '_', '_' } ,
                                 { '|', '|' } ,
                                 { ' ', '|',} ,
                                 { ' ', '|',} ,
                                 
            };
        }

        public override void RenderImg()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            base.RenderImg();
        }
    }
}
