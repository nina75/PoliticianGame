﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticianCrusade
{
    public abstract class GameObject : IRenderable
    {
        protected GameObject(int x, int y)
        {
            this.CoordX = x;
            this.CoordY = y;
        }
        protected GameObject()
        {
        }

        public int CoordX { get; set; }
        public int CoordY { get; set; }
              
        
        public virtual char[,] GetImage()
        {
            return new char[,] { { '*' } };
        }

        public void RenderImg()
        {
            Console.SetCursorPosition(this.CoordX, this.CoordY);
            for (int i = 0; i < this.GetImage().GetLength(0); i++)
            {
                for (int j = 0; j < this.GetImage().GetLength(1); j++)
                {
                    Console.Write(this.GetImage()[i, j]);
                }
                Console.SetCursorPosition(this.CoordX, this.CoordY + i + 1);
            }

        }

        public void ClearImg()
        {
            Console.SetCursorPosition(this.CoordX, this.CoordY);
            for (int i = 0; i < this.GetImage().GetLength(0); i++)
            {
                for (int j = 0; j < this.GetImage().GetLength(1); j++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(this.CoordX, this.CoordY + i + 1);
            }
        }
       
    }
}