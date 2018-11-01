using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Age_Verifier
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter User Age (ex: 21)");
            String ageText = Console.ReadLine();
            int Age = Int32.Parse(ageText);
            if (Age > 21)
            {
                Console.WriteLine("Can buy alcohol");
            }
            if (Age > 18)
            {
                Console.WriteLine("Can buy cigarettes");
            }
            else
            {
                Console.WriteLine("Watch movies");
            }

            WaitForKeyPress();
        }
        private static void WaitForKeyPress()
        {
            Console.WriteLine("Waiting for Any Key To Exit: ");
            Console.ReadKey();
        }
    }
}
