using System;
using System.Collections.Generic;
using System.Text;

namespace EsGeometriaBertoldoMatteo
{
    internal class CRettangolo : CFigura
    {
        public double Base {  get; set; }
        public double Altezza { get; set; }

        public CRettangolo(string n, double b, double h) : base(n)
        {
            Nome = "Rettangolo";
            Base = b;
            Altezza = h;
        }

        public override double CalcolaArea()
        {
            return Base * Altezza;
        }

        public override double CalcolaPerimetro()
        {
            return Base * 2 + Altezza * 2;
        }

    }
}
