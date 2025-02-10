using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ERPReportApp
{
    public class DatabaseConnector
    {
        private readonly string connectionString;

        public DatabaseConnector()
        {
            // Load default config (app.config)
            connectionString = ConfigurationManager.ConnectionStrings["ERPDB"].ConnectionString;
        }

        /// <summary>
        /// Open a connection to SQL Server
        /// </summary>
        /// <returns>SqlConnection</returns>
        private SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="procedureName">Stored Procedure</param>
        /// <param name="parameters">params</param>
        /// <returns>Datatable</returns>
        public DataTable ExecuteStoredProcedure(string procedureName, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable resultTable = new DataTable();
                        adapter.Fill(resultTable);
                        return resultTable;
                    }
                }
            }
        }

        /// <summary>
         /// </summary>
        /// <param name="procedureName">Stored Procedure</param>
        /// <param name="parameters">params</param>
        /// <returns>number of rows</returns>
        public int ExecuteNonQuery(string procedureName, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
