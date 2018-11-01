using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace list_testing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listTest = new List<string>();
            string[] arr = new string[] { "test", "test2", "test3", "test4" };

            for(int i = 0; i < arr.Length; i++)
            {
                listTest.Add(arr[i]);
            }

            for(int i = 0; i < listTest.Capacity;i++)
            {
                Console.WriteLine(listTest[i]);
            }
            Console.ReadKey();
        }
    }
}
