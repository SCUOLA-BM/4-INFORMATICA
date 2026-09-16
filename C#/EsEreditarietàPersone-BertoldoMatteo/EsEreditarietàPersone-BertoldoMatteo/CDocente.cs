using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace EsEreditarietàPersone_BertoldoMatteo
{
    internal class CDocente : CPersona
    {
        protected string Materia { get; set; }
        public double Salario { get; set; }

        public CDocente() : base()
        {
            Materia = "";
            Salario = 0;
        }

        public CDocente(string codfiscale, string nome, string cognome, string materia, double salario) : base(codfiscale, nome, cognome)
        {
            Materia = materia;
            Salario = salario;
        }

        public new string Print()
        {
            return base.Print() + "\nMatricola : " + this.Materia + "\nUniversità : " + this.Salario;
        }

    }
}
