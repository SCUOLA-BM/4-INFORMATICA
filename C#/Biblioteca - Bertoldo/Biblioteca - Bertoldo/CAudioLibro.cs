using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca___Bertoldo
{
    internal class CAudioLibro : CLibro
    {
        public int Durata { get; set; }
        private const int maxgiorni = 14;
        private const double tariffa = 0.4;

        public CAudioLibro(string cod, string tit, int anno, string a, int d) : base(cod, tit, anno, a)
        {
            Durata = d;
        }

        public  override double CalcoloPenale()
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
            return "AUDIO" + base.Descrizione() + " - DUR : " + Durata+ " min";
        }
    }
}
