using System;

namespace PoliticianCrusade
{
    public class Parliament : StaticObject, IRenderable
    {
        public Parliament(int x, int y) 
                : base(x, y)
        {
        }


        public override char[,] GetImage()
        {

            return new char[,] {
                                 { '^', '^','^', '^','^', '^', '^','^', '^', '^', '^', '^'  ,'^','^' ,'^','^','^','^','^'}, 
                                 { '^', '^','^', '^','^', '^','^', '^', '^', '^', '^', '^', '^', '^' ,'^','^','^','^','^'}, 
                                 { ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ',' ',' ', ' ', ' ', ' ' , ' ', ' ', ' ', ' ','|',' '}, 
                                 { ' ', '|', ' ', ' ', 'P', 'A', 'R', 'L', 'I', 'A','M', 'E', 'N', 'T', ' ',' ', ' ', '|', ' '}, 
                                 { ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ',' ',' ', ' ', ' ', ' ' , ' ', ' ', ' ', ' ','|',' '}, 
                                 { ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ',' ',' ', ' ', ' ', ' ' , ' ', ' ', ' ', ' ','|',' '}, 
                                 { ' ', '|', '_', '_', '_', '_', '_', '_','_', '_', '_', '_', '_', '_', '_', '_', '_','|', ' '}, 
            };
        }

        public override void RenderImg()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            base.RenderImg();
        }
    }
}
