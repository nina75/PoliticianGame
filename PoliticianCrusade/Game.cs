using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PoliticianCrusade
{
    [Version ("000.820")]
    
    public class Game
    {
        //static bool restartGame = false; // Още го размишлявам! Недейте да триете закоментираните редове! 
        public const int MaxHeight = 40;
        public const int MaxWidth = 100;

        //static char[,] playerField = new char[MaxHeight, MaxWidth]; //Dinko:
        
        static void Main()
        {
            Console.BufferHeight = Console.WindowHeight = MaxHeight;
            Console.BufferWidth = Console.WindowWidth = MaxWidth;

            Engine.Action();
        }
       
    }
}