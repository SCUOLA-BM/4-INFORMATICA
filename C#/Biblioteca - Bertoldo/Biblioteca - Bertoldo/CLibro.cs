using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Biblioteca___Bertoldo
{
    internal class CLibro : CMateriale
    {
        public string Autore { get; set; }
        private const int maxgiorni = 30;
        private const double tariffa = 0.4;

        public CLibro(string cod, string tit, int anno, string a) : base(cod,tit,anno)
        {
            Autore = a;
        }

        public override double CalcoloPenale()
        {
            if (Disponibile) throw new ArgumentException("Il Libro è libero");
            if (DataPrestito == null)  throw new ArgumentException("La data è nulla");
            int giorni = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).DayNumber - new DateOnly(DataPrestito.Value.Year, DataPrestito.Value.Month, DataPrestito.Value.Day).DayNumber;
            return giorni * tariffa;
        }

        public override string CalcolaRitorno()
        {
            return DateTime.Now.AddDays(maxgiorni).ToShortDateString();
        }

        public override string Descrizione()
        {
            return "LIBRO - " + base.Descrizione() + " - AUT : " + Autore; 
        }
    }
}
