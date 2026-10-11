using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FantasiLandia
{
    internal class CGiostra : CAttrazione
    {
        private int prezzo;

        private int etàMax;
        private bool stato;

        public CGiostra(string n, int cap, bool s,int t, int c, int p, int em) : base(n,cap,s,t,c)
        {
            prezzo = p;
            etàMax = em;
            stato = s;
        }

        public override string Print()
        {
            return base.Print() + "\nPREZZO : " + prezzo + "\nETA' MASSIMA : " + etàMax;
        }

        public override int CalcolaPrezzo(CVisitatore vis)
        {
            return prezzo;
        }

        public override bool Verifica(CVisitatore vis)
        {
            if (!stato) throw new ArgumentException("LA GIOSTRA E' CHIUSA PER GUASTO");
            return vis.Eta <= etàMax;
        }
    }
}
