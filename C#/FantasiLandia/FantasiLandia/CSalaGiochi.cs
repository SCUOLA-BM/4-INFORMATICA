using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasiLandia
{
    internal class CSalaGiochi : CAttrazione
    {
        private int gettoni; // 1 gettone costa 2 euro
        private bool stato;


        public CSalaGiochi(string n, int cap, bool s,int t, int c, int g) : base(n, cap, s,t,c)
        {
            stato = s;
            gettoni = g;
        }

        public override string Print()
        {
            return base.Print() + "\nPREZZO : " + gettoni;
        }

        public override int CalcolaPrezzo(CVisitatore vis)
        {
            return gettoni * 2;
        }

        public override bool Verifica(CVisitatore vis)
        {
            if (!stato) throw new ArgumentException("LA SALA GIOCHI E' CHIUSA PER GUASTO");
            return true;
        }
    }
}
