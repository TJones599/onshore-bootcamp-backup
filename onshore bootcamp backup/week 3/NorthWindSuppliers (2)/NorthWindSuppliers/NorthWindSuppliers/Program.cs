
namespace NorthWindSuppliers
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Reflection;

    class Program
    {
        private static readonly string filePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        private static void ViewSpecifiedSupplier(int supplierID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dataSource"].ConnectionString;

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                using (SqlCommand viewRowByID = new SqlCommand("VIEW_ROW_BY_ID", sqlConnection))
                {
                    viewRowByID.CommandType = System.Data.CommandType.StoredProcedure;
                    viewRowByID.CommandTimeout = 90;

                    viewRowByID.Parameters.AddWithValue("SupplierID", supplierID);

                    sqlConnection.Open();
                    //change to adapter and return to main
                    //pass table into a read method to output table results
                    using (SqlDataReader reader = viewRowByID.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.WriteLine(reader.GetValue(i));
                            }
                            Console.WriteLine();
                        }
                    }

                    sqlConnection.Close();
                }
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
        }

        private static void DeleteSuppliers()
        {
            //ToDo: display using view all suppliers, obtain SupplierID and pass it to the delete method
            string connectionString = ConfigurationManager.ConnectionStrings["dataSource"].ConnectionString;

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                using (SqlCommand deleteSupplier = new SqlCommand("DELETE_SUPPLIER", sqlConnection))
                {
                    deleteSupplier.CommandType = System.Data.CommandType.StoredProcedure;
                    deleteSupplier.CommandTimeout = 90;

                    Console.WriteLine("Which supplier would you like to delete?");

                    string supplierID = Console.ReadLine();

                    deleteSupplier.Parameters.AddWithValue("SupplierID", supplierID);

                    sqlConnection.Open();
                    deleteSupplier.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
        }

        private static void UpdateSuppliers()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dataSource"].ConnectionString;
            string[] columnNames = File.ReadAllLines(filePath + @"\ColumnsInSuppliers.txt");

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                using (SqlCommand updateSupplier = new SqlCommand("UPDATE_SUPPLIER_INFO", sqlConnection))
                {
                    updateSupplier.CommandType = System.Data.CommandType.StoredProcedure;
                    updateSupplier.CommandTimeout = 90;

                    Console.WriteLine("Enter supplierID you wish to update:");
                    int supplierID;
                    updateSupplier.Parameters.Add("supplierID", SqlDbType.Int);
                    supplierID = GetIntInput();
                    updateSupplier.Parameters["SupplierID"].Value = supplierID;

                    ViewSpecifiedSupplier(supplierID);
                    //ToDo: Gather information in a different method and pass that information into the update method.
                    foreach (string name in columnNames)
                    {
                        if (name != "SupplierID")
                        {
                            Console.WriteLine("Please enter " + Convert.ToString(name) + ": ");

                            if (name == "HomePage")
                            {
                                updateSupplier.Parameters.Add(name, SqlDbType.NText);
                            }
                            else
                            {
                                updateSupplier.Parameters.Add(name, SqlDbType.NVarChar);
                            }

                            updateSupplier.Parameters[name].Value = Console.ReadLine();
                        }
                    }

                    sqlConnection.Open();
                    updateSupplier.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
        }

        private static void CreateSuppliers()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dataSource"].ConnectionString;
            string[] ColumnNames = File.ReadAllLines(filePath + @"\ColumnsInSuppliers.txt");

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand updateSupplier = new SqlCommand("CREATE_SUPPLIER", sqlConnection))
                    {
                        updateSupplier.CommandType = System.Data.CommandType.StoredProcedure;
                        updateSupplier.CommandTimeout = 90;

                        //ToDo: Gather information in a different method and pass that data to the creation method
                        foreach (string name in ColumnNames)
                        {
                            if (name != "SupplierID")
                            {
                                Console.WriteLine("Please enter " + Convert.ToString(name) + ": ");

                                if (name == "HomePage")
                                {
                                    updateSupplier.Parameters.Add(name, SqlDbType.NText);
                                }
                                else
                                {
                                    updateSupplier.Parameters.Add(name, SqlDbType.NVarChar);
                                }

                                updateSupplier.Parameters[name].Value = Console.ReadLine();
                            }
                        }

                        sqlConnection.Open();
                        updateSupplier.ExecuteNonQuery();

                        sqlConnection.Close();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
        }

        private static void ViewSuppliers()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dataSource"].ConnectionString;

            string[] columnNames = File.ReadAllLines(filePath + @"\ColumnsInSuppliers.txt");

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                using (SqlCommand viewSupplierTable = new SqlCommand("VIEW_SUPPLIER_TABLE", sqlConnection))
                {
                    viewSupplierTable.CommandType = System.Data.CommandType.StoredProcedure;
                    viewSupplierTable.CommandTimeout = 90;

                    sqlConnection.Open();
                    //ToDo: change to adapter and move to a new method.
                    using (SqlDataReader reader = viewSupplierTable.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                if (i == 0)
                                    Console.ForegroundColor = ConsoleColor.Green;
                                else
                                    Console.ResetColor();

                                Console.WriteLine("{0,-12}: {1}", columnNames[i], reader.GetValue(i));
                            }
                            Console.WriteLine();
                        }
                    }

                    sqlConnection.Close();
                    //ToDo:Return table to main
                }
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }

            //foreach (DataRow row in supplierTable.Rows)
            //{
            //    foreach (DataColumn column in supplierTable.Columns)
            //    {
            //        Console.WriteLine(column.ColumnName + ": " + row[column]);
            //    }
            //    Console.WriteLine();
            //}
        }

        private static int GetIntInput()
        {
            int num;
            bool invalidEntry = true;

            int cTop = Console.CursorTop;
            int cLeft = Console.CursorLeft;

            do
            {
                invalidEntry = (!int.TryParse(Console.ReadLine(), out num));

                if (invalidEntry)
                {
                    Console.SetCursorPosition(cLeft, cTop);
                    Console.WriteLine("Invalid Entry. Input Number:");
                }
            } while (invalidEntry);

            return num;
        }

        //private static void DisplayAllSuppliers(DataTable allSuppliers)
        //{
        //    if (allSuppliers == null)
        //        throw new ArgumentNullException("AllSuppliers cannot be null if displaying");


        //    foreach (DataRow row in allSuppliers.Rows)
        //    {
        //        foreach (DataColumn column in allSuppliers.Columns)
        //        {
        //            Console.WriteLine($"{ column.ColumnName }: { row[column] }");
        //        }
        //    }
        //}

        //private static DataTable ObtainAllSuppliers()
        //{
        //    DataTable response = new DataTable();

        //    string connectionString = ConfigurationManager.ConnectionStrings["dataSource"].ConnectionString;
        //    try
        //    {
        //        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        //        using (SqlCommand viewRowByID = new SqlCommand("VIEW_SUPPLIER_TABLE", sqlConnection))
        //        {
        //            viewRowByID.CommandType = System.Data.CommandType.StoredProcedure;
        //            viewRowByID.CommandTimeout = 90;

        //            sqlConnection.Open();

        //            using (SqlDataAdapter adapter = new SqlDataAdapter(viewRowByID))
        //            {
        //                adapter.Fill(response);
        //            }

        //            sqlConnection.Close();
        //        }
        //    }
        //    catch (SqlException sqlEx)
        //    {
        //        throw sqlEx;
        //    }

        //    return response;
        //}


        static void Main(string[] args)
        {
            //DataTable table = ObtainAllSuppliers();
            //DisplayAllSuppliers(table);
            try
            {
                Console.BufferHeight = 500;
                bool wrongNum = false;
                bool exit = false;

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

                    int menuChoice = GetIntInput();
                    switch (menuChoice)
                    {
                        case 1:
                            ViewSuppliers();
                            Console.WriteLine("Press any key to return.");
                            Console.ReadKey();
                            break;
                        case 2:
                            UpdateSuppliers();
                            break;
                        case 3:
                            CreateSuppliers();
                            break;
                        case 4:
                            DeleteSuppliers();
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
