using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCampionato2JsonBM
{
    internal class RepositoryMemoria<T> : IRepository<T> where T : IEquatable<T>
    {
        private List<T> elementi = new List<T>();

        public IReadOnlyList<T> GetElenco()
        {
            return elementi;
        }

        public bool Aggiungi(T elemento)
        {
            if (elementi.Contains(elemento))
                return false;

            elementi.Add(elemento);
            return true;
        }

        public bool Rimuovi(T elemento)
        {
            return elementi.Remove(elemento);
        }
        public void Carica() { }
        public void Salva() { }
    }
}
