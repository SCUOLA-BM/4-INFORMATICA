using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasiLandia
{
    internal interface IFixable
    {
        bool Stato(); //ritorna lo stato della struttura
        int Ripara(); //imposta a true lo stato
        void SegnalaGuasto(); //imosta a false lo stato

        string Print();
    }
}
