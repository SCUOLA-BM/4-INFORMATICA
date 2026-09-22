using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsGarage_BertoldoMatteo
{
    internal class CFurgone : CVeicolo
    {
        private int capacità;

        public int Capacità { get; set; }

        public CFurgone() : base()
        {
            capacità = 0;
        }

        public override string Print()
        {
            return base.Print() + "CAP : " + Capacità+"m³";
        }
    }
}
