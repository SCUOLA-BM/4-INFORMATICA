using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;

namespace EsAutonoleggioBM
{
    internal class CAutoElettrica : CVeicolo, IElettrico
    {
        private string modello;
        private string targa;
        private const string tipo = "Auto elettrica";
        private const double tariffagiornaliera = 65;
        public int AutonomiaKM { get; }
        public CAutoElettrica(string ta, string m, int akm) : base(ta, m, tipo, tariffagiornaliera)
        {
            modello = m;
            targa = m;
            AutonomiaKM = akm;
        }

        public override double CalcolaCosto(int g)
        {
            return base.CalcolaCosto(g);
        }


    }
}
