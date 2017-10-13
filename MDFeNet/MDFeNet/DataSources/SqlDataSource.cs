using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MDFeNet.DataSources
{
    public class SqlDataSource : MDFeDataSource
    {
        private SqlConnection Connection { get; set; }

        public SqlDataSource(DatasourceConfiguration configurationToTest = null)
        {
            if (configurationToTest != null)
            {
                SetupConnection(configurationToTest);

                if (Connection != null)
                    CloseConnection();
            }
        }

        public override void CloseConnection()
        {
            try
            {
                Connection.Close();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public override DataTable RetrieveDataFromSQL(string sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, Connection);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                DataTable dt = new DataTable();
                dt.Load(dr);

                return dt;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public override void SetupConnection(DatasourceConfiguration config)
        {
            try
            {
                SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
                sb.DataSource = config.Datasource;
                sb.UserID = config.UserId;
                sb.Password = config.Password;
                sb.InitialCatalog = config.InitialCatalog;

                SqlConnection conn = new SqlConnection(sb.ConnectionString);
                conn.Open();

                Connection = conn;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
