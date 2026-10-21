using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EsCampionato2JsonBM
{
    internal class CPartitaGirone : CPartita
    {
        bool casa, ospite;
        [JsonIgnore]
        public override string Fase
        {
            get { return "Girone"; }
        }
        public CPartitaGirone(int giornata, string squadraCasa, string squadraOspite, int golCasa, int golOspite, DateTime? data = null)
            : base(giornata, squadraCasa, squadraOspite, golCasa, golOspite, data)
        {
        }

        public override int PuntiPer(string s) //FUNZIONE PER ASSEGNAMENTI DEI PUNTI
        {
            if (string.IsNullOrWhiteSpace(s))
                return 0;

            casa = string.Equals(s, SquadraCasa, StringComparison.OrdinalIgnoreCase);
            ospite = string.Equals(s, SquadraOspite, StringComparison.OrdinalIgnoreCase);
            if (!casa && !ospite)
                return 0;

            if (CalcolaEsito() == Esito.Pareggio)
                return 1;

            return string.Equals(s, CalcolaVincitore(), StringComparison.OrdinalIgnoreCase) ? 3 : 0;
        }
    }
}
