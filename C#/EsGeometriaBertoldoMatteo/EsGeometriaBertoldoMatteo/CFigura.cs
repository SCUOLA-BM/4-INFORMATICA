using System;
using System.Collections.Generic;
using System.Text;

namespace EsGeometriaBertoldoMatteo
{
    internal abstract class CFigura
    {
        public string Nome { get; set; }
        public double Area {  get; set; }
        public double Perimetro {  get; set; }

        public CFigura(string n)
        {
            Nome = n;
        }

        public abstract double CalcolaArea();
        public abstract double CalcolaPerimetro();
        public virtual string Descrizione()
        {
            return "\nNOME: " + Nome + "\nAREA: " + Area + "\nPERIMETRO: " + Perimetro;
        }
    }
}
