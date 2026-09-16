using System;
using System.Collections.Generic;
using System.Text;

namespace EsEreditarietàPersone_BertoldoMatteo
{
    internal class CStudente : CPersona
    {
        public int Matricola { get; set; }
        public string Università { get; set; }

        public CStudente() : base() {
            Matricola = 0; 
            Università = "";
        }

        public CStudente(string codfiscale, string nome, string cognome, int matricola, string università) : base(codfiscale, nome, cognome)
        {
            Matricola = matricola;
            Università = università;
        }

        public new string Print()
        {
            return base.Print() + "\nMatricola : " + Matricola + "\nUniversità : " + Università;
        }

    }
}
