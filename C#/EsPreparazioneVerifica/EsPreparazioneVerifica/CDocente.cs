using System;
using System.Collections.Generic;
using System.Text;

namespace EsPreparazioneVerifica
{
    internal class CDocente
    {
        public string Nome {  get; set; }
        public int Ora {  get; set; }
        public bool Sesso {  get; set; }

        public CDocente() { }

        public CDocente(string n, int o, bool s)
        {
            Nome = n;
            Ora = o;
            Sesso = s;
        }

        public string Descrizione()
        {
            return "NOME: " + Nome + " - ORA: " + Ora + " - " + (Sesso ? "UOMO" : "DONNA");
        }
    }
}
