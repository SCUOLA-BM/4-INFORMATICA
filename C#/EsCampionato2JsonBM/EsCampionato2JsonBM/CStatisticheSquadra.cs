using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCampionato2JsonBM
{
    internal class CStatisticheSquadra : IComparable<CStatisticheSquadra>, IEquatable<CStatisticheSquadra>
    {
        bool casa, ospite;
        int goal, subiti;

        public string Squadra { get; }
        public int Giocate { get; private set; }
        public int Vinte { get; private set; }
        public int Pareggiate { get; private set; }
        public int Perse { get; private set; }
        public int GolFatti { get; private set; }
        public int GolSubiti { get; private set; }
        public int DifferenzaReti { get { return GolFatti - GolSubiti; } }
        public int Punti { get; private set; }

        public CStatisticheSquadra(string squadra)
        {
            if (string.IsNullOrWhiteSpace(squadra))
                throw new ArgumentException("NOME SQUADRA VUOTO");
            Squadra = squadra.Trim();
        }


        public void Aggiungi(CPartita partita)
        {
            if (partita is null)
                return;

            casa = string.Equals(partita.NomeC, Squadra, StringComparison.OrdinalIgnoreCase);
            ospite = string.Equals(partita.NomeO, Squadra, StringComparison.OrdinalIgnoreCase);
            if (!casa && !ospite)
                return;

            goal = casa ? partita.GoalC : partita.GoalO;
            subiti = ospite ? partita.GoalO : partita.GoalC;

            Giocate++;
            GolFatti += goal;
            GolSubiti += subiti;

            if (goal > subiti)
                Vinte++;
            else if (goal == subiti)
                Pareggiate++;
            else
                Perse++;

            Punti += partita.PuntiPer(Squadra);
        }

        public int CompareTo(CStatisticheSquadra? other)
        {
            if (other is null)
                return -1;

            int risultato = other.Punti.CompareTo(Punti);
            if (risultato == 0)
                risultato = other.DifferenzaReti.CompareTo(DifferenzaReti);
            if (risultato == 0)
                risultato = other.GolFatti.CompareTo(GolFatti);
            if (risultato == 0)
                risultato = string.Compare(Squadra, other.Squadra, StringComparison.OrdinalIgnoreCase);
            return risultato;
        }

        public bool Equals(CStatisticheSquadra? other)
        {
            if (other is null)
                return false;
            return string.Equals(Squadra, other.Squadra, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
        {
            return Squadra + " - " + Punti + " punti";
        }
    }
}
