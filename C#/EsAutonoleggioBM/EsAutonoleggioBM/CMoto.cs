using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;

namespace EsAutonoleggioBM
{
    internal class CMoto : CVeicolo
    {
        private string modello;
        private string targa;
        private const string tipo = "Moto";
        private const double tariffagiornaliera = 50;
        public CMoto(string ta, string m) : base(ta, m, tipo, tariffagiornaliera)
        {
            modello = m;
            targa = m;
        }

        public override double CalcolaCosto(int g)
        {
            return g>=7 ? base.CalcolaCosto(g)*8/10 : base.CalcolaCosto(g);
        }
    }
}

