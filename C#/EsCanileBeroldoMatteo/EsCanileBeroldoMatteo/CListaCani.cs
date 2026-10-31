using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO.Enumeration;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace EsCanileBeroldoMatteo
{
    internal class CListaCani
    {
        private static int id;
        string FileName = "registrocani.json";
        public List<CCane> ListaCani;
        protected CCane cane;

        public CListaCani()
        {
            ListaCani = new List<CCane>();
            id = 0;
        }

        public void Add(CCane cane)
        {
            if (cane == null) throw new ArgumentNullException("Inserimento di un cane non esistente!!");
            cane.Id = id;
            ListaCani.Add(cane);
            id++;
        }

        public void Elimina(CCane? cane)
        {
            if (cane == null) throw new ArgumentNullException("Eliminazione di un cane inesistente!!");
            if (!Esiste(cane)) throw new ArgumentNullException("Eliminazione di un cane inesistente!!");
            ListaCani.Remove(cane);
            Salva();
        }

        public bool Esiste(CCane cane)
        {
            foreach (var c in ListaCani) if (c == cane) return true;
            return false;
        }

        public void Salva()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(ListaCani, options);
            File.WriteAllText(FileName, json);
        }

        public void Carica()
        {
            ListaCani.Clear();

            if (!File.Exists(FileName))
                return;   // PRIMO AVVIO

            string json = File.ReadAllText(FileName);
            if (string.IsNullOrWhiteSpace(json))
                return;

            List<CCane>? lette = JsonSerializer.Deserialize<List<CCane>>(json);
            if (lette == null)
                return;

            foreach (CCane elemento in lette)
            {
                if (ListaCani.Contains(elemento))
                    continue;   // SE ESISTE GIA' LO SCARTO

                ListaCani.Add(elemento);
                id = elemento.Id+1;
            }
        }
    }
}
