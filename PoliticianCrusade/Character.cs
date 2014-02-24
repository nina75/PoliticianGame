using System;

namespace PoliticianCrusade
{
    public abstract class Character : GameObject
    {
        protected Character(int x, int y) 
            : base(x, y)
        {
        }
        protected Character()
        {
        }

    }
}
