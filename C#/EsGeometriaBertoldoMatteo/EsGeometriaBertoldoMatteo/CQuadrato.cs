using System;
using System.Collections.Generic;
using System.Text;

namespace EsGeometriaBertoldoMatteo
{
    internal class CQuadrato : CRettangolo
    {

        public CQuadrato(string n, double l1, double l) : base(n,l1,l)
        {
            Nome = "Quadrato";
            if (l1 == l) Base = l1;
            else throw new ArgumentException("IMPOSSIBILE AVERE QUADRATO CON LATI DIVERSI!!");
        }


    }
}
