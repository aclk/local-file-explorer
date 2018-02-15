using System;
using System.Threading;

namespace RainbowWorm
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            ConsoleColor[] colors = new ConsoleColor[] {
                ConsoleColor.Blue,
                ConsoleColor.Cyan,
                ConsoleColor.Gray,
                ConsoleColor.Green,
                ConsoleColor.Magenta,
                ConsoleColor.Red,
                ConsoleColor.White,
                ConsoleColor.Yellow
            };

            //Source: https://codegolf.stackexchange.com/a/18733
            int index = 0;
            for (var i = 0d; ;) {
                if (index == colors.Length) { index = 0; }
                Console.ForegroundColor = colors[index];
                Console.Write("{0," + (int)(40 + 20 * Math.Sin(i += .1)) + "}\n", "meow meow meow");
                index++;
                Thread.Sleep(25);//50);
            }
        }
    }
}
