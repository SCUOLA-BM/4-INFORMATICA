using System;
using System.Collections.Generic;
using System.Text;

namespace EsEreditarietàPersone_BertoldoMatteo
{
    internal class CPersona
    {
        protected string codFiscale;
        protected string nome;
        protected string cognome;
        public string CodFiscale
        {
            get {  return codFiscale; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length != 16) throw new ArgumentException("Codice Fiscale non valido\n");
                else codFiscale = value;
            }
        }

        public string Nome
        {
            get { return nome; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Nome non valido\n");
                else nome = value;
            }
        }

        public string Cognome
        {
            get { return cognome; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("Cognome non valido\n");
                else cognome = value;
            }
        }

        public CPersona()
        {
            codFiscale = "";
            nome = "";
            cognome = "";
        }
        public CPersona(string codFisc, string nom, string cogn)
        {
            codFiscale = codFisc;
            nome = nom;
            cognome = cogn;
        }

        public virtual string Print()
        {
            return "\nCodice fiscale : " + CodFiscale + "\nNome : " + Nome + "\nCognome : " + Cognome; 
        }

    }
}
