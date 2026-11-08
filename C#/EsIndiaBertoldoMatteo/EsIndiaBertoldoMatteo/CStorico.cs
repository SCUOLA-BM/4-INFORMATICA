using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace EsIndiaBertoldoMatteo
{
    internal class CStorico
    {
        public List<CTavolo> Storico { get; set; }
        string NomeFile = "storico.json";

        public CStorico()
        {
            Carica();

        }

        public void Salva(CTavolo t)
        {
            CTavolo t1 = new CTavolo(t.PMax);
            t1.Id = t.Id;
            t1.Libero = false;
            t1.Data = t.Data;
            t1.Poccupati = t.Poccupati;
            t1.Ordini = new List<COrdine>();
            t1.Tot = t.Tot;

            if (t.Ordini != null)
            {
                foreach (var ord in t.Ordini)
                {
                    t1.Ordini.Add(ord);
                }
            }

            Storico.Add(t1);
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(Storico, options);
            File.WriteAllText(NomeFile, jsonString);
        }

        public void Carica()
        {
            Storico = new List<CTavolo>();
            if (File.Exists(NomeFile))
            {
                string json = File.ReadAllText(NomeFile);
                if (string.IsNullOrWhiteSpace(json)) return;
                Storico = JsonSerializer.Deserialize<List<CTavolo>>(json);
            }
        }

        public string Descrizione()
        {
            string str = "";
            foreach (var t in Storico)
            {
                str+=t.DescrStorico()+"\n";
            }
            return str;
        }
    }
}
