using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDFeNet.Model
{
    public class IdeMdfe
    {
        public int cUF { get; set; }
        public int tpAmb { get; set; }
        public int tpEmit { get; set; }
        public string tpTransp { get; set; }
        public int mod { get; set; }
        public int serie { get; set; }
        public int nMdf { get; set; }
        public int cMdf { get; set; }
        public int cDV { get; set; }
        public string modal { get; set; }
        public string dhEmi { get; set; }
        public int tpEmis { get; set; }
        public int procEmi { get; set; }
        public string verProc { get; set; }
        public string ufIni { get; set; }
        public string ufFim { get; set; }
        public string infMunCarrega { get; set; }
        public string infPercurso { get; set; }
        public string dhIniViagem { get; set; }
        public string cMunCarrega { get; set; }
        public string xMunCarrega { get; set; }

        public string GetStatement()
        {
            return null;
        }

    }

    
}
