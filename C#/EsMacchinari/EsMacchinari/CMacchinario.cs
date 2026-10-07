using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EsMacchinari
{
    public abstract class CMacchinario
    {
        //ATTRIBUTI
        private static int id = 0;
        //PROPRIETA'
        public int Id { get; }
        protected string Targa { get; }
        protected string Modello { get;}
        protected int Anno { get;}
        protected int Volume { get;}
        protected bool Stato { get;}

        //COSTRUTTORE
        public CMacchinario(string targa, string modello, int anno, int volume, bool stato)
        {
            Id = id;
            Targa = targa;
            Modello = modello;
            Anno = anno;
            Volume = volume;
            Stato = stato; //true -> occupato / false -> libero
            id++;
        }

        //METODI
        public abstract string Descrizione();     }
    }
}
