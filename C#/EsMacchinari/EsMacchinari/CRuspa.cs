using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsMacchinari
{
    public enum Benna
    {
        _300 = 300,
        _500 = 500,
        _700 = 700,
        _1000 = 1000,
        _1500 = 1500,
        _2000 = 2000

    }

    internal class CRuspa : CMacchinario
    {
        private Benna benna;

        //COSTRUTTORE
        public CRuspa(string targa, string modello, int anno, int volume, bool stato, Benna ben) : base(targa, modello, anno, volume, stato)
        {
            benna = ben;
        }

        //METODO
        public override string Descrizione()
        {
            return "\nID: " + Id + "\nTARGA: " + Targa + "\nMODELLO: " + Modello + "\nANNO: " + Anno + "\nVOLUME: " + Volume + "\nSTATO: " + (Stato ? "LIBERO" : "OCCUPATO") + "\nBENNA: " + benna;
        }
        
        public bool CambiaBenna(string n)
        {
            Benna b = new Benna();
            if (Enum.TryParse<Benna>(n, out b))
            {
                benna = b;
                return true;
            }
            else return false;
        }
    }
}
