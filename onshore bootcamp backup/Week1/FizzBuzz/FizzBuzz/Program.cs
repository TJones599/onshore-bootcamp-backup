namespace FizzBuzz
{
    using System;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                int top = Console.CursorTop;

                if( i % 15 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if ( i % 5 == 0)
                {
                    Console.SetCursorPosition(2,top);
                    Console.WriteLine("Buzz");
                }
                else if ( i % 3 == 0)
                {                       
                    Console.SetCursorPosition(2,top);
                    Console.WriteLine("Fizz");
                }
                else
                {
                    Console.SetCursorPosition(3,top);
                    Console.WriteLine(i);
                }

                Thread.Sleep(300);
            }

            Console.ReadKey();
        }
    }
}
