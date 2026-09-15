using System;
using System.Collections.Generic;
using System.Text;

namespace EsEreditarietà_BertoldoMatteo
{
    public class CFile
    {
        private string estensione;
        private double dimensione;

        public string Estensione
        {
            get { return estensione; }
            set { estensione = value; }
        }

        public double Dimensione
        {
            get { return dimensione; }
            set { dimensione = value; }
        }

        public CFile(string est, double dim)
        {
            estensione = est;
            dimensione = dim;
        }
        public string Apri()
        {
            return "file Aperto";
        }

    }
}
