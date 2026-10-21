using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EsCampionato2JsonBM
{
    internal class CPartitaFinale : CPartita
    {
        public const int MoltiplicatorePunti = 2;

        public CPartitaFinale(int giornata, string squadraCasa, string squadraOspite, int golCasa, int golOspite, DateTime? data = null)
            : base(giornata, squadraCasa, squadraOspite, golCasa, golOspite, data)
        {
        }

        [JsonIgnore]
        public override string Fase
        {
            get { return "Finale"; }
        }

        public override int PuntiPer(string squadra)
        {
            if (string.IsNullOrWhiteSpace(squadra))
                return 0;

            bool giocaInCasa = string.Equals(squadra, SquadraCasa, StringComparison.OrdinalIgnoreCase);
            bool giocaFuori = string.Equals(squadra, SquadraOspite, StringComparison.OrdinalIgnoreCase);
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
