using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasiLandia
{
    internal class CSaltoVuoto : CMontagnaRussa
    {
        private int peso;

        private int supplemento;

        public CSaltoVuoto(string n, int cap,bool s,int t, int c, int p, int a, int f, int pes, int sup) : base(n, cap,s , t, c, p, a, f)
        {
            peso = pes;
            supplemento = sup;
        }

        public override string Print()
        {
            return base.Print() + "\nLIMITE PESO: " + peso + "\nSUPPLEMENTO: " + supplemento;
        }

        public override int CalcolaPrezzo(CVisitatore vis)
        {
            return base.CalcolaPrezzo(vis) + supplemento;
        }

        public override bool Verifica(CVisitatore vis)
        {
            return base.Verifica(vis) && vis.Peso <= peso;
        }
    }
}
