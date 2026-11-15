using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca___Bertoldo
{
    internal abstract class CMateriale
    {
        public string Codice { get; set; }
        public string Titolo { get; set; }
        public int Anno { get; set; }

        public bool Disponibile { get; set; }

        public string? Nome { get; set; }
        public DateTime? DataPrestito { get; set; }

        public CMateriale() { }

        public CMateriale(string cod, string tit, int anno)
        {
            Codice = cod;
            Titolo = tit;
            Anno = anno;
            Disponibile = true;
        }

        public abstract double CalcoloPenale();
        public abstract string CalcolaRitorno();

        public virtual string Descrizione()
        {
            return "COD: "+Codice+" - TIT: "+Titolo+" - ANNO: " + Anno + (Disponibile? (" - DISPONIBILE"+ " - NOME: "+ Nome+ " - DATA PREST : "+ DataPrestito.ToString()) : " - PRESTITO");
        }
    }
}
