using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCampionato2JsonBM
{
    internal abstract class CPartita : IRisultato, IStampabile, IEquatable<CPartita>, IComparable<CPartita>
    {
        private int giornata;
        private string nomeC = string.Empty;
        private string nomeO = string.Empty;
        private int goalC;
        private int goalO;

        public int Giornata
        {
            get { return giornata; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("La giornata deve essere maggiore di zero.");
                giornata = value;
            }
        }
        public string NomeC
        {
            get { return nomeC; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("NOME SQUADRA CASA VUOTO");
                if (nomeO.Length > 0 &&
                    string.Equals(value.Trim(), nomeO, StringComparison.OrdinalIgnoreCase))
                    throw new ArgumentException("SQUADRA NON PUO' GIOCARE CONTRO SE STESSA");
                nomeC = value.Trim();
            }
        }
        public string NomeO
        {
            get { return nomeO; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("NOME SQUADRA OSPITE VUOTO");
                if (nomeC.Length > 0 &&
                    string.Equals(value.Trim(), nomeC, StringComparison.OrdinalIgnoreCase))
                    throw new ArgumentException("SQUADRA NON PUO' GIOCARE CONTRO SE STESSA");
                nomeO = value.Trim();
            }
        }
        public int GoalC
        {
            get { return goalC; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("GOL DEGLI OSPITI NEGATIVI");
                goalC = value;
            }
        }
        public int GoalO
        {
            get { return goalO; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("GOL DEGLI OSPITI NEGATIVI");
                goalO = value;
            }
        }
        //PROPRIETA' ABSTRACT
        public abstract string Fase { get; }

        public CPartita(int g, string nc, string no, int gc, int go)
        {
            Giornata = g;
            NomeC = nc;
            NomeO = no;
            GoalC = gc;
            GoalO = go;
        }

        //METODI ABSTRACT
        public abstract int PuntiPer(string s);

        //METODI VIRTUAL
        public virtual string? CalcolaVincitore()
        {
            if (CalcolaEsito() == Esito.VittoriaCasa)
                return NomeC;
            if (CalcolaEsito() == Esito.VittoriaOspite)
                return NomeO;
            return null;
        }
        public virtual string Descrizione()
        {
            return "Giornata " + Giornata + " [" + Fase + "] " +
                   NomeC + " " + GoalC + "-" + GoalO + " " + NomeO;
        }

        //METODI DERIVATI DA IRisultato
        public int CalcolaGolTotali()
        {
            return GoalC + GoalO;
        }

        public int CalcolaScarto()
        {
            return Math.Abs(GoalC - GoalO);
        }

        public Esito CalcolaEsito()
        {
            if (GoalC > GoalO)
                return Esito.VittoriaCasa;
            if (GoalC < GoalO)
                return Esito.VittoriaOspite;
            return Esito.Pareggio;
        }

        //METODI DERIVATI DA IEquatable
        public bool Equals(CPartita? other)
        {
            if (other is null)
                return false;

            return Giornata == other.Giornata &&
                   string.Equals(NomeC, other.NomeC, StringComparison.OrdinalIgnoreCase) &&
                   string.Equals(NomeO, other.NomeO, StringComparison.OrdinalIgnoreCase);
        }

        //METODI DERIVATI DA IComparable
        public int CompareTo(CPartita? other)
        {
            if (other is null)
                return 1;
            
            return Giornata.CompareTo(other.Giornata);
        }
    }
}
