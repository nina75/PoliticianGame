using System;
using System.Collections.Generic;

namespace PoliticianCrusade
{
    public class Umbrella : StaticObject, IResource
    {
        public const int price = 150;
       
        public Umbrella(int x, int y) 
                : base(x, y)
        {
            this.RemainingPower = 100;
        }

        public int RemainingPower{ get; set; }
        
        public override char[,] GetImage()
        {
            return new char[,] { 
                                 { ' ', '_', ' ' } ,
                                 { ' ', '|' , ' '} ,
                                 { '_', '_', '_' } ,
                                 { '\\', '|', '/'} ,
                                 { ' ', '|' , ' '} ,
                                 
            };
        }

        public override void RenderImg()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            base.RenderImg();
        }
    }
}
