using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsVolatili_BERTOLDO_MATTEO
{
    internal class CRapace : CPennuto
    {
        public string Dieta { get; set; }
        public CRapace() : base()
        {
            Dieta = String.Empty;
        }
        public override string ToString()
        {
            return base.ToString() + "\nDieta: " + Dieta;
        }
    }
}
