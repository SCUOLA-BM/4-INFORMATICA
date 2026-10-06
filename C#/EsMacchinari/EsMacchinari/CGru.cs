using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsMacchinari
{
    public class CGru : CMacchinario
    {
        //PROPRIETA'
        public int Portata {  get; set; }
        public int Altezza {  get; set; }

        //COSTRUTTORE
        public CGru(string targa, string modello, int anno, int volume, bool stato, int portata, int altezza) : base(targa,modello,anno,volume,stato)
        {
            Portata = portata;
            Altezza = altezza;
        }

        //METODO
        public string Descrizione()
        {
            return base.Descrizione() + "\nPORTATA: " + Portata + "\nALTEZZA: " + Altezza;
        }

        public void Alza()
        {
            Altezza++;
        }

        public void Abbassa()
        {
            if (Altezza == 1) throw new ArgumentException("ALTEZZA NON VALIDA");
            else Altezza--;
            
        }

    }
}
