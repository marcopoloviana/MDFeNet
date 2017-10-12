using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDFeNet.DataSources
{
    [Serializable]
    public class DatasourceConfiguration
    {
        public enum Provider
        {
            MS_SQL = 0,
            Firebird = 1,
            MySQL = 2,
            PgSQL = 3
        }

        public Provider DataProvider { get; set; }
        public string Datasource { get; set; }
        public string InitialCatalog { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public int Port { get; internal set; }

        public void TestConnection()
        {
            switch (DataProvider)
            {
                case Provider.Firebird:
                    new FirebirdDataSource(this);
                    break;
            }
        }
    }
}
