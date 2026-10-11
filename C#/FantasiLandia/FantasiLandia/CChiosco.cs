using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasiLandia
{
    internal class CChiosco : IFixable
    {
        private int tempoR;
        private int costoR;
        private bool stato;

        public CChiosco(int t, int c, bool s)
        {
            tempoR = t;
            costoR = c;
            stato = s;
        }

        public string Print()
        {
            return "COSTO RIP: " + costoR + "\nTEMPO RIP: " + tempoR + "\nSTATO : " + (stato ? "FUNZIONANTE" : "GUASTO");
        }

        public bool Stato()
        {
            return stato;
        }

        public int Ripara()
        {
            if (stato) throw new ArgumentException("CHISCO GIA' RIPARATO");
            stato = true;
            return costoR;
        }

        public void SegnalaGuasto()
        {
            if (!stato) throw new ArgumentException("CHIOSCO GIA' GUASTO");
            stato = false;
        }
    }
}
