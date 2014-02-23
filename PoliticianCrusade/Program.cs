using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticianCrusade
{
    public class Program
    {
        public const int MaxHeight = 40;
        public const int MaxWidth = 100;
        static void Main(string[] args)
        {
            Console.BufferHeight = Console.WindowHeight = MaxHeight;
            Console.BufferWidth = Console.WindowWidth = MaxWidth;

            var baba = new GrandMom(8,8);
            var parliament = new Parliament(40, 2);
            var garden1 = new Garden(5, 2);
            var garden2 = new Garden(73, 2);
            var policeman1 = new Policeman(76, 4);
            var policeman2 = new Policeman(8, 4);
            var politician1 = new Politician(0, 20);

            Console.ForegroundColor = ConsoleColor.Red;
            baba.RenderImg();

            Console.ForegroundColor = ConsoleColor.Gray;
            parliament.RenderImg();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            garden1.RenderImg();
            garden2.RenderImg();

            Console.ForegroundColor = ConsoleColor.Yellow;

            policeman1.RenderImg();
            policeman2.RenderImg();
            politician1.RenderImg();

            //policeman.Move();
            while (true)
            {
                baba.Move();
                policeman1.Move(76, 4);
                policeman2.Move(8, 4);
                politician1.Move(0,20);
            }

           


        }
    }
}
