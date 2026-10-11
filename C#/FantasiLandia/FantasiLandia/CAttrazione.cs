using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FantasiLandia
{
    internal abstract class CAttrazione : IFixable
    {
        private string nome;
        private int capienza;
        private bool stato;
        private const int tempoR = 5;
        private const int costoR = 100;

        public CAttrazione(string n, int cap, bool s, int tempoR, int costoR)
        {
            nome = n.ToLower();
            capienza = cap;
            stato = s;
        }
        
        public bool Stato()
        {
            return stato;
        }

        public int Ripara()
        {
            if (stato) throw new ArgumentException("ATTRAZIONE GIA' RIPARATA");
            stato = true;
            return costoR;
        }

        public void SegnalaGuasto()
        {
            stato = false;
        }

        public abstract int CalcolaPrezzo(CVisitatore vis);

        public abstract bool Verifica(CVisitatore vis);

        public virtual string Print()
        {
            return "\nNOME: "+nome+"\nCAPIENZA: "+capienza+"\nSTATO: "+(stato ? "APERTA" : "CHIUSA");
        } 
    }
}
