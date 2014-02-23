using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticianCrusade
{
    public abstract class Character : GameObject
    {
        protected Character(int x, int y) : base(x, y)
        {
        }
        protected Character()
        {
        }

    }
}
