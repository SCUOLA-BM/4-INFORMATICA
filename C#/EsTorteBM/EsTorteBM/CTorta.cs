using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsTorteBM
{
    internal class CTorta : CDolce
    {
        public CTorta(string n, int p) : base(n, p)
        {
            Nome = n;
            Punteggio = p;
        }

        public override string Print()
        {
            return "\nID: " + Id + "\nNOME: " + Nome + "\nPUNTEGGIO: " + Punteggio;
        }

        public void Sofficezza()
        {
            Punteggio = Punteggio - 6 <= 0 ? 0 : Punteggio - 6;
        }
    }
}
