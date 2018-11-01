using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using NorthWNDSuppliersV2.Models;

namespace NorthWNDSuppliersV2
{
   public class SupplierDAO
    {
        public readonly string connectionString;

        public SupplierDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DataTable ObtainTableInfo()
        {
            DataTable table = null;
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                using (SqlCommand sqlCom = new SqlCommand("VIEW_SUPPLIER_TABLE", sqlCon))
                {
                    sqlCom.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCom.CommandTimeout = 90;

                    sqlCon.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCom))
                    {
                        adapter.Fill(table);
                    }
                    sqlCon.Close();

                }

                return table;
            }
            catch(SqlException sqlEx)
            {
                throw sqlEx;
            }
        }

        public DataTable ObtainSupplierSingle(int ID)
        {
            DataTable table = null;

            return table;
        }

        public void CreateNewSupplier(Supplier supplierInfo)
        {

        }

        public void UpdateInformation(Supplier information, int ID)
        {

        }

        public void DeleteSupplier(int ID)
        {

        }
    }
}
