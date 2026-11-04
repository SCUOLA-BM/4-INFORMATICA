using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;

namespace EsAutonoleggioBM
{
    internal class CAuto : CVeicolo
    {
        private string modello;
        private string targa;
        private const string tipo = "Auto";
        private const double tariffagiornaliera = 50;
        public CAuto(string ta, string m) : base( ta , m, "Auto" , 50)
        {
            modello = m;
            targa = m;
        }
    }
}
