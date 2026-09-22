using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsGarage_BertoldoMatteo
{
    internal class CAuto : CVeicolo
    {
        private int numPorte;
        private bool alimentazione; //true = benzina / false = diesel
        
        public int NumPorte { get; set; }
        public bool Alimentazione { get; set; }

        public CAuto() : base()
        {
            numPorte = 0;
            alimentazione = true;
        }

        public override string Print()
        {
            return base.Print() + " PORTE: " + NumPorte + " ALIM: " + (Alimentazione? "BENZINA":"DIESEL");
        }
    }
}
