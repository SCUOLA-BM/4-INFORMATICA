using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EsCampionato2JsonBM
{
    internal class CPartitaEliminazione : CPartita
    {
        private int? rigoriCasa;
        private int? rigoriOspite;

        public int? RigoriCasa
        {
            get { return rigoriCasa; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("N° RIGORI CASA NON VALIDO");
                rigoriCasa = value;
            }
        }

        public int? RigoriOspite
        {
            get { return rigoriOspite; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("N° RIGORI OSPITI NON VALIDO");
                rigoriOspite = value;
            }
        }

        [JsonIgnore]
        public override string Fase
        {
            get { return "Eliminazione"; }
        }

        public CPartitaEliminazione(int giornata, string squadraCasa, string squadraOspite, int golCasa, int golOspite, int? rigoriCasa = null, int? rigoriOspite = null, DateTime? data = null)
            : base(giornata, squadraCasa, squadraOspite, golCasa, golOspite, data)
        {
            RigoriCasa = rigoriCasa;
            RigoriOspite = rigoriOspite;
        }

        public void VerificaRigori()
        {
            if (CalcolaEsito() == Esito.Pareggio)
            {
                if (RigoriCasa is null || RigoriOspite is null)
                    throw new InvalidOperationException("PARITA', SI PASSA AI RIGORI");
                if (RigoriCasa == RigoriOspite)
                    throw new InvalidOperationException("RIGONI IN PARITA', SI DEVE DECIDERE VINCITORE");
            }
        }

        public override string? CalcolaVincitore()
        {
            if (CalcolaEsito() != Esito.Pareggio)
                return base.CalcolaVincitore();

            if (RigoriCasa is null || RigoriOspite is null)
                return null;

            if (RigoriCasa > RigoriOspite)
                return SquadraCasa;
            return SquadraOspite;
        }

        public override string Descrizione()
        {
            if (CalcolaEsito() != Esito.Pareggio || RigoriCasa == null || RigoriOspite == null)
                return base.Descrizione();

            return base.Descrizione() + " (d.c.r. " + RigoriCasa + "-" + RigoriOspite + ", passa " + CalcolaVincitore() + ")";
        }

        public override int PuntiPer(string squadra)
        {
            return 0;
        }
    }
}
