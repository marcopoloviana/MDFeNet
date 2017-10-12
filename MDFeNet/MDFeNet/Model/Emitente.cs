using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDFeNet.Model
{
    public class Emitente
    {
        public string cnpj { get; set; }
        public string ie { get; set; }
        public string xNome { get; set; }
        public string xFant { get; set; }
        public string xLgr { get; set; }
        public string nro { get; set; }
        public string xCpl { get; set; }
        public string xBairro { get; set; }
        public string cMun { get; set; }
        public string cep { get; set; }
        public string uf { get; set; }
        public string fone { get; set; }
        public string email { get; set; }

    }

    public string GetStatement()
    {
        return null;
    }
}
