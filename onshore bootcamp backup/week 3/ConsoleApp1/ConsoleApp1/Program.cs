using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        private static int ObtainIntInput()
        {
            int num;
            bool invalidEntry = true;

            int cTop = Console.CursorTop;
            int cLeft = Console.CursorLeft;

            do
            {
                invalidEntry = (!int.TryParse(Console.ReadLine(), out num));

                if (invalidEntry)
                {
                    Console.SetCursorPosition(cLeft, cTop);
                    Console.WriteLine("invalid Entry");
                }
            } while (invalidEntry);

            return num;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("enter a number\n" +
                "below this menu\n" +
                "at this point\n");
            int n = ObtainIntInput();
            Console.ReadKey();

        }
    }
}
