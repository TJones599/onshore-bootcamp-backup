namespace MilitaryClock
{
    using System;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            TimeSpan realTime = DateTime.Now.TimeOfDay;

            for (int hour = realTime.Hours; hour < 24; hour++)
            {
                for (int minute = realTime.Minutes; minute < 60; minute++)
                {
                    for (int second = realTime.Seconds; second < 60; second++)
                    {
                        Console.Clear();
                        Console.WriteLine(String.Format("{0:00}", hour) + ":" +
                                          String.Format("{0:00}", minute) + ":" +
                                          String.Format("{0:00}", second));
                        Thread.Sleep(1000);
                    }
                }
            }
            /*
            Console.ReadKey();

            for (int hour = 0; hour < 24; hour++)
            {
                for (int minute = 0; minute < 60; minute++)
                {
                    for (int second = 0; second < 60; second++)
                    {
                        Console.Clear();
                        Console.WriteLine(String.Format("{0:00}", hour) + ":" +
                                          String.Format("{0:00}", minute) + ":" +
                                          String.Format("{0:00}", second));
                        Thread.Sleep(1000);
                    }
                }
            }

            Console.ReadKey();
            */
        }
    }
}
