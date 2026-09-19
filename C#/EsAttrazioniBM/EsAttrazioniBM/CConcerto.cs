using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsAttrazioniBM
{
    internal class CConcerto : CAttrazione
    {
        private TimeSpan oraInizio;
        private int numPosti;

        public TimeSpan OraInizio {  
            get { return oraInizio; } 
            set { if (oraInizio < TimeSpan.Zero || oraInizio > new TimeSpan(24,0,0)) throw new ArgumentException("ORA INIZIO NON VALIDA"); oraInizio = value; } 
        }

        public int NumPosti
        {
            get { return numPosti; }
            set { if (numPosti < 0) throw new ArgumentException("NUMERO POSTI NON VALIDO"); numPosti = value; }
        }

        public CConcerto() : base()
        {
            oraInizio = TimeSpan.Zero;
            numPosti = 0;
        }
        public override string Info()
        {
            return "\n   GIOSTRA" + base.Info() + "\nORA INIZIO : " + oraInizio + "\nNUM POSTI : " + numPosti;
        }

    }
}
