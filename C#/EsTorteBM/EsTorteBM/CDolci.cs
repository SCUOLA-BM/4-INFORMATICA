using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsTorteBM
{
    public abstract class CDolce
    {
        private static int id = -1;
        public int Id { get; }
        protected string Nome {  get; set; }
        protected int Punteggio { get; set; }

        public CDolce(string n, int p)
        {
            id++;
            Id = id;
            Nome = n;
            Punteggio = p;
        }

        public void Raffinare()
        {
            Random r = new Random();

            Punteggio += r.Next(3, 8);
            Punteggio = Punteggio >= 10 ? 10 : Punteggio; 
        }

        public abstract string Print();
    }
}
