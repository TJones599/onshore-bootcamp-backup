namespace Pulling_Data_from_SQL
{
    using System;
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
        private static readonly string connectionString = @"Server=ADMIN2-PC\SQLEXPRESS;Database=NORTHWND;Trusted_Connection=True";

        static DataSet ConnectToSQL()
        {
            //records single table result
            //DataTable queryResult = new DataTable();

            //records multiple table results

            DataSet queryResult = new DataSet();
            try
            {
                //create sql connection id:connectToServer2            v-- connection string
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                using (SqlCommand storedCommand = new SqlCommand("PULL_RELEVANT_SUPPLIER_INFO", sqlConnection))
                {

                    storedCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    //times out in 60 seconds
                    storedCommand.CommandTimeout = 60;

                    //if you need parameters include V     ie. "firstName", "John"
                    //storedCommand.Parameters.AddWithValue("param1", "Value1");
                    //opens connection
                    sqlConnection.Open();

                    using (SqlDataAdapter commandAdapter = new SqlDataAdapter(storedCommand))
                    {
                        commandAdapter.Fill(queryResult);
                    }

                    //only used for executing commands. does not return information
                    //storedCommand.ExecuteNonQuery();

                    //closes and disposes connection much like filewriter?
                    sqlConnection.Close();
                }

            }
            catch (SqlException sqlEx )
            {
                //log
                sqlEx.Data["Logged"] = true;
                throw sqlEx;
            }
            return queryResult;
        }

        static void showSuppliers(DataSet suppliers)
        {
                string supplierColumns="";
            bool headers = false;
            foreach (DataTable dt in suppliers.Tables)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    foreach (DataColumn dc in dt.Columns)
                    {
                    Console.WriteLine(dc.ColumnName + ": " + dr[dc]);
                        if (!headers)
                             supplierColumns += (Convert.ToString(dc.ColumnName)+"\n");
                    }
                    headers = true;
                    Console.WriteLine("");
                }
            }
                Console.WriteLine(supplierColumns);

            

        }

        static void Main(string[] args)
        {
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

                if (!(sqlEx.Data.Contains("Logged")&&(bool)sqlEx.Data["Logged"] == true))
                {
                    //do stuff
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
    }
}
