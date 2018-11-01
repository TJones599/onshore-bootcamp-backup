namespace Daiblo3Equipmentset
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Threading;
    using System.IO;
    class Program
    {

        static string folderContents(string topFolder)
        {
            string fc = "";
            DirectoryInfo dInfo = new DirectoryInfo(topFolder);
            FileInfo[] Files = dInfo.GetFiles("*");
            foreach (FileInfo file in Files)
            {
                fc = (fc + "\n" + file.Name);
            }

            return fc;
        }

        static void newLoadout()
        {
            Console.Clear();
            string[] gearTitle = System.IO.File.ReadAllLines(@"C:\Users\Tyler Jones\source\repos\Daiblo3Equipmentset\Daiblo3Equipmentset\gearTitle.txt");
            string[] Gear = new string[16];

            Console.Write("Enter name of loadout: ");
            string loadoutName = Console.ReadLine();
            loadoutName = loadoutName + ".txt";

            string loadoutFolder = @"C:\Users\Tyler Jones\source\repos\Daiblo3Equipmentset\Daiblo3Equipmentset\Loadout";
    
            if (!System.IO.Directory.Exists(loadoutFolder))
                System.IO.Directory.CreateDirectory(loadoutFolder);
 
            string filePath = System.IO.Path.Combine(loadoutFolder, loadoutName);

            if (System.IO.File.Exists(filePath))
            {
                Console.WriteLine("Loadout already exists.");
                return;
            }
            else
            {
                Console.WriteLine("Enter names for the following pieces of gear.\n");
                for (int i = 0; i < 16; i++)
                {
                    Console.Write(gearTitle[i] + ": ");
                    Gear[i] = Console.ReadLine();
                }

                System.IO.File.WriteAllLines(filePath, Gear);
            }

            Console.Clear();
        }

        static void viewLoadout()
        {
            Console.Clear();
            string topFolder = @"C:\Users\Tyler Jones\source\repos\Daiblo3Equipmentset\Daiblo3Equipmentset\Loadout";

            Console.WriteLine("Which File would you like to view?"+ folderContents(topFolder));

            string loadout = (Console.ReadLine());
            string filePath = System.IO.Path.Combine(topFolder, loadout);

            if (!System.IO.File.Exists(filePath))
            {
                Console.Clear();
                Console.WriteLine("File Not Found!\n");
                return;
            }

            string[] gearInfo = System.IO.File.ReadAllLines(filePath);
            for (int i = 0; i < 16; i++)
            {
                Console.WriteLine(gearInfo[i]);
            }
        }

        static void removeLoadout()
        {
            Console.Clear();
            string sourcePath= @"C:\Users\Tyler Jones\source\repos\Daiblo3Equipmentset\Daiblo3Equipmentset\Loadout";
            string destPath= @"C:\Users\Tyler Jones\source\repos\Daiblo3Equipmentset\Daiblo3Equipmentset\Loadout\OldLoadout";
            string moveFile;
            
            Console.WriteLine("Which file would you like to remove:"+folderContents(sourcePath));
            moveFile = Console.ReadLine();

            string sourceFile = System.IO.Path.Combine(sourcePath, moveFile);
            string destFile = System.IO.Path.Combine(destPath, moveFile);
            
            if (!System.IO.Directory.Exists(destPath))
                System.IO.Directory.CreateDirectory(destPath);

            if (System.IO.File.Exists(sourceFile))
            {
                System.IO.File.Copy(sourceFile, destFile, true);
                System.IO.File.Delete(sourceFile);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("File Not Found!");
                return;
            }

            Console.Clear();
        }

        static void restorLoadout()
        {

            Console.Clear();
            string destPath = @"C:\Users\Tyler Jones\source\repos\Daiblo3Equipmentset\Daiblo3Equipmentset\Loadout";
            string sourcePath = @"C:\Users\Tyler Jones\source\repos\Daiblo3Equipmentset\Daiblo3Equipmentset\Loadout\OldLoadout";
            string moveFile;
         
            Console.WriteLine("Which file would you like to restore:" + folderContents(sourcePath));
            moveFile = Console.ReadLine();

            string sourceFile = System.IO.Path.Combine(sourcePath, moveFile);
            string destFile = System.IO.Path.Combine(destPath, moveFile);

            if (!System.IO.Directory.Exists(destPath))
                System.IO.Directory.CreateDirectory(destPath);

            if (System.IO.File.Exists(sourceFile))
            {
                System.IO.File.Copy(sourceFile, destFile, true);
                System.IO.File.Delete(sourceFile);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("File Not Found!");
                return;
            }

            Console.Clear();
        }

        /*static void callTime()
        {
            TimeSpan time = DateTime.Now.TimeOfDay;
            Console.WriteLine(time.Hours + ":" + time.Minutes + "\n");
        }*/

        static void Menu()
        {
            bool exit = false;
            bool invalidEntry = false;
            do
            {
                if (invalidEntry)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Option, please try again\n");
                    invalidEntry = false;
                }

              //  callTime();

                Console.WriteLine("Please choose one of the following or hit escape:\n"+
                    "1) Add new loadout\n"+
                    "2) View Loadouts\n"+
                    "3) Remove old loadout\n"+
                    "4) Restore deleted loadout\n"+
                    "5) Exit");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Escape:
                        {
                            Console.WriteLine("Esc pressed, exiting program...");
                            Thread.Sleep(750);
                            exit = true;
                            break;
                        }

                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        {
                            newLoadout();
                            break;
                        }
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        {
                            viewLoadout();
                            break;
                        }
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        {
                            removeLoadout();
                            break;
                        }
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        {
                            restorLoadout();
                            break;
                        }
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        {
                            Console.WriteLine("Exit selected, exiting program...");
                            Thread.Sleep(750);
                            exit = true;
                            break;
                        }
                    default:
                        {
                            invalidEntry = true;
                            break;
                        }
                }
            } while (!exit);

        }

        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 25);

            Menu();
        }
    }
}
