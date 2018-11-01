using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingApp
{
    class player
    {     
        //to be continued

        public string name;
        public static int total=0;
        public static int[] frame=new int[10];

        public void NewPlayer ()
        {
            Console.WriteLine("Enter Name");
            name = Console.ReadLine();

        }

        public string getName()
        {
            return name;
        }
        public void setFrame(int frameTotal, int score)
        {
            frame[frameTotal] = score;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            player p1 = new player();

            
        }
    }
}
