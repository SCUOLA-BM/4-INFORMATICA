using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsGarage_BertoldoMatteo
{
    internal class CMoto : CVeicolo
    {
        private bool tempi; //true = 2 / false = 4
        public bool Tempi {  get; set; }

        public CMoto() : base()
        {
            tempi = true;
        }

        public override string Print()
        {
            return base.Print() + "TEMPI : "+(Tempi? "2":"4");
        }

    }
}
