using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsTorteBM
{
    internal class CTorta : CDolce
    {
        //METTERE SEMPRE ATTRIBUTI AD UNA CLASSE CONCRETA, ANCHE SE NON E' IN CONSEGNA
        private int strati;
        public CTorta(string n, int p) : base(n, p)
        {
            strati = 1;
            Nome = n;
            Punteggio = p;
        }

        public override string Print()
        {
            return "\nID: " + Id + "\nNOME: " + Nome + "\nPUNTEGGIO: " + Punteggio+"\nSTRATI: "+strati;
        }

        public void Sofficezza()
        {
            Punteggio = Punteggio - 6 <= 0 ? 0 : Punteggio - 6;
        }

        public bool AggStrato()
        {
            strati++;
            if (strati > 5) return false;
            Punteggio++;
            if (Punteggio > 10) Punteggio = 10;
            return true;
        }
    }
}
