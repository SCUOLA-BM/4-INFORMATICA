using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;

namespace EsAutonoleggioBM
{
    internal class CAutoElettrica : CVeicolo, IElettrico
    {
        private const string tipo = "Auto elettrica";
        private const double tariffagiornaliera = 65;
        public int AutonomiaKM { get; }
        public CAutoElettrica(string ta, string m, int akm) : base(ta, m, tipo, tariffagiornaliera)
        {
            AutonomiaKM = akm;
        }

        public override double CalcolaCosto(int g)
        {
            return base.CalcolaCosto(g);
        }


    }
}
