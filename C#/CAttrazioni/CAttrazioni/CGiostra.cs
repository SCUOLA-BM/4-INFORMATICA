using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsAttrazioniBM
{
    internal class CGiostra : CAttrazione
    {
        private string tema;
        private int numPosti;

        public string Tema
        {
            get { return tema; }
            set { if (value == null) throw new ArgumentException("TEMA NON VALIDO"); tema = value; }
        }

        public int NumPosti
        {
            get { return numPosti; }
            set { if (numPosti < 0) throw new ArgumentException("NUMERO POSTI NON VALIDO"); numPosti = value; }
        }

        public CGiostra() : base()
        {
            numPosti = 0;
            tema = "";
        }

        public override string Info()
        {
            return "\n   GIOSTRA" + base.Info() + "\nNUM POSTI : " + numPosti+"\nTEMA : "+tema;
        }
    }
}
