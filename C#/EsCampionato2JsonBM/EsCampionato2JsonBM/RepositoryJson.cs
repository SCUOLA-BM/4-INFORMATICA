using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCampionato2JsonBM
{
    internal class RepositoryJson<T> : IRepository<T> where T : IEquatable<T>
    {
        private string percorso;
        private List<T> elementi = new List<T>();

        public RepositoryJson(string percorso)
        {
            this.percorso = percorso;
        }

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

        public void Carica()
        {
            elementi.Clear();

            if (!File.Exists(percorso))
                return;   // PRIMO AVVIO

            string json = File.ReadAllText(percorso);
            if (string.IsNullOrWhiteSpace(json))
                return;

            List<T> lette = JsonSerializer.Deserialize<List<T>>(json);
            if (lette == null)
                return;

            foreach (T elemento in lette)
            {
                if (elementi.Contains(elemento))
                    continue;   // SE ESISTE GIA' LO SCARTO

                elementi.Add(elemento);
            }
        }

        public void Salva()
        {
            string json = JsonSerializer.Serialize(elementi);
            File.WriteAllText(percorso, json);
        }

    }
}
