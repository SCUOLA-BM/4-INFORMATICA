using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCampionato2JsonBM
{
    internal class CPartitaEliminazione : CPartita
    {
        private int? rigoriC;
        private int? rigoriO;

        public int? RigoriC
        {
            get { return rigoriC; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("N° RIGORI CASA NON VALIDO");
                rigoriC = value;
            }
        }

        public int? RigoriO
        {
            get { return rigoriO; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("N° RIGORI OSPITI NON VALIDO");
                rigoriO = value;
            }
        }

        public override string Fase
        {
            get { return "Eliminazione"; }
        }

        public CPartitaEliminazione(int g, string nc, string no, int gc, int go, int? rc = null, int? ro = null) : base(g, nc, no, gc, go)
        {
            RigoriC = rc;
            RigoriO = ro;
        }

        public void VerificaRigori()
        {
            if (CalcolaEsito() == Esito.Pareggio)
            {
                if (RigoriC is null || RigoriO is null)
                    throw new InvalidOperationException("PARITA', SI PASSA AI RIGORI");
                if (RigoriC == RigoriO)
                    throw new InvalidOperationException("RIGONI IN PARITA', SI DEVE DECIDERE VINCITORE");
            }
        }

        public override string? CalcolaVincitore()
        {
            if (CalcolaEsito() != Esito.Pareggio)
                return base.CalcolaVincitore();

            if (RigoriC is null || RigoriO is null)
                return null;

            if (RigoriC > RigoriO)
                return NomeC;
            return NomeO;
        }

        public override string Descrizione()
        {
            if (CalcolaEsito() != Esito.Pareggio || RigoriC == null || RigoriO == null)
                return base.Descrizione();

            return base.Descrizione() + " (d.c.r. " + RigoriC + "-" + RigoriO + ", passa " + CalcolaVincitore() + ")";
        }

        public override int PuntiPer(string squadra)
        {
            return 0;
        }
    }
}
