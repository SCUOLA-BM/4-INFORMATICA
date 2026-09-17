using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace EsEreditarietàPersone_BertoldoMatteo
{
    internal class CDocente : CPersona
    {
        private string materia;
        private float salario;
        public string Materia
        {
            get { return materia; }
            set { 
                if (!string.IsNullOrWhiteSpace(value)) materia = value;
                else throw new ArgumentException("Materia non inserita\n");
            }
        }
        public float Salario
        {
            get { return salario; }
            set
            {
                if (value > 0.0f) salario = value;
                else throw new ArgumentException("Salario < 0\n");
            }
        }

        public CDocente() : base()
        {
            materia = "";
            salario = 0;
        }

        public CDocente(string codfiscale, string nome, string cognome, string mat, float sal) : base(codfiscale, nome, cognome)
        {
            materia = mat;
            salario = sal;
        }

        public override string Print()
        {
            return base.Print() + "\nMateria : " + this.Materia + "\nSalario : " + this.Salario;
        }

    }
}
