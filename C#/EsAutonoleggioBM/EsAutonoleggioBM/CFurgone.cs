using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;

namespace EsAutonoleggioBM
{
    internal class CFurgone : CVeicolo
    {
        private const string tipo = "Furgone";
        private const double tariffagiornaliera = 80;
        public CFurgone(string ta, string m) : base(ta, m, tipo, tariffagiornaliera) { }

        public override double CalcolaCosto(int g)
        {
            return base.CalcolaCosto(g)+100;
        }
    }
}
