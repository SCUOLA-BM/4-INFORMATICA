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
        public int Capacità { get; set; }
        public int Cemento { get; set; }

        //COSTRUTTORE
        public CBetoniera(string targa, string modello, int anno, int volume, bool stato, int capacità, int cemento) : base(targa, modello, anno, volume, stato)
        {
            Capacità = capacità;
            if (capacità < cemento) throw new ArgumentException("SUPERATO LIMITE DI SERBATOIO");
            Cemento = cemento;
        }

        //METODI
        public string Carica(int c)
        {
            if (Cemento + c >= Capacità) return "\nSUPERATO LIMITE CAPACITA'";
            else
            {
                Cemento += c;
                return "\nCEMENTO CARICATO CON SUCCESSO!!";
            }
        }

        public string Versa(int c)
        {
            if (Cemento - c < 0) return "\nCEMENTO INSUFFICIENTE";
            else
            {
                Cemento -= c;
                return "\nCEMENTO VERSATO CON SUCCESSO!!";
            }
        }

        public string Descrizione()
        {
            return base.Descrizione() + "\nCAPACITA': " + Capacità + "\nCEMENTO: " + Cemento;
        }

    }
}
