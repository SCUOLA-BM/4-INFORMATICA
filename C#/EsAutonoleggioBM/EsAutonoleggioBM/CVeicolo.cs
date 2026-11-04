using System;
using System.Collections.Generic;
using System.Text;

namespace EsAutonoleggioBM
{
    internal abstract class CVeicolo
    {
        protected string Targa { get; }
        protected string Modello {  get; }
        protected string Tipo { get; }
        protected double TariffaGiornaliera { get; }

        protected CVeicolo(string ta, string m, string ti, double tg)
        {
            Targa = ta;
            Modello = m;
            Tipo = ti;
            TariffaGiornaliera = tg;
        }

        public virtual double CalcolaCosto(int g)
        {
            return TariffaGiornaliera * g;
        }

        public override string ToString()
        {
            return "" + Tipo + " - " + Modello +"("+Targa+")"+ " - " + TariffaGiornaliera + " €/giorno";
        }

        public bool Duplicata(string t)
        {
            if (Targa == t) return true;
            return false;
        }

    }
}
