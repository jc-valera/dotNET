using Jcvalera.Core.Common.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jcvalera.Core.DAL
{
    public class SalesDAL
    {
        private SqlConnection Connection;

        public SalesDAL()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

            Connection = new SqlConnection(connectionString);
        }

        public async Task<List<SalesCustomer>> GetSalesCustomer()
        {
            var salesCustomer = new List<SalesCustomer>();

            Connection.Open();

            using (var cmd = new SqlCommand("sp_GetSalesCustomer", Connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        var sales = new SalesCustomer
                        {
                            BusinessEntityID = Convert.ToInt32(reader["BusinessEntityID"]),
                            FirstName = reader["FirstName"].ToString(),
                            MiddleName = reader["MiddleName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            SalesLastYear = Convert.ToDecimal(reader["SalesLastYear"])
                        };
                        
                        salesCustomer.Add(sales);
                    }
                }
            }

            Connection.Close();

            return salesCustomer;
        }
    }
}
