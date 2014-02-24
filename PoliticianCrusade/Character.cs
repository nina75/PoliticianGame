using System;

namespace PoliticianCrusade
{
    public abstract class Character : GameObject
    {
        public int Health { get; set; }
        public bool isAlive { get; set; }

        protected Character(int x, int y) 
            : base(x, y)
        {
            this.Health = 100;
            this.isAlive = true;
        }
        protected Character()
        {
            this.Health = 100;
            this.isAlive = true;
        }

    }
}
