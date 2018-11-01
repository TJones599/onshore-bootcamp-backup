namespace Gocery_List
{
    using System;
    using System.IO;
    using System.Media;
    using System.Reflection;
    using System.Configuration;

    class Program
    {
        
        public static void TaDa()
        {
            SoundPlayer soundplayer = new SoundPlayer()
            {
                SoundLocation = soundPath
            };
            soundplayer.Load();
            soundplayer.Play();
        }
        public static decimal ObtainDecimalInput(string message)
        {
            string textInput = "";
            decimal number = 0;
            bool invalidInput = true;

            do
            {
                Console.Write(message);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                textInput = Console.ReadLine();
                invalidInput = decimal.TryParse(textInput, out number);
            } while (!invalidInput);

            return number;
        }
        public static bool EmptyFile(string filePath, bool emptyList)
        {
            StreamWriter clearList = new StreamWriter(filePath, false);
            clearList.WriteLine("We arrr disinclined to aquiesce to your request. Means no.");
            clearList.Close();
            clearList.Dispose();
            emptyList = true;
            return emptyList;
        }
        public static void ReadList(string filePath)
        {
            Console.Clear();
            TaDa();
            Console.WriteLine("Grocery List");
            StreamReader reader = new StreamReader(filePath, true);
            Console.WriteLine(reader.ReadToEnd());
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("<Press Enter To Go Back To The Main Page>");
            Console.ResetColor();
            Console.ReadKey();
            reader.Close();
            reader.Dispose();
        }

        public static bool ObtainItem(string filePath, bool emptyList)
        {
            //Gathering information.
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\nItem Name: ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            string name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nItem Amount: ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string quantity = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Red;
            decimal price = ObtainDecimalInput("\nItem Price: ");
            string[] groceryItem = { name, quantity, (Convert.ToString(price)) };

            //check statement to verify information.

            //Data access
            emptyList = AddItem(emptyList, filePath, groceryItem);
            Console.ResetColor();

            return emptyList;
        }
        public static bool AddItem(bool emptyList, string filePath, string[] groceryItem)
        {
            if (emptyList == true)
            {
                StreamWriter addNewItem = new StreamWriter(filePath, false);
                //addNewItem.WriteLine($"{name} {quantity} {price}");
                addNewItem.WriteLine("{0,-10} {1, -6} {2, -10:C}", groceryItem[0], groceryItem[1], Convert.ToDecimal(groceryItem[2]));
                addNewItem.Close();
                addNewItem.Dispose();
                emptyList = false;
            }
            else
            {
                StreamWriter addNewItem = new StreamWriter(filePath, true);
                //addNewItem.WriteLine($"{name} {quantity} {price}");
                addNewItem.WriteLine("{0,-10} {1, -6} {2, -10:C}", groceryItem[0], groceryItem[1], Convert.ToDecimal(groceryItem[2]));
                addNewItem.Close();
                addNewItem.Dispose();
            }
            return emptyList;
        }

        private static readonly string soundPath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Ta Da-SoundBible.com-1884170640.wav";

        static void Main(string[] args)
        {
            string programTitle = ConfigurationManager.AppSettings["appTitle"];
            Console.Title = programTitle;

            string connectionString = ConfigurationManager.ConnectionStrings["datasource"].ConnectionString;

            bool emptyList = false;
            bool continueOrExit = true;
            string filePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Grocery_List";
            do
            {

                Console.Clear();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("");
                Console.WriteLine("1.) Add items to your list");
                Console.WriteLine("2.) Read your list");
                Console.WriteLine("3.) Clear your list");
                Console.WriteLine("4.) Exit program");

                ConsoleKey readOrWrite = Console.ReadKey(true).Key;
                switch (readOrWrite)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        emptyList = ObtainItem(filePath, emptyList);
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        ReadList(filePath);
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        emptyList = EmptyFile(filePath, emptyList);
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        continueOrExit = false;
                        break;
                }
            } while (continueOrExit);
        }
    }
}
