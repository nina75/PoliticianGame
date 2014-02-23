using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
