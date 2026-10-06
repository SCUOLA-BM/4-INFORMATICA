using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsMacchinari
{
    internal class CCantiere : IAssegnabile
    {
        //PROPRIETA'
        public List<CMacchinario> Macchinari { get; set; }
        public string Name { get; set; }

        //COSTRUTTORE
        public CCantiere(string name)
        {
            Macchinari = new List<CMacchinario>();
            Name = name;
        }

        //METODI
        public void Assegna(CMacchinario m)
        {
            Macchinari.Add(m);
        }

        public bool Libera(int id)
        {
            bool trovato = false;
            foreach(var m in Macchinari)
            {
                if(m.Id == id)
                {
                    trovato = true;
                    Macchinari.Remove(m);
                }
            }
            return trovato;
        }

        public string PrintMacchinari()
        {
            string str = ""; 
            foreach(var m in Macchinari)
            {
                str += m.Descrizione();
            }
            return str;
        }
    }
}
