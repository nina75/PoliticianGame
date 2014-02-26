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
        static bool restartGame = false; // Dinko: Още го размишлявам! Недейте да триете закоментираните редове!
        static string pathIntro = @"..\..\intro_screen.txt";
        public const int MaxHeight = 40;
        public const int MaxWidth = 100;

        //static char[,] playerField = new char[MaxHeight, MaxWidth]; //Dinko:
        
        static void Main()
        {
            //IntroPlayer(pathIntro);

            Console.BufferHeight = Console.WindowHeight = MaxHeight;
            Console.BufferWidth = Console.WindowWidth = MaxWidth;

            Engine.Action();
        }

        #region IntroPlayer
        public static void IntroPlayer(string stringWitPath)
        {
            //console init
            Console.BufferHeight = Console.WindowHeight = 40;
            Console.BufferWidth = Console.WindowWidth = 80;
            Console.OutputEncoding = Encoding.Unicode;

            using (StreamReader stream = new StreamReader(stringWitPath))
            {
                while (!stream.EndOfStream)
                {
                    Console.WriteLine(stream.ReadLine());
                    Thread.Sleep(30);
                }
            }
       
            Console.ReadKey();
            Console.Clear();
        } 
        #endregion
    }
}
