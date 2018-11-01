namespace Pulling_Data_from_SQL
{
    using System;
    using System.Collections.Generic;
    //saving query results
    using System.Data;
    //must include data and data.sqlclient for sql interaction
    using System.Data.SqlClient;
    using System.IO;

    class Program
    {
        //connection string includes server name or url of external server
        //database name
        //trusted connection(true/false)
        private static readonly string connectionString = @"Server=ADMIN2-PC\SQLEXPRESS;Database=NORTHWIND;Trusted_Connection=True";

        private static DataSet ConnectToSQL()
        {
            DataSet queryResult = new DataSet();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                using (SqlCommand storedCommand = new SqlCommand("PULL_RELEVANT_SUPPLIER_INFO", sqlConnection))
                {
                    storedCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    storedCommand.CommandTimeout = 60;

                    sqlConnection.Open();

                    using (SqlDataAdapter commandAdapter = new SqlDataAdapter(storedCommand))
                    {
                        commandAdapter.Fill(queryResult);
                    }

                    sqlConnection.Close();
                }
            }
            catch (SqlException sqlEx)
            {
                sqlEx.Data["Logged"] = true;
                throw sqlEx;
            }
            return queryResult;
        }

        static void showSuppliers(DataSet suppliers)
        {
            int row = 1;
            int id = 0;
            foreach (DataTable dt in suppliers.Tables)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    
                    Console.WriteLine(row);

                    foreach (DataColumn dc in dt.Columns)
                    {
                        //if (id == 0)
                        //    id = 1;
                        //else
                            Console.WriteLine(dc.ColumnName + ": " + dr[dc]);
                    }
                    row++;
                    id = 0;

                    //dt.Select("CompanyName = New Orleans Cajun Delights");


                    Console.WriteLine("");
                }
            }

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            //Test();
            try
            {
                DataSet suppliers = ConnectToSQL();
                showSuppliers(suppliers);
            }
            catch (SqlException sqlEx)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(sqlEx.Message);
                Console.WriteLine();
                Console.WriteLine(sqlEx.StackTrace);
                Console.ResetColor();

                if (!(sqlEx.Data.Contains("Logged") && (bool)sqlEx.Data["Logged"] == true))
                {
                    Console.WriteLine("--------------hi---------------");
                }
            }
            catch (IOException ioEx)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Couldn't Access File");
                Console.ResetColor();
            }
            finally
            {
                Console.ReadKey();
            }



        }

        /*  private static void Test()
          {
              Item.MyStaticString = "THIS IS A STATIC STRING";
              Item item1 = new Item();
              item1.Name = "Ball";
              item1.Weight = 3;
              item1.Description = "Its a red ball";


              Item item2 = new Item();
              item2.Name = "Cup";
              item2.Weight = 3;
              item2.Description = "Red solo cup, I fill you up";

              Console.WriteLine(item1.Name);
              Console.WriteLine(item2.Name);

              Console.WriteLine(item1.GetStaticString());
              Console.WriteLine(item2.GetStaticString());



              Console.ReadKey();
          }
      }

      public class Item
      {
          private Item() { }

          private static List<Item> _ReferencePool = new List<Item>();

          private static Item _Instance;
          public static Item Instance
          {
              get
              {
                  Item retItem = new Item();
                  _ReferencePool.Add(retItem);
                  return retItem;
              }
          }

          public static void UpdateAll(Func<Item, bool> action)
          {
              foreach (Item item in _ReferencePool)
              {
                  action(item);
              }
          }

          public static string MyStaticString { get; set; }

          public string GetStaticString()
          {
              return MyStaticString;
          }

          public string Name { get; set; }

          public decimal Weight { get; set; }

          public string Description { get; set; }
      }*/
    }
}
