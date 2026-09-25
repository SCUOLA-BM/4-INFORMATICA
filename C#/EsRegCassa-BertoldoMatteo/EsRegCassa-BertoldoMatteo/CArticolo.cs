using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace EsRegCassa_BertoldoMatteo
{
    public class CArticolo
    {
        public long Codice { get; set; }
        public string Descrizione { get; set; }
        public float Prezzo { get; set; }

        public CArticolo()
        {
            Codice = 0;
            Descrizione = string.Empty;
            Prezzo = 0;
        }

        public virtual void Sconta()
        {
            this.Prezzo = Prezzo * 95 / 100;
        }

        public virtual string Print()
        {
            return "\nCODICE : " + Codice + "\nPREZZO : " + Prezzo + " \u20AC";
        }
    }
}
