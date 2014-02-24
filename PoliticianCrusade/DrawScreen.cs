using System;

namespace PoliticianCrusade
{
    public class DrawScreen 
    {
        public const int StartCol = 40;
        public const int Step = 12;

        public static void DrawConsoleBottom()
        {
            Console.SetCursorPosition(0, 32);
            Console.WriteLine(new string('-', 100));
            for (int i = StartCol; i < Console.WindowWidth ; i += Step)
            {
                DrawVerticalLine(i);
            }
            Console.SetCursorPosition(44, 33);
            Console.WriteLine("Money");

            Console.SetCursorPosition(56, 33);
            Console.WriteLine("Cane");

            Console.SetCursorPosition(69, 33);
            Console.WriteLine("Bag");

            Console.SetCursorPosition(78, 33);
            Console.WriteLine("Umbrella");

            Console.SetCursorPosition(92, 33);
            Console.WriteLine("Gun");
        }

        public static void DrawVerticalLine(int coordX)
        {
            for (int i = 33; i < 39; i++)
            {
                Console.SetCursorPosition(coordX, i);
                Console.WriteLine('|');
            }
        }
    }
}
