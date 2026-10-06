using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsSchedaLavoro
{
    public abstract class CDispositivoSmart : ISwitchable
    {
        protected string Nome {  get; set; }
        protected string Stanza {  get;set; }
        private bool isAcceso;
        public bool IsAcceso
        {
            get { return isAcceso; }
        }

        public CDispositivoSmart(string nome, string stanza)
        {
            Nome = nome;
            Stanza = stanza;
            isAcceso = false;
        }
        public void Accendi()
        {
            isAcceso = true;
        }
        public void Spegni()
        {
            isAcceso = false;
        }
        public abstract string MostraDettagli();
    }
}
