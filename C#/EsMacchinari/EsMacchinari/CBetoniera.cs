using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsMacchinari
{
    internal class CBetoniera : CMacchinario
    {
        //PROPRIETA'
        private int capacità;
        private int cemento;

        //COSTRUTTORE
        public CBetoniera(string targa, string modello, int anno, int volume, bool stato, int cap, int cem) : base(targa, modello, anno, volume, stato)
        {
            capacità = cap;
            if (capacità < cem) throw new ArgumentException("SUPERATO LIMITE DI SERBATOIO");
            cemento = cem;
        }

        //METODI
        public string Carica(int c)
        {
            if (cemento + c >= capacità) return "\nSUPERATO LIMITE CAPACITA'";
            else
            {
                cemento += c;
                return "\nCEMENTO CARICATO CON SUCCESSO!!";
            }
        }

        public string Versa(int c)
        {
            if (cemento - c < 0) return "\nCEMENTO INSUFFICIENTE";
            else
            {
                cemento -= c;
                return "\nCEMENTO VERSATO CON SUCCESSO!!";
            }
        }

        public override string Descrizione()
        {
            return "\nID: " + Id + "\nTARGA: " + Targa + "\nMODELLO: " + Modello + "\nANNO: " + Anno + "\nVOLUME: " + Volume + "\nSTATO: " + (Stato ? "LIBERO" : "OCCUPATO") + "\nCAPACITA': " + capacità + "\nCEMENTO: " + cemento;
        }

    }
}
