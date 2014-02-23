using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticianCrusade
{
    public class Garden : StaticObject
    {
        public Garden(int x, int y) : base(x, y)
        {
        }

        public override void RenderImg()
        {
             Console.ForegroundColor = ConsoleColor.DarkGreen;
             base.RenderImg();
        }
        public override char[,] GetImage()
        {
            return new char[,] {
                                 {'*','*', '*', '*','*','*', '*', '*','*', '*', '*', '*', '*'  ,'*','*' ,'*','*','*','*'},
                                 { '*', '*','*','*','*','*', 'G', 'A','R', 'D', 'E', 'N','*','*', '*'  ,'*', '*' ,'*','*'}, 
                                 { '*','*', '*',' ', ' ', ' ',' ', ' ', ' ', ' ', ' '  ,' ', ' ',' ',' ', ' ', '*' ,'*','*'}, 
                                 { '*','*', '*',' ', ' ', ' ',' ', ' ', ' ', ' ', ' '  ,' ', ' ',' ',' ', ' ', '*' ,'*','*'}, 
                                 { '*','*', '*',' ', ' ', ' ',' ', ' ', ' ', ' ', ' '  ,' ', ' ',' ',' ', ' ', '*' ,'*','*'}, 
                                 { '*','*', '*',' ', ' ', ' ',' ', ' ', ' ', ' ', ' '  ,' ', ' ',' ',' ', ' ', '*' ,'*','*'}, 
                                 { '*','*', '*',' ', ' ', ' ',' ', ' ', ' ', ' ', ' '  ,' ', ' ',' ',' ', ' ', '*' ,'*','*'}, 
                               };
        }
    }
}
