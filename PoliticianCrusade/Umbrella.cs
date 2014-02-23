using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticianCrusade
{
    public class Umbrella : StaticObject, IResource
    {
        public Umbrella(int x, int y) : base(x, y)
        {
        }
        public override char[,] GetImage()
        {
            return new char[,] { 
                                 { ' ', '_', ' ' } ,
                                 { ' ', '|' , ' '} ,
                                 { '_', '_', '_'} ,
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
