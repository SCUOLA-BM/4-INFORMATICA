using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsVerificaBertoldoMatteo
{
    internal class CMediterranea : CPianta, IPerdeFoglie
    {
        private int lummin;
        public override string Specie { get; }
        public CMediterranea(string n, int e, bool f, int lm) : base(n, e, f)  // COSTRUTTORE
        {
            lummin = lm;
            Specie = "MEDITERRANEA";
        }

        public override bool CondAmb(CCondAmb c)   // VERIFICA CHE LA LUMINOSITA' NON SIA PIU' BASSA DI QUELLA MINIMA
        {
            return lummin <= c.Luminosità;
        }

        public override string Print()  // STAMPA DESCRIZIONE DELL'OGGETTO
        {
            return base.Print() + "\nLUMINOSITA'' MIN: " + lummin;
        }

        public void Foglie(int m)  // AGGIORNA STATO FOGLIE
        {
            foglie = m < 7 || m > 8;
        }

        public override string ControlloGen(CCondAmb c)  // STAMPA CONTROLLO GENERALE DELL'OGGETTO
        {
            string str = "";

            str += this.Print() + "\nSPECIE:" + Specie + "\nFOGLIE: " + (foglie ? "PRESENTI" : "ASSENTI") + "\nFOGLIE ASSENTI DA LUGLIO AD AGOSTO" + "\nCONDIZIONI: " + (this.CondAmb(c) ? "ADEGUATE" : "NON ADEGUATE");

            return str;
        }
    }
}
