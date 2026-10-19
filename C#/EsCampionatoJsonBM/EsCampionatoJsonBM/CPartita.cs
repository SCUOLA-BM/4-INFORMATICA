using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCampionatoJsonBM
{
    internal class CPartita
    {
        public string Casa { get; set; }
        public string Ospite { get; set; }
        public int GolC { get; set; }
        public int GolO { get; set; }

        public CPartita(string c, string o, int gc, int go)
        {
            Casa = c;
            Ospite = o;
            GolC = gc;
            GolO = go;
        }

    }
}
