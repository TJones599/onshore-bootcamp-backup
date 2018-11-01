

namespace NorthWNDSuppliersV2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading;
    using System.IO;
    using System.Reflection;
    using System.Configuration;
    using NorthWNDSuppliersV2.Models;

    class Program
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["dataSource"].ConnectionString;

        private static void ViewSuppliers(DataTable table)
        {
            foreach(DataRow row in table.Rows)
            {
                foreach(DataColumn column in table.Columns)
                {
                    Console.WriteLine("{0,-12}: {1}", column.ColumnName, row[column]);
                }
                Console.WriteLine();
            }
        }

        private static Supplier ObtainUpdatedInformation(Supplier supplierInfo)
        {
            int menuChoice = 0;
            bool exit = true;
            bool wrongNum = false;
            do
            {
                Console.WriteLine("What would you like to change?" +
                    "\n\t1)" + supplierInfo.CompanyName +
                    "\n\t2)" + supplierInfo.ContactName +
                    "\n\t3)" + supplierInfo.ContactTitle +
                    "\n\t4)" + supplierInfo.Address +
                    "\n\t5)" + supplierInfo.City +
                    "\n\t6)" + supplierInfo.Region +
                    "\n\t7)" + supplierInfo.PostalCode +
                    "\n\t8)" + supplierInfo.Country +
                    "\n\t9)" + supplierInfo.Phone +
                    "\n\t10)" + supplierInfo.Fax +
                    "\n\t11)" + supplierInfo.HomePage+
                    "\n\t12) Exit");

                if (wrongNum)
                {
                    Console.WriteLine("\nInput number 1-5:");
                    wrongNum = false;
                }
                menuChoice = GetIntInput("");

                switch(menuChoice)
                {
                    case 1:
                        Console.WriteLine("Company name was: {0}", supplierInfo.CompanyName);
                        supplierInfo.CompanyName = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Company Contact Name was: {0}", supplierInfo.ContactName);
                        supplierInfo.ContactName = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Company Contact Title was: {0}", supplierInfo.ContactTitle);
                        supplierInfo.ContactTitle = Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("Company Address was: {0}", supplierInfo.Address);
                        supplierInfo.Address = Console.ReadLine();
                        break;
                    case 5:
                        Console.WriteLine("City was: {0}", supplierInfo.City);
                        supplierInfo.City = Console.ReadLine();
                        break;
                    case 6:
                        Console.WriteLine("Company Region was: {0}", supplierInfo.Region);
                        supplierInfo.Region = Console.ReadLine();
                        break;
                    case 7:
                        Console.WriteLine("Company Postal Code was: {0}", supplierInfo.PostalCode);
                        supplierInfo.PostalCode = Console.ReadLine();
                        break;
                    case 8:
                        Console.WriteLine("Company Country Location was: {0}", supplierInfo.Country);
                        supplierInfo.Country = Console.ReadLine();
                        break;
                    case 9:
                        Console.WriteLine("Company Phone was: {0}", supplierInfo.Phone);
                        supplierInfo.Phone = Console.ReadLine();
                        break;
                    case 10:
                        Console.WriteLine("Company Fax was: {0}", supplierInfo.Fax);
                        supplierInfo.Fax = Console.ReadLine();
                        break;
                    case 11:
                        Console.WriteLine("Company Home Page was: {0}", supplierInfo.HomePage);
                        supplierInfo.HomePage = Console.ReadLine();
                        break;
                    case 12:
                        exit = true;
                        break;
                    default:
                        Console.Clear();
                        wrongNum = true;
                        break;
                }
                
                exit = true;
                menuChoice = GetIntInput("Would you like to change another property?" +
                    "1) Yes" +
                    "2) No");
                if (menuChoice == 1)
                    exit = false;

            } while (!exit);
            return supplierInfo;
        }

        private static Supplier ObtainNewSupplierInfo()
        {
            Supplier supplierInfo = new Supplier();

            Console.WriteLine("Creating New Supplier, please enter the following information.");
            Console.Write("Enter Company name: ");
            supplierInfo.CompanyName = Console.ReadLine();
         
            Console.Write("Enter Company Contact Name: ");
            supplierInfo.ContactName = Console.ReadLine();
         
            Console.Write("Enter Company Contact Title: ");
            supplierInfo.ContactTitle = Console.ReadLine();
         
            Console.Write("Enter Company Address: ");
            supplierInfo.Address = Console.ReadLine();
         
            Console.Write("Enter City: ");
            supplierInfo.City = Console.ReadLine();
         
            Console.Write("Enter Company Region: ");
            supplierInfo.Region = Console.ReadLine();
         
            Console.Write("Enter Company Postal Code: ");
            supplierInfo.PostalCode = Console.ReadLine();
         
            Console.Write("Enter Company Country Location: ");
            supplierInfo.Country = Console.ReadLine();
         
            Console.Write("Enter Company Phone: ");
            supplierInfo.Phone = Console.ReadLine();
         
            Console.Write("Enter Company Fax: ");
            supplierInfo.Fax = Console.ReadLine();
         
            Console.Write("Enter Company Home Page: ");
            supplierInfo.HomePage = Console.ReadLine();
         
            return supplierInfo;
        }

        private static Supplier ConvertTableToSupplier(DataTable supplierTable)
        {
            return new Supplier()
            {
                CompanyName = supplierTable.Rows[0]["CompanyName"].ToString(),
                ContactName = supplierTable.Rows[0]["ContactName"].ToString(),
                ContactTitle = supplierTable.Rows[0]["ContactTitle"].ToString(),
                Address = supplierTable.Rows[0]["Address"].ToString(),
                City = supplierTable.Rows[0]["City"].ToString(),
                Region = supplierTable.Rows[0]["Region"].ToString(),
                PostalCode = supplierTable.Rows[0]["PostalCode"].ToString(),
                Country = supplierTable.Rows[0]["Country"].ToString(),
                Phone = supplierTable.Rows[0]["Phone"].ToString(),
                Fax = supplierTable.Rows[0]["Fax"].ToString(),
                HomePage = supplierTable.Rows[0]["HomePage"].ToString(),
            };
        }

        private static int GetIntInput(string message)
        {
            int input = 0;
            bool valid = true;

            do
            {
                Console.WriteLine(message);
                valid = int.TryParse(Console.ReadLine(), out input);
            } while (!valid);

            return input;
        }

        static void Main(string[] args)
        {
            try
            {
                Console.BufferHeight = 500;

                SupplierDAO supDao = new SupplierDAO(connectionString);

                bool wrongNum = false;
                bool exit = false;
                DataTable supplierTable = new DataTable();
                Supplier supplierInfo = new Supplier();
                int ID=0;

                do
                {
                    Console.WriteLine("We are in the Supplier table of NORTHWIND. \nWould you like to: \n\t" +
                        "1) View all suppliers.\n\t" +
                        "2) Update an existing supplier information.\n\t" +
                        "3) Create a new supplier.\n\t" +
                        "4) Delete a supplier.\n\t" +
                        "5) Exit this program.");

                    //Ask to put 1-5, if not.
                    if (wrongNum)
                    {
                        Console.WriteLine("\nInput number 1-5:");
                        wrongNum = false;
                    }

                    int menuChoice = GetIntInput("Please enter a number between 1 and 5");
                    switch (menuChoice)
                    {
                        case 1:
                            //view all suppliers
                            supplierTable = supDao.ObtainTableInfo();
                            ViewSuppliers(supplierTable);
                            break;
                        case 2:
                            //Update supplier
                            ID = GetIntInput("Input supplier ID");
                            supplierTable = supDao.ObtainSupplierSingle(ID);
                            ViewSuppliers(supplierTable);
                            supplierInfo = ConvertTableToSupplier(supplierTable);
                            supplierInfo = ObtainUpdatedInformation(supplierInfo);
                            supDao.UpdateInformation(supplierInfo, ID);
                            break;
                        case 3:
                            //Create New Supplier
                            supplierInfo = ObtainNewSupplierInfo();
                            supDao.CreateNewSupplier(supplierInfo);
                            break;
                        case 4:
                            //Delete Supplier
                            ID = GetIntInput("Input supplier ID");
                            supDao.DeleteSupplier(ID);
                            break;
                        case 5:
                            exit = true;
                            break;
                        default:
                            Console.Clear();
                            wrongNum = true;
                            break;
                    }
                } while (exit == false);
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("SQL failure");
                Console.ReadKey();
            }
            finally
            {

            }
        }
    }
}
