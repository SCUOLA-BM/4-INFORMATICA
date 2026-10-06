using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsSchedaLavoro
{
    public class CTermostato : CDispositivoSmart
    {
        public int Temperatura { get; set; }
        public CTermostato(string nome, string stanza,int temperatura) : base(nome,stanza)
        {
            Temperatura = temperatura;
        }
        public override string MostraDettagli()
        {
            return "\nNOME: " + Nome + "\nSTANZA: " + Stanza + "\nACCESO: "+(IsAcceso? "SI" : "NO")+"\nTEMPERATURA: " + Temperatura;
        }
    }
}
