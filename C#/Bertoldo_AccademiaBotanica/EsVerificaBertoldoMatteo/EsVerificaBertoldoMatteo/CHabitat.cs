using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsVerificaBertoldoMatteo
{
    internal class CHabitat : IEquatable<CHabitat>, IComparable
    {
        public string Nome { get; set; }
        public List<CPianta> Piante { get; set; }

        public CCondAmb c { get; set; }
        public CHabitat(string n, int t, int u, int l, int m)  // COSTRUTTORE
        {
            Nome = n;
            c = new CCondAmb(t, u, l, m);
            Piante = new List<CPianta>();
        }

        public void AddPianta(object o)  // AGGIUNGE PIANTA
        {
            Piante.Add((CPianta)o);
        }

        public void RemPianta(object o)  // RIMUOVE PIANTA
        {
            Piante.Remove((CPianta)o);
        }

        public string Print()  // STAMPA DESCRIZIONE BREVE HABITAT
        {
            return "NOME : " + Nome;
        }

        public bool Equals(CHabitat h)  // VERIFICA UGUAGLIANZA TRA HABITAT PER NOME
        {
            return h.Nome.ToUpper() == Nome.ToUpper();
        }
        public int CompareTo(object obj)  // ORDINA ELENCO HABITAT PER NOME
        {
            if (obj == null) return 1;
            if (!(obj is CHabitat other))
                throw new ArgumentException("L'oggetto non è di tipo Habitat");
            return Nome.CompareTo(other.Nome);
        }

    }
}
