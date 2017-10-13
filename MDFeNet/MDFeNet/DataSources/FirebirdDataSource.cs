using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MDFeNet.DataSources
{
    [Serializable]
    public class FirebirdDataSource : MDFeDataSource
    {
        private FbConnection Connection { get; set; }

        public FirebirdDataSource(DatasourceConfiguration configurationToTest = null)
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
                Connection = null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override void SetupConnection(DatasourceConfiguration config)
        {
            try
            {
                FbConnectionStringBuilder sb = new FbConnectionStringBuilder();
                sb.DataSource = config.Datasource;
                if (config.Port > 0)
                    sb.Port = config.Port;
                sb.Database = config.InitialCatalog;
                sb.UserID = config.UserId;
                sb.Password = config.Password;

                FbConnection conn = new FbConnection(sb.ConnectionString);
                conn.Open();

                Connection = conn;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override DataTable RetrieveDataFromSQL(string sql)
        {
            try
            {
                FbCommand cmd = new FbCommand(sql, Connection);
                FbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                DataTable dt = new DataTable();
                dt.Load(reader);

                return dt;
            }
            catch
            {
                return null;
            }
        }
    }
}
