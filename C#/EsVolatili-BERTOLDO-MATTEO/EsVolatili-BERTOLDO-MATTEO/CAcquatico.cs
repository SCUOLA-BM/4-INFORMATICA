using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsVolatili_BERTOLDO_MATTEO
{
    internal class CAcquatico : CPennuto
    {
        public bool TipoAcqua { get; set; } // true -> dolce / false -> salata

        public CAcquatico() : base()
        {
            TipoAcqua = true;
        }

        public override string ToString()
        {
            return base.ToString() + "\nTIPO ACQUA : " + TipoAcqua; 
        }
    }
}
