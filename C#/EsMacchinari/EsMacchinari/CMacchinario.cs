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
        //PROPRIETA'
        private static int id = 0;
        public int Id { get; }
        public string Targa { get; set; }
        public string Modello { get; set; }
        public int Anno { get; set; }
        public int Volume { get; set; }
        public bool Stato { get; set; }

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
        public string Descrizione()
        {
            return "\nID: "+Id+"\nTARGA: " + Targa + "\nMODELLO: " + Modello + "\nANNO: " + Anno + "\nVOLUME: " + Volume + "\nSTATO: " + (Stato ? "LIBERO" : "OCCUPATO");
        }
    }
}
