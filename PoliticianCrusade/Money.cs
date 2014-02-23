using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticianCrusade
{
    public class Money : StaticObject, IResource
    {
        public Money(int x, int y) : base(x, y)
        {
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
