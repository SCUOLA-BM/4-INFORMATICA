using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCampionato2JsonBM
{
    internal class CRepositoryPartite : IRepository<CPartita> 
    {
        private string percorso;
        private List<CPartita> elencoPartite = new List<CPartita>();

        // LA POLICY camelCase GENERA LE CHIAVI JSON DAI NOMI PASCALCASE DELLE PROPRIETA'
        private static readonly JsonSerializerOptions OpzioniJson = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public CRepositoryPartite(string percorso)
        {
            this.percorso = percorso;
        }

        public IReadOnlyList<CPartita> GetElenco() //PER OTTENERE LISTA PARTITE
        {
            return elencoPartite;
        }
        public bool Aggiungi(CPartita elemento)// AGGIUNGE PARTITA E RESTITUISCE FALSE SE ESISTE GIA'
        {
            if (elencoPartite.Contains(elemento))
                return false;

            elencoPartite.Add(elemento);
            return true;
        }

        public bool Rimuovi(CPartita elemento) // RIMUOVE PARTITA E RESTITUISCE FALSE SE NON ESISTE
        {
            return elencoPartite.Remove(elemento);
        }

        public void Carica() //LEGGE DAL FILE JSON LE PARTITE ED ELIMINA DUPLICATE
        {
            elencoPartite.Clear();

            if (!File.Exists(percorso))
                return;   // PRIMO AVVIO

            string json = File.ReadAllText(percorso);
            if (string.IsNullOrWhiteSpace(json))
                return;

            List<CPartita>? lette = JsonSerializer.Deserialize<List<CPartita>>(json, OpzioniJson);
            if (lette == null)
                return;

            foreach (CPartita elemento in lette)
            {
                if (elencoPartite.Contains(elemento))
                    continue;   // SE ESISTE GIA' LO SCARTO

                elencoPartite.Add(elemento);
            }
        }

        public void Salva() //SCRIVE SU JSON ELENCO PARTITE
        {
            string json = JsonSerializer.Serialize(elencoPartite, OpzioniJson);
            File.WriteAllText(percorso, json);
        }

    }
}
