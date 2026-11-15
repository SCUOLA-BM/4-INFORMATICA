using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca___Bertoldo
{
    internal class CRivista : CMateriale
    {
        public int NumUscita { get; set; }
        private const int maxgiorni = 7;
        private const double tariffa = 0.10;

        public CRivista(string cod, string tit, int anno, int nu) : base(cod, tit, anno)
        {
            NumUscita = nu;
        }

        public override double CalcoloPenale()
        {
            if (Disponibile) throw new ArgumentException("Il Libro è libero");
            if (DataPrestito == null) throw new ArgumentException("La data è nulla");
            int giorni = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).DayNumber - new DateOnly(DataPrestito.Value.Year, DataPrestito.Value.Month, DataPrestito.Value.Day).DayNumber;
            return giorni * tariffa;
        }

        public override string CalcolaRitorno()
        {
            return DateTime.Now.AddDays(maxgiorni).ToShortDateString();
        }

        public override string Descrizione()
        {
            return "RIVISTA - " + base.Descrizione() + " - NUM USCITA : " + NumUscita;
        }
    }
}
