using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsVerificaBertoldoMatteo
{
    internal class CTemperata : CPianta
    {
        private int tempideale;
        public override string Specie { get; }
        public CTemperata(string n, int e, bool f, int ti) : base(n, e, f)  // COSTRUTTORE
        {
            tempideale = ti;
            Specie = "TEMPERATA";
        }

        public override bool CondAmb(CCondAmb c)  // VERIFICA CHE LA TEMPERATURA SIA SIMILE ALLA TEMPERATURA IDEALE
        {
            return (c.Temperatura <= tempideale + 3 && c.Temperatura >= tempideale - 3);
        }

        public override string Print()  // STAMPA DESCRIZIONE DELL'OGGETTO
        {
            return base.Print() + "\nTEMPERATURA IDEALE: " + tempideale;
        }

        public override string ControlloGen(CCondAmb c)  // STAMPA CONTROLLO GENERALE DELL'OGGETTO
        {
            string str = "";

            str += this.Print() + "\nSPECIE:" + Specie + "\nFOGLIE: " + (foglie ? "PRESENTI" : "ASSENTI") + "\nCONDIZIONI: " + (this.CondAmb(c) ? "ADEGUATE" : "NON ADEGUATE");

            return str;
        }
    }
}
