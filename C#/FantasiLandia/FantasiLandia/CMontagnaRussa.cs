using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasiLandia
{
    internal class CMontagnaRussa : CAttrazione
    {
        public int Prezzo {  get; set; }
        private int altezzaMin;
        private int fastPass;
        private bool stato;

        public CMontagnaRussa(string n, int cap, bool s,int t, int c,int p, int amin, int f) : base(n,cap,s,t,c)
        {
            stato = s;
            Prezzo = p;
            altezzaMin = amin;
            fastPass = f;
        }

        public override string Print()
        {
            return base.Print() + "\nPREZZO: " + Prezzo + "ALTEZZA MIN: " + altezzaMin;
        }

        public override int CalcolaPrezzo(CVisitatore vis)
        {
            if (vis.FastPass) Prezzo += fastPass;
            return Prezzo;
        }

        public override bool Verifica(CVisitatore vis)
        {
            if (!stato) throw new ArgumentException("LA MONTAGNA RUSSA E' CHIUSA PER GUASTO");
            return vis.Altezza >= altezzaMin;
        }
    }
}
