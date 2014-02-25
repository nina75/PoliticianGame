using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticianCrusade
{
    public class Gun : StaticObject, IResource
    {
        private static int xCoord = 92;
        private static int yCoord = 35;

        public const int Price = 250;
       
        public Gun() 
                : base(xCoord, yCoord)
        {
            this.RemainingPower = 100;
        }
        public int CoordXOnScreen
        {
            get { return 10; }
        }

        public int CoordYOnScreen
        {
            get { return 38; }
        }
        
        public int RemainingPower { get; set; }
        
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
    }
}
