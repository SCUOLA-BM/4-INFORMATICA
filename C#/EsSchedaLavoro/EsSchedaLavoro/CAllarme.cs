using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EsSchedaLavoro
{
    public class CAllarme : ISwitchable
    {
        private bool isAcceso;
        public bool IsAcceso
        {
            get { return isAcceso; }
        }
        
        public void Accendi()
        {
            isAcceso = true;
        }
        public void Spegni()
        {
            isAcceso = false;
        }

        public string MostraDettagli()
        {
            return "ACCESO: "+(isAcceso ? "SI" : "NO");
        }
    }
}
