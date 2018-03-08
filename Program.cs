using System;
using System.Threading;

namespace RainbowWorm
{
    class MainClass
    {
        public const String DEFAULT_TEXT = "-++###########++-";
        public static ConsoleColor defaultColor = Console.ForegroundColor;

        public static void Main(string[] args)
        {
            string wormTxt = DEFAULT_TEXT;

            // Setup console
            Console.CursorVisible = false;
            Console.CancelKeyPress += new ConsoleCancelEventHandler(ExitHandler);
            
            // Setup string
            if (args.Length > 0) {
                // Use first arg as worm text if its set
                wormTxt = string.IsNullOrEmpty(args[0]) ? DEFAULT_TEXT : args[0];
            }

            // Colours to use
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

            // Draw worm
            //Source: https://codegolf.stackexchange.com/a/18733
            int index = 0;
            for (var i = 0d; ;) {
                if (index == colors.Length) { index = 0; }
                Console.ForegroundColor = colors[index];
                Console.Write("{0," + (int)(40 + 20 * Math.Sin(i += .1)) + "}\n", wormTxt);
                index++;
                Thread.Sleep(25);
            }
        }

        protected static void ExitHandler(object sender, ConsoleCancelEventArgs args)
        {
            // Restore console
            Console.CursorVisible = true;
            Console.ForegroundColor = defaultColor;
        }
    }
}
