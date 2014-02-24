using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticianCrusade
{
    public class Gun : StaticObject, IResource
    {
        public const int price = 250;
       
        public Gun(int x, int y) 
                : base(x, y)
        {
            this.RemainingPower = 100;
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
