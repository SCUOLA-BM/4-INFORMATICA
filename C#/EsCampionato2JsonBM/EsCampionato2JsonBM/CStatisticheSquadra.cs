using System;
using System.Collections.Generic;
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

            casa = string.Equals(partita.SquadraCasa, Squadra, StringComparison.OrdinalIgnoreCase);
            ospite = string.Equals(partita.SquadraOspite, Squadra, StringComparison.OrdinalIgnoreCase);
            if (!casa && !ospite)
                return;

            goal = casa ? partita.GolCasa : partita.GolOspite;
            subiti = casa ? partita.GolOspite : partita.GolCasa;

            Giocate++;
            GolFatti += goal;
            GolSubiti += subiti;

            if (goal > subiti) //CONTROLLO RISULTATO PARTITA
                Vinte++;
            else if (goal == subiti)
                Pareggiate++;
            else
                Perse++;

            Punti += partita.PuntiPer(Squadra);
        }

        public int CompareTo(CStatisticheSquadra? other) // RIDEFINISCO METODI IComparable
        {
            if (other is null)
                return -1;

            int risultato = other.Punti.CompareTo(Punti);
            if (risultato == 0)
                risultato = other.DifferenzaReti.CompareTo(DifferenzaReti);
            if (risultato == 0)
                risultato = other.GolFatti.CompareTo(GolFatti);
            if (risultato == 0)
                risultato = other.Squadra.CompareTo(Squadra);
            return risultato;
        }

        public bool Equals(CStatisticheSquadra? other) // RIDEFINISCO METODI IEquatable
        {
            if (other is null)
                return false;
            return Squadra.ToUpper().Trim() == other.Squadra.ToUpper().Trim();
        }

        public override string ToString()
        {
            return Squadra + " - " + Punti + " punti";
        }
    }
}
