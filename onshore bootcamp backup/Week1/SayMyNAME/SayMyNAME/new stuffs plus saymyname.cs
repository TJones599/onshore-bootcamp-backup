using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//System.Media library used to play sound (only .wav files? not sure on this yet)
using System.Media;
//System.Threading used to manipulate the threads running the program. ie. causing a delay
using System.Threading;

namespace SayMyNAME
{
    class Program
    {
        //creates an instance of the SoundPlayer class with the identifier "sp".
        static SoundPlayer sp = new SoundPlayer();

        //Function to write the given string "message" at position (left,top) and reset the cursor position to
        //its starting location at this function call.
        //(example: left = 10, top = 5, message = "Hello World"
        //10 charactor spaces to the right and 5 lines down, Hello World will be displayed and the cursor will be reset to its original position.

        private static void WriteAt(int left, int top, string message)
        {
            //checks for console size and providing and error code if cursor position is outside of the console
            if (left >= Console.WindowWidth || top >= Console.WindowHeight)
                throw new ArgumentOutOfRangeException("left or top are too large");
            //saving startingh cursor position
            int oldLeft = Console.CursorLeft;
            int oldTop = Console.CursorTop;
            //setting cursor to target position,outputing the message given, and resetting the cursor to starting position
            Console.SetCursorPosition(left, top);
            Console.Write(message);
            Console.SetCursorPosition(oldLeft, oldTop);
        }

        //Functionc called to write the given text "message" in the given console color "requestedColor"
        //Not sure how the boolean variable "newLine" used to stop or create a new line yet.b

        private static void WriteInColor(string message, ConsoleColor requestedColor, bool newLine = false)
        {
            //capturing starting color
            ConsoleColor previousColor = Console.ForegroundColor;
            //changing console to requested color, and displaying text given in the new color
            Console.ForegroundColor = requestedColor;
            Console.WriteLine(message + (newLine ? Environment.NewLine : ""));
            //resetting color to starting color
            Console.ForegroundColor = previousColor;
        }

        //Function to move the player model around the screen

        //private static void DrawScreen()
        //{
        //    Console.Clear();
        //    WriteAt(currLeft, currTop, player.ToString());
        //}


        //posistion and player model variables
        //private static int currLeft = 0;
        //private static int currTop = 0;
        //private static char player = '*';
        static void Main(string[] args)
        {
            //Writing out screen dimentions at left position 50 and top position 0 and 1
            //
            //while (true)
            //{
            //    WriteAt(50, 0, Console.WindowHeight.ToString());
            //    WriteAt(50, 1, Console.WindowWidth.ToString());
            //}

            //moving game cursor by reading "W, A, S, D" inputs as movement
            //can also be used to execute actions base on what was pressed ie. press e to open inventory menu

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

            //Play sound based on key press. In this case NumPad0 plays smb3_1-up.wav
            //or 
                            
                        //case ConsoleKey.NumPad0:
                        //case ConsoleKey.D0:
                        //    sp.SoundLocation = @"C:\Users\Tyler Jones\Downloads\smb3_1-up.wav";
                        //    sp.Load();
                        //    break;
                        //case ConsoleKey.NumPad1:
                        //case ConsoleKey.D1:
                        //    sp.SoundLocation = @"C:\Users\Tyler Jones\Downloads\smb3_airship_moves.wav";
                        //    sp.Load();
                        //    break;
                        //default:
                        //    break;
            //        }

            //    }

            //calls DrawScreen function which moves the player cursor.
            //    DrawScreen();
            //
            //This is causing a 100 microsecond delay between excepted inputs, although this creates a buffer.
            //    Thread.Sleep(100);
            //}

            //calls WriteAt function to position cursor to Left 62 and Top 1 to display the message "Health: ||||||||"
            //WriteAt(62, 1, "Health: ||||||||");
            //WriteAt(65, 2, "Mana:||||||||");
            //Console.ReadKey();

            //this is my SayMyName program pre-Andrewfication lol
            String Creator = "Tyler";
            Console.WriteLine("Hello! What is your name? :)");
            String Name = Console.ReadLine();
            if (Name == Creator)
            {
                Console.Clear();
                Console.Write(Name);
                
                Console.WriteLine("? That's a good name! :D");
                Console.ReadKey();
            }
            else
            {
                Console.Write(Name);
                Console.WriteLine(" huh? kinda lame...");
                Console.ReadKey(true);
                Console.Write(Creator);
                Console.WriteLine(" is coolor");
                Console.ReadKey(true);
                Console.WriteLine("Wait... why are you on his computer? O_O");
                Console.ReadKey(true);
                Console.WriteLine("TYLER COME HELP ME, I'VE BEEN STOLEN! D:");
                Console.ReadKey(true);
                Console.WriteLine("THAT'S IT! I'M OUT OF HERE! D:");
                Console.ReadKey(true);
            }

            //handy Shortcuts

            //type many lines of the same code at once with shift+alt+click & Drag
            //comment many lines at once by highlighting the section and using ctrl+K+C
            //uncomment by ctrl+K+U

            //many things to type at once
            //many things to type at once
            //many things to type at once
            //many things to type at once
            //many things to type at once
        }
    }
}
