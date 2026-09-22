using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EsGarage_BertoldoMatteo
{
    internal class CVeicolo
    {
        protected int id;
        protected string marca;
        protected int anno;
        protected int cyl;

        public int Id { get; set; }
        public string Marca { get; set; }
        public int Anno { get; set; }
        public int Cyl { get; set; }

        public CVeicolo()
        {
            id = 0;
            marca = string.Empty;
            anno = 0;
            cyl = 0;
        }

        public virtual string Print()
        {
            return "\nID: " + Id + "  MARCA: " + Marca + " ANNO: " + Anno + " CILINDRATA: " + Cyl;

        }
    }
}
