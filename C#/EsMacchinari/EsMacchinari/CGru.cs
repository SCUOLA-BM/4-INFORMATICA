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
        private int portata;
        private int altezza;

        //COSTRUTTORE
        public CGru(string targa, string modello, int anno, int volume, bool stato, int port, int alt) : base(targa,modello,anno,volume,stato)
        {
            portata = port;
            altezza = alt;
        }

        //METODO
        public override string Descrizione()
        {
            return "\nID: " + Id + "\nTARGA: " + Targa + "\nMODELLO: " + Modello + "\nANNO: " + Anno + "\nVOLUME: " + Volume + "\nSTATO: " + (Stato ? "LIBERO" : "OCCUPATO") + "\nPORTATA: " + Portata + "\nALTEZZA: " + Altezza;
        }

        public void Alza()
        {
            if (altezza >= 263) throw new ArgumentException("ALTEZZA NON VALIDA");
            else altezza++;
        }

        public void Abbassa()
        {
            if (altezza == 1) throw new ArgumentException("ALTEZZA NON VALIDA");
            else altezza--;
            
        }

    }
}
