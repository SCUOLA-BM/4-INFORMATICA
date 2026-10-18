using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsVerificaBertoldoMatteo
{
    internal class CCondAmb : IEquatable<CCondAmb>
    {
        public int Temperatura { get; set; }
        public int Umidità { get; set; }
        public int Luminosità { get; set; }
        public int Mese { get; set; }
        public CCondAmb(int t, int u, int l, int m)  // COSTRUTTORE
        {
            Temperatura = t;
            Umidità = u;
            Luminosità = l;
            Mese = m;
        }

        public bool Equals(CCondAmb c)  // CONFRONTA DUE OGGETTI E RITORNA SE SONO UGUALI
        {
            return c.Temperatura == this.Temperatura && c.Umidità == this.Umidità && c.Luminosità == this.Luminosità && c.Mese == this.Mese;
        }


    }
}
