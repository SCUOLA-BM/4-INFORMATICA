using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsVerificaBertoldoMatteo
{
    internal abstract class CPianta : IEquatable<CPianta>, IComparable
    {
        public string Nome { get; }
        protected int età;
        protected bool foglie;
        public abstract string Specie { get; }

        public CPianta(string n, int e, bool f)  // COSTRUTTORE
        {
            Nome = n;
            età = e;
            foglie = f;
        }

        public virtual string Print()  // STAMPA DATI CHE ACCOMUNANO LE PIANTE
        {
            return "\nNOME: " + Nome + "\nETA' : " + età;
        }

        public abstract bool CondAmb(CCondAmb c);  // FUNZIONE ASTRATTA CHE VERRA' IMPLEMENTATA NELLE CLASSI FIGLIO

        public abstract string ControlloGen(CCondAmb c);  // FUNZIONE ASTRATTA CHE VERRA' IMPLEMENTATA NELLE CLASSI FIGLIO

        public bool Equals(CPianta p)  // VERIFICA UGUAGLIANZA TRA DUE PIANTE SECONDO NOME E SPECIE
        {
            return p.Nome.ToUpper() == this.Nome.ToUpper() && p.Specie.ToUpper() == this.Specie.ToUpper();
        }

        public int CompareTo(object obj)  // ORDINA ELENCO DI PIANTE PER SPECIE, NOME ED ETA'
        {
            if (obj == null) return 1;
            if (!(obj is CPianta other))
                throw new ArgumentException("L'oggetto non è di tipo Pianta");
            int result = Specie.CompareTo(other.Specie);

            if (result != 0) return result;

            result = Nome.CompareTo(other.Nome);

            if (result != 0) return result;

            result = età.CompareTo(other.età);
            return result;
        }
    }
}
