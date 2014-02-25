using System;

namespace PoliticianCrusade
{
    public abstract class StaticObject : GameObject
    {
        protected StaticObject(int x, int y) 
            : base(x, y)
        {
        }
        
        protected StaticObject()
        {
        }
    }
}
