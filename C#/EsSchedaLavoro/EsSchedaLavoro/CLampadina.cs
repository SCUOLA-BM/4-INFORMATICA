using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsSchedaLavoro
{
    internal class CLampadina : CDispositivoSmart
    {
        public int Luminosità {  get; set; }
        public CLampadina(string nome, string stanza, int temperatura) : base(nome, stanza)
        {
            Luminosità = temperatura;
        }
        public override string MostraDettagli()
        {
            return "\nNOME: " + Nome + "\nSTANZA: " + Stanza + "\nACCESO: " + (IsAcceso ? "SI" : "NO") + "\nTEMPERATURA: " + Luminosità;
        }
    }
}
