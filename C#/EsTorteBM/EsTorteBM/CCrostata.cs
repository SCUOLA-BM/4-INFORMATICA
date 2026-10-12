using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsTorteBM
{
    internal class CCrostata : CDolce
    {
        public CCrostata(string n, int p) : base(n, p)
        {
            Nome = n;
            Punteggio = p;
        }

        public override string Print()
        {
            return "\nID: "+Id+"\nNOME: " + Nome + "\nPUNTEGGIO: " + Punteggio;
        }

        public void Croccantezza()
        {
            Punteggio = Punteggio - 4 <= 0 ? 0 : Punteggio - 4;
        }
    }
}
