using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace MDFeNet.DataSources
{
    public class MDFeNetConfig
    {
        public static DatasourceConfiguration GetLocalConfiguration()
        {
            return new DatasourceConfiguration();
        }

        public static DatasourceConfiguration ReadFromLocal()
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(@".\DatasourceConfiguration.conf", FileMode.Open);
                BinaryFormatter bin = new BinaryFormatter();
                DatasourceConfiguration conf = (DatasourceConfiguration)bin.Deserialize(fs);
                fs.Close();

                return conf;
            }
            catch (Exception ex)
            {
                if (fs != null)
                    fs.Close();

                return new DatasourceConfiguration();
            }
        }

        public static void SaveToLocal(DatasourceConfiguration conf)
        {
            try
            {
                FileStream fs = new FileStream(@".\DatasourceConfiguration.conf", FileMode.Create);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(fs, conf);
                fs.Close();
            }
            catch (Exception ex)
            {

            }
        }

        public static void WriteStatementForModel(string modelName,
            string statement)
        {
            try
            {
                byte[] b = Encoding.ASCII.GetBytes(statement);
                string[] str = b.Select(x => Convert.ToString(x, 2)).ToArray();
                File.WriteAllLines($@".\Statements\{modelName}.mds", str);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static string ReadStatementForModel(string modelName)
        {
            try
            {
                string[] str = File.ReadAllLines($@".\Statements\{modelName}.mds");
                byte[] rb = str.Select(x => Convert.ToByte(x, 2)).ToArray();
                string result = Encoding.ASCII.GetString(rb);

                return result;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
