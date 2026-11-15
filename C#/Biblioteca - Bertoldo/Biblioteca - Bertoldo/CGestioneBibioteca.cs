using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca___Bertoldo
{
    internal class CGestioneBibioteca
    {
        public List<CMateriale> Lista{ get; set; }

        public CGestioneBibioteca()
        {
            Lista = new List<CMateriale>();
        }

        public void Aggiungi(CMateriale mat)
        {
            if (mat == null) throw new ArgumentException("Oggetto nullo");

            Lista.Add(mat);
        }

        public void Restituisci(CMateriale? mat)
        {
            if(mat == null) throw new ArgumentException("inserisci materiale");
            mat = Cerca(mat);
            if(mat == null) throw new ArgumentException("Materiale non presente nella lista");
            if (mat.Disponibile) throw new ArgumentException("Materiale già a disposizione");
            mat.Disponibile = true;
            mat.Nome = null;
            mat.DataPrestito = null;
        } 

        public void Presta(CMateriale? mat, string n, DateTime d)
        {
            if (mat == null) throw new ArgumentException("inserisci materiale");
            mat = Cerca(mat);
            if (mat == null) throw new ArgumentException("Materiale non presente");
            if (!mat.Disponibile) throw new ArgumentException("Materiale già in prestito");
            mat.Disponibile = false;
            mat.Nome = n;
            mat.DataPrestito = d;
        }

        public CMateriale? Cerca(CMateriale mat)
        {
            foreach(var m in Lista)
            {
                if (m == mat) return m;
            }
            return null;
        }


    }
}
