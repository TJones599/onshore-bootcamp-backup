using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatingFilePathsAndTxtFile
{
    class Program
    {
        static void Main(string[] args)
        {
            //starting file path
            string topFolderPath = @"C:\Users\Tyler Jones\source\repos\CreatingFilePathsAndTxtFile\CreatingFilePathsAndTxtFile\bin\Debug";
            //new folder
            string newFolder = "NewTestFolder";

            //adds new folder file path to initial file path
            string filePath = System.IO.Path.Combine(topFolderPath, newFolder);

            //creates new folder occording to filePath
            System.IO.Directory.CreateDirectory(filePath);

            //any indicated filename or file name of your choosing
            string fileName = "testFileName";

            //includes new file to filepath
            filePath = System.IO.Path.Combine(filePath, fileName+".txt");

            Console.WriteLine("\nCurrent File Path: " + filePath);

            string[] stringText = { "a", "b", "c", "d", "e" };

            if (System.IO.File.Exists(filePath))
            {
                // using (System.IO.FileStream fs = System.IO.File.Create(filePath))
                // {
                int i = 0;
                System.IO.File.WriteAllLines(filePath, stringText);

                //}
            }

            /* if (System.IO.File.Exists(filePath))
             {
                // using (System.IO.FileStream fs = System.IO.File.Create(filePath))
                // {
                     int i = 0;
                     System.IO.File.WriteAllText(filePath, stringText[i]);

                 //}
             }*/

            /*
            {
                for (byte i = 0; i < 100; i++)
                {
                    fs.WriteByte(i);
                }
            }

            try
            {
                byte[] readBuffer = System.IO.File.ReadAllBytes(filePath);
                foreach (byte b in readBuffer)
                {
                    Console.Write(b + " ");
                }
                Console.WriteLine();
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
            }
            }
            */

            Console.ReadKey();

        }
    }
}
