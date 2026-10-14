using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsTorteBM
{
    internal class CCrostata : CDolce
    {
        private bool glassatura;
        public CCrostata(string n, int p) : base(n, p)
        {
            glassatura = false;
            Nome = n;
            Punteggio = p;
        }

        public override string Print()
        {
            return "\nID: "+Id+"\nNOME: " + Nome + "\nPUNTEGGIO: " + Punteggio+ "\nGLASSA: "+ (glassatura ? "SI" : "NO");
        }

        public void Croccantezza()
        {
            Punteggio = Punteggio - 4 <= 0 ? 0 : Punteggio - 4;
        }

        public bool Glassa()
        {
            if (glassatura) return false;
            glassatura = true;
            Punteggio += 2;
            if (Punteggio > 10) Punteggio = 10;
            return true;
        }
    }
}
