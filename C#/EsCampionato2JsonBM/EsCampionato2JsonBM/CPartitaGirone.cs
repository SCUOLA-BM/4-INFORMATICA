using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCampionato2JsonBM
{
    internal class CPartitaGirone : CPartita
    {
        bool casa, ospite;
        public override string Fase
        {
            get { return "Girone"; }
        }
        public CPartitaGirone(int g, string nc, string no, int gc, int go) : base(g, nc, no, gc, go)
        {
        }

        public override int PuntiPer(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return 0;

            casa = string.Equals(s, NomeC, StringComparison.OrdinalIgnoreCase);
            ospite = string.Equals(s, NomeO, StringComparison.OrdinalIgnoreCase);
            if (!casa && !ospite)
                return 0;

            if (CalcolaEsito() == Esito.Pareggio)
                return 1;

            return string.Equals(s, CalcolaVincitore(), StringComparison.OrdinalIgnoreCase) ? 3 : 0;
        }
    }
}
