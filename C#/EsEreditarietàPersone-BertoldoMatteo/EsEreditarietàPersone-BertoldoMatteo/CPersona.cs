using System;
using System.Collections.Generic;
using System.Text;

namespace EsEreditarietàPersone_BertoldoMatteo
{
    internal class CPersona
    {
        protected string CodFiscale {  get; set; }
        protected string Nome { get; set; }
        protected string Cognome { get; set; }

        public CPersona()
        {
            CodFiscale = "";
            Nome = "";
            Cognome = "";
        }
        public CPersona(string codFiscale, string nome, string cognome)
        {
            CodFiscale = codFiscale;
            Nome = nome;
            Cognome = cognome;
        }

        public string Print()
        {
            return "Codice fiscale : " + CodFiscale + "\nNome : " + Nome + "\nCognome : " + Cognome; 
        }

    }
}
