using System;

namespace PoliticianCrusade
{
    public class Walker : Character
    {
        public Walker(int x, int y)
            : base(x, y)
        {
        }

        #region DrawObjectMethods
        public override char[,] GetImage()
        {
            return new char[,] {
                                  { ' ', 'o', 'o', ' ' }, 
                                  { ' ', '~', ' ', ' ' }, 
                                  { '(', ' ', ' ', ')' }, 
                                  {' ', '|', '|', ' '  } 
                               };
        }
        public override void RenderImg()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            base.RenderImg();
        } 
        #endregion
    }
}
