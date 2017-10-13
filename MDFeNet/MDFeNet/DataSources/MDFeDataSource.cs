using MDFeNet.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MDFeNet.DataSources
{
    [Serializable]
    public abstract class MDFeDataSource
    {
        public List<Motorista> Motoristas { get; set; }
        public abstract DataTable RetrieveDataFromSQL(string sql);
        public abstract void SetupConnection(DatasourceConfiguration config);
        public abstract void CloseConnection();
    }
}
