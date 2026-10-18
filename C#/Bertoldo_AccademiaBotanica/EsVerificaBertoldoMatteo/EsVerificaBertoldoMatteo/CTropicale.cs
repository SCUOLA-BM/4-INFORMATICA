using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsVerificaBertoldoMatteo
{
    internal class CTropicale : CPianta, IPerdeFoglie
    {
        private int umiditàmin;
        public override string Specie { get;}
        public CTropicale(string n, int e,bool f, int um) : base(n, e, f)  // COSTRUTTORE
            umiditàmin = um;
            Specie = "TROPICALE";
        }

        public override bool CondAmb(CCondAmb c)  // VERIFICA CHE LA LUMINOSITA' NON SIA PIU' BASSA DI QUELLA MINIMA
        {
            return umiditàmin <= c.Umidità;
        }

        public override string Print()  // STAMPA DESCRIZIONE DELL'OGGETTO
        {
            return base.Print() + "\nUMIDITA' MIN: " + umiditàmin;
        }

        public void Foglie(int m)  // AGGIORNA STATO FOGLIE
        {
            foglie = m > 2 && m <11;
        }

        public override string ControlloGen(CCondAmb c)  // STAMPA CONTROLLO GENERALE DELL'OGGETTO
        {
            string str = "";

            str += this.Print() + "\nSPECIE:" + Specie+ "\nFOGLIE: " + (foglie ? "PRESENTI" : "ASSENTI") +"\nFOGLIE ASSENTI DAL "+2+"MESE AL"+11+"MESE" + "\nCONDIZIONI: " + (this.CondAmb(c) ? "ADEGUATE" : "NON ADEGUATE");

            return str;
        }
    }
}
