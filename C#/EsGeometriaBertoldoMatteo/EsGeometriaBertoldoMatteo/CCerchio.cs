using System;
using System.Collections.Generic;
using System.Text;

namespace EsGeometriaBertoldoMatteo
{
    internal class CCerchio : CFigura
    {
        public double Raggio {  get; set; }

        public CCerchio(string n, double r) : base(n)
        {
            Nome = "CERCHIO";
            Raggio = r;
        }

        public override double CalcolaArea()
        {
            return Math.Pow(Raggio,2)*double.Pi;
        }

        public override double CalcolaPerimetro()
        {
            return 2 * Raggio * double.Pi;
        }
    }
}
