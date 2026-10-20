using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCampionato2JsonBM
{
    internal class CPartitaFinale : CPartita
    {
        public const int MoltiplicatorePunti = 2;

        public CPartitaFinale(int g, string nc, string no,int gc, int go) : base(g, nc, no, gc, go)
        {
        }

        public override string Fase
        {
            get { return "Finale"; }
        }

        public override int PuntiPer(string squadra)
        {
            if (string.IsNullOrWhiteSpace(squadra))
                return 0;

            bool giocaInCasa = string.Equals(squadra, NomeC, StringComparison.OrdinalIgnoreCase);
            bool giocaFuori = string.Equals(squadra, NomeO, StringComparison.OrdinalIgnoreCase);
            if (!giocaInCasa && !giocaFuori)
                return 0;

            if (CalcolaEsito() == Esito.Pareggio)
                return 1 * MoltiplicatorePunti;

            if (string.Equals(squadra, CalcolaVincitore(), StringComparison.OrdinalIgnoreCase))
                return 3 * MoltiplicatorePunti;
            return 0;
        }
    }
}
