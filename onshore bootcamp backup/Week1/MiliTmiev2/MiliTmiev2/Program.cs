namespace MilitaryClock
{
    using System;
    using System.Threading;
    using System.Media;


    class Program
    {
        /*static void writeMessage(int hour, int minute, int second)
        {
            Console.Clear();
            Console.Write(String.Format("{0:00}", hour) + ":");
            Console.Write(String.Format("{0:00}", minute) + ":");
            Console.Write(String.Format("{0:00}", second));
            Thread.Sleep(1000);
        }*/


        static void Main(string[] args)
        {
            SoundPlayer sp = new SoundPlayer();

            int changeColor = 1;
            // TimeSpan time = DateTime.Now.TimeOfDay;
            // int thour;
            // int tminute;
            // int tsecond;
            TimeSpan realTime = DateTime.Now.TimeOfDay;

            while (true)
            {
                for (int hour = realTime.Hours; hour < 24; hour++)
                {
                    for (int minute = realTime.Minutes; minute < 60; minute++)
                    {
                        for (int second = realTime.Seconds; second < 60; second++)
                        {

                            //time = DateTime.Now.TimeOfDay;
                            /*thour = time.Hours;
                            tminute = time.Minutes;
                            tsecond = time.Seconds;*/

                            switch (changeColor)
                            {
                                case 1:
                                    {
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Clear();

                                        //Console.WriteLine("\n{0} : {1} : {2}", time.Hours, time.Minutes, time.Seconds);

                                        Console.SetCursorPosition(2, 0);
                                        Console.Write(":");
                                        Console.SetCursorPosition(5, 0);
                                        Console.Write(":");
                                        Console.SetCursorPosition(0, 0);
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write(String.Format("{0:00}", hour));
                                        Console.SetCursorPosition(3, 0);
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write(String.Format("{0:00}", minute));
                                        Console.SetCursorPosition(6, 0);
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.Write(String.Format("{0:00}", second));
                                        Thread.Sleep(1000);
                                        changeColor = 2;
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Clear();

                                        // Console.WriteLine("\n{0} : {1} : {2}", time.Hours, time.Minutes, time.Seconds);

                                        Console.SetCursorPosition(2, 0);
                                        Console.Write(":");
                                        Console.SetCursorPosition(5, 0);
                                        Console.Write(":");
                                        Console.SetCursorPosition(0, 0);
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.Write(String.Format("{0:00}", hour));
                                        Console.SetCursorPosition(3, 0);
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write(String.Format("{0:00}", minute));
                                        Console.SetCursorPosition(6, 0);
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write(String.Format("{0:00}", second));
                                        Thread.Sleep(1000);
                                        changeColor = 3;
                                        break;
                                    }
                                case 3:
                                    {
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Clear();

                                        //Console.WriteLine("\n{0} : {1} : {2}", time.Hours, time.Minutes, time.Seconds);

                                        Console.SetCursorPosition(2, 0);
                                        Console.Write(":");
                                        Console.SetCursorPosition(5, 0);
                                        Console.Write(":");
                                        Console.SetCursorPosition(0, 0);
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write(String.Format("{0:00}", hour));
                                        Console.SetCursorPosition(3, 0);
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.Write(String.Format("{0:00}", minute));
                                        Console.SetCursorPosition(6, 0);
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write(String.Format("{0:00}", second));
                                        Thread.Sleep(1000);
                                        changeColor = 1;
                                        break;
                                    }
                            }
                        sp.SoundLocation = @"C:\Users\Tyler Jones\Downloads\smb3_bump.wav";
                        sp.Load();
                        sp.Play(); 
                        }
                    sp.SoundLocation = @"C:\Users\Tyler Jones\Downloads\smb3_fireball.wav";
                    sp.Load();
                    sp.Play();
                    }
                sp.SoundLocation = @"C:\Users\Tyler Jones\Downloads\smb3_stomp.wav";
                sp.Load();
                sp.Play();
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
