using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsSchedaLavoro
{
    internal interface ISwitchable
    {
        void Accendi();
        void Spegni();
        string MostraDettagli();
        bool IsAcceso { get;}
    }
}
