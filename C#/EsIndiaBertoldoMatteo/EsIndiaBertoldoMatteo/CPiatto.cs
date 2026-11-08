using System;
using System.Collections.Generic;
using System.Text;

namespace EsIndiaBertoldoMatteo
{
    internal class CPiatto
    {
        public string Nome {  get; set; }
        public string Categoria { get; set; }
        public double Prezzo { get; set; }

        public CPiatto() { } //costruttore vuoto per json
        public CPiatto(string nome, string cat, double prez)
        {
            Nome = nome;
            Categoria = cat;
            Prezzo = prez;
        }

        public string Descrizione()
        {
            return Nome+" - "+Categoria+" - "+Prezzo+"€";
        }
    }
}
