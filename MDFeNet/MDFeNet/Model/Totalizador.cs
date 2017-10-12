using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDFeNet.Model
{
    public class Totalizador
    {
        public qNFe tara { get; set; }
        public decimal vCarga { get; set; }
        public string cUnid { get; set; }
        public decimal qCarga { get; set; }


        public string GetStatement()
        {
            return null;
        }
    }
}
