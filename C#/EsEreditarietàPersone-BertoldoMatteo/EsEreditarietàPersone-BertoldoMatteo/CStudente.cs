using System;
using System.Collections.Generic;
using System.Text;

namespace EsEreditarietàPersone_BertoldoMatteo
{
    internal class CStudente : CPersona
    {
        private string matricola;
        private string università;
        public string Matricola
        {
            get { return matricola; }
            set {
                if (!string.IsNullOrWhiteSpace(value)) matricola = value;
                else throw new ArgumentException("matricola non inserita\n");
            }
        }
        public string Università {
            get { return università; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) università = value;
                else throw new ArgumentException("università non inserita\n");
            }
        }

        public CStudente() : base() {
            matricola = ""; 
            università = "";
        }

        public CStudente(string codfiscale, string nome, string cognome, string matr, string uni) : base(codfiscale, nome, cognome)
        {
            matricola = matr;
            università = uni;
        }

        public override string Print()
        {
            return base.Print() + "\nMatricola : " + Matricola + "\nUniversità : " + Università;
        }

    }
}
