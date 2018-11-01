namespace FizzBuzz
{
    using System;
    using System.Threading;
    using System.Media;

    class Program
    {
        static void Main(string[] args)
        {
            SoundPlayer sp = new SoundPlayer();
            for (int i = 1; i <= 100; i++)
            {
                int top = Console.CursorTop;

                if (i % 15 == 0)
                {
                    sp.SoundLocation = @"C:\Users\Tyler Jones\Downloads\smb3_1-up.wav";
                    sp.Load();
                    sp.Play();
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 5 == 0)
                {
                    sp.SoundLocation = @"C:\Users\Tyler Jones\Downloads\smb3_airship_moves.wav";
                    sp.Load();
                    sp.Play();
                    Console.SetCursorPosition(2, top);
                    Console.WriteLine("Buzz");
                }
                else if (i % 3 == 0)
                {
                    sp.SoundLocation = @"C:\Users\Tyler Jones\Downloads\smb3_coin.wav";
                    sp.Load();
                    sp.Play();
                    Console.SetCursorPosition(2, top);
                    Console.WriteLine("Fizz");
                }
                else
                {
                    Console.SetCursorPosition(3, top);
                    Console.WriteLine(i);
                }

                Thread.Sleep(300);
            }

            Console.ReadKey();
        }
    }
}
