using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsGarage_BertoldoMatteo
{
    internal class CGarage
    {
        private List<CVeicolo> lstGarage;

        public List<CVeicolo> LstGarage{ get; set; }

        public CGarage()
        {
            lstGarage = new List<CVeicolo>();
        }

        public void Add(CVeicolo veicolo)
        {
            lstGarage.Add(veicolo);
        }

        public void Elim(int index)
        {
            lstGarage.RemoveAt(index);
        }

        public string Print()
        {
            string str = string.Empty;
            foreach(var v in lstGarage)
            {
                str += v.Print();
            }
            return str;
        }
    }
}
