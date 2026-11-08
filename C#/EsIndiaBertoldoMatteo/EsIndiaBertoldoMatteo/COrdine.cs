using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http.Headers;
using System.Text;

namespace EsIndiaBertoldoMatteo
{
    internal class COrdine
    {
        public List<CPiatto> piatti { get; set; }
        public List<string> Lista;
        
        public COrdine()
        {
            piatti = new List<CPiatto>();
            Lista = new List<string>();
        }

        public void Agg(CPiatto p, int q)
        {
            for(int i = 0; i<q;i++)
            piatti.Add(p);
            Lista.Add(q.ToString()+" x " + p.Descrizione());
        }

        public double CalcolaPrezzo()
        {
            double prezzo = 0;
            foreach(var p in piatti)
            {
                prezzo += p.Prezzo;
            }
            return prezzo;
        }

        public string Descrizione(int id)
        {
            return "ORDINE N° " + id.ToString("D2") + " - PIATTI: "+piatti.Count+" - PREZZO : " + CalcolaPrezzo().ToString("F2") + " €\n";
        }
    }
}
