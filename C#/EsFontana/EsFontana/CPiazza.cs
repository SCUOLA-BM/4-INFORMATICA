using System;
using System.Collections.Generic;
using System.Text;

namespace EsFontana
{
    internal class CPiazza : CFontana
    {
        private float diametro;
        private string città;
        private string nome;

        public float Diametro
        {
            get
            {
                return diametro;
            }
            set
            {
                if (float.IsNaN(value) || value >= 0.0f) diametro = value;
                else throw new ArgumentException("DIAMETRO NON VALIDO");
            }

        }

        public string Città
        {
            get
            {
                return città;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) città = value;
                else throw new ArgumentException("NOME CITTA' NON INSERITO");
            }
        }

        public string Nome
        {
            get
            {
                return nome;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) nome = value;
                else throw new ArgumentException("NOME PIAZZA NON INSERITO");
            }
        }

        public CPiazza() : base()
        {
            diametro = 0.0f;
            città = string.Empty;
            nome = string.Empty;
        }

        public override string Print()
        {
            return base.Print()+"\n--PIAZZA\nDIAMETRO : " + diametro + "\nCITTA' : " + città + "\nNOME : " + nome;
        }

    }
}
