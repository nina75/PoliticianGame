using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticianCrusade
{
    public abstract class StaticObject : GameObject
    {
        protected StaticObject(int x, int y) : base(x, y)
        {
        }
        protected StaticObject()
        {

        }
       
    }
}
