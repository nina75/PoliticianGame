using System;
using System.Collections.Generic;
using System.Linq;

namespace PoliticianCrusade
{
    public class BGMom : Character
    {
        public override char[,] GetImage()
        {
            return new char[,] { { ' ', '@', '@', ' ' }, { '(', ' ', ' ', ')' }, {'s', 'g', 'g', 'g'} };
        }
    }
}
