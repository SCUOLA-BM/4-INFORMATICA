using System;
using System.Collections.Generic;
using System.Text;

namespace EsIndiaBertoldoMatteo
{
    internal class CSala
    {
        public List<CTavolo> tavoli { get; set; }
        private List<string> lista;

        public CSala()
        {
            tavoli = new List<CTavolo>();
            lista = new List<string>();
            Popola();
        }

        public void Popola()
        {
            tavoli.Add(new CTavolo(7));
            tavoli.Add(new CTavolo(2));
            tavoli.Add(new CTavolo(4));
            tavoli.Add(new CTavolo(5));
            tavoli.Add(new CTavolo(2));
            tavoli.Add(new CTavolo(6));
        }

        public List<string> AggiornaLista()
        {
            lista = new List<string>();
            foreach(var t in tavoli)
            {
                lista.Add(t.Descrizione());
            }
            return lista;
        }
    }
}
