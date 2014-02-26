using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PoliticianCrusade
{
    [Version ("000.830")]
    public class Game
    {
        //static bool restartGame = false; // Dinko: Още го размишлявам! Недейте да триете закоментираните редове!
        static string pathIntro = @"..\..\intro_screen.txt";
        public const int MaxHeight = 40;
        public const int MaxWidth = 100;

        //static char[,] playerField = new char[MaxHeight, MaxWidth]; //Dinko:
        
        static void Main()
        {
            Console.BufferHeight = Console.WindowHeight = MaxHeight;
            Console.BufferWidth = Console.WindowWidth = 70;
            
            DrawScreen.IntroPlayer(pathIntro);

            Console.ReadKey();
            Console.Clear();

            Console.BufferWidth = Console.WindowWidth = MaxWidth;

            Engine.Action();
        }
    }
}
