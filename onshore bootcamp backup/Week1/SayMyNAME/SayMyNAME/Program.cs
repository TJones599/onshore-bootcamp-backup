using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Threading;

namespace SayMyNAME
{
    class Program
    {
        static SoundPlayer sp = new SoundPlayer();

        private static void WriteAt(int left, int top, string message)
        {
            if (left >= Console.WindowWidth || top >= Console.WindowHeight)
                throw new ArgumentOutOfRangeException("left or top are too large");

            int oldLeft = Console.CursorLeft;
            int oldTop = Console.CursorTop;

            Console.SetCursorPosition(left, top);
            Console.Write(message);
            Console.SetCursorPosition(oldLeft, oldTop);
        }

        private static void WriteInColor(string message, ConsoleColor requestedColor, bool newLine = false)
        {
            ConsoleColor previousColor = Console.ForegroundColor;

            Console.ForegroundColor = requestedColor;
            Console.WriteLine(message + (newLine ? Environment.NewLine : ""));

            Console.ForegroundColor = previousColor;
        }

        private static void DrawScreen()
        {
            Console.Clear();
            WriteAt(currLeft, currTop, player.ToString());
        }

        private static int currLeft = 0;
        private static int currTop = 0;
        private static char player = '*';
        static void Main(string[] args)
        {
            //while (true)
            //{
            //    WriteAt(50, 0, Console.WindowHeight.ToString());
            //    WriteAt(50, 1, Console.WindowWidth.ToString());
            //}
            //while (true)
            //{
            //    if (Console.KeyAvailable)
            //    {
            //        ConsoleKeyInfo keyInfo = Console.ReadKey();
            //        switch (keyInfo.Key)
            //        {
            //            case ConsoleKey.W:
            //                currTop--;
            //                break;
            //            case ConsoleKey.S:
            //                currTop++;
            //                break;
            //            case ConsoleKey.A:
            //                currLeft--;
            //                break;
            //            case ConsoleKey.D:
            //                currLeft++;
            //                break;
                            
            //            //case ConsoleKey.NumPad0:
            //            //case ConsoleKey.D0:
            //            //    sp.SoundLocation = @"C:\Users\Tyler Jones\Downloads\smb3_1-up.wav";
            //            //    sp.Load();
            //            //    break;
            //            //case ConsoleKey.NumPad1:
            //            //case ConsoleKey.D1:
            //            //    sp.SoundLocation = @"C:\Users\Tyler Jones\Downloads\smb3_airship_moves.wav";
            //            //    sp.Load();
            //            //    break;
            //            //default:
            //            //    break;
            //        }
                    //to play audio .play is required.
                    //sp.play();
            //    }
            //    DrawScreen();
            //    Thread.Sleep(100);
            //}
            WriteAt(25, 1, "Health: ||||||||");
            WriteAt(25, 2, "Mana:||||||||");
            Console.ReadKey();
            String Creator = "Tyler";
            Console.WriteLine("Hello! What is your name? :)");
            String Name = Console.ReadLine();
            if (Name == Creator)
            {
                Console.Write(Name);
                Console.WriteLine("? That's a good name! :D");
                Console.ReadLine();
            }
            else
            {
                Console.Write(Name);
                Console.WriteLine(" huh? kinda lame...");
                Console.ReadLine();
                Console.Write(Creator);
                Console.WriteLine(" is coolor");
                Console.ReadLine();
                Console.WriteLine("Wait... why are you on his computer? O_O");
                Console.ReadLine();
                Console.WriteLine("TYLER COME HELP ME, I'VE BEEN STOLEN! D:");
                Console.ReadLine();
            }

        }
    }
}
