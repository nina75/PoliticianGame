using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticianCrusade
{
    public class Cane : StaticObject, IResource
    {
        protected static int xCoord = 57;
        private static int yCoord = 34;

        public const int Price = 100;
       
        public Cane() 
            : base(xCoord, yCoord)
        {
            this.RemainingPower = 100;
        }

        public int RemainingPower { get; protected set; }

        public int CoordXOnScreen
        {
            get { return 10; }
        }

        public int CoordYOnScreen
        {
            get { return 35; }
        }

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
