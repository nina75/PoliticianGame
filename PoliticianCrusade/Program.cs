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
            DrawScreen.DrawConsoleBottom();

            var baba = new GrandMom(48, 23);
            var parliament = new Parliament(40, 2);
            var garden1 = new Garden(5, 2);
            var garden2 = new Garden(73, 2);
            var policeman1 = new Policeman(76, 4);
            var policeman2 = new Policeman(8, 4);
            var politician1 = new Politician(0, 12);
            var politician2 = new Politician(97, 15);
            var politician3 = new Politician(0, 18);
            var money = new Money(45, 35);
            var cane = new Cane(57, 34);
            var bag = new Bag(68, 35);
            var umbrella = new Umbrella(81, 34);

            var objects = new List<GameObject>() { baba, parliament, garden1, garden2, policeman1, policeman2, politician1, politician2, politician3, money, cane, bag, umbrella};

            foreach (var obj in objects)
            {
                obj.RenderImg();
            }

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                baba.Move();
                Console.ForegroundColor = ConsoleColor.Yellow;
                policeman1.Move(76, 4);
                policeman2.Move(8, 4);
                politician1.Move(0, 12);
                politician2.MoveBack(97, 15);
                politician3.Move(0, 18);

            }

           


        }
    }
}
