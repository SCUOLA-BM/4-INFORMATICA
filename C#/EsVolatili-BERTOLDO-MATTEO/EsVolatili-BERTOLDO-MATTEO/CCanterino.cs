using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsVolatili_BERTOLDO_MATTEO
{
    internal class CCanterino : CPennuto
    {
        public string CantoCaratt { get; set; }

        public CCanterino() : base()
        {
            CantoCaratt = string.Empty;
        }

        public override string ToString()
        {
            return base.ToString() + "\nCANTO CARATTERISTICO : " + CantoCaratt;
        }
    }
}
