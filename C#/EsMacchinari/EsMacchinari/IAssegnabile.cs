using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsMacchinari
{
    internal interface IAssegnabile
    {
        void Assegna(CMacchinario m);
        bool Libera(int id);
        
    }
}
