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
        public Benna Benna { get; set; }
        public int Altezza { get; set; }

        //COSTRUTTORE
        public CRuspa(string targa, string modello, int anno, int volume, bool stato, Benna benna) : base(targa, modello, anno, volume, stato)
        {
            Benna = benna;
        }

        //METODO
        public string Descrizione()
        {
            return base.Descrizione() + "\nBENNA: " + Benna;
        }
        
        public bool CambiaBenna(string n)
        {
            Benna b = new Benna();
            if (Enum.TryParse<Benna>(n, out b))
            {
                Benna = b;
                return true;
            }
            else return false;
        }
    }
}
