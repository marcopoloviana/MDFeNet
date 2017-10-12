using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDFeNet.Model
{
    public class Veiculo
    {
        public string placa { get; set; }
        public string tara { get; set; }
        public string tpRod { get; set; }
        public string tpCar { get; set; }
        public string uf { get; set; }


        public string GetStatement()
        {
            return null;
        }
    }
}
