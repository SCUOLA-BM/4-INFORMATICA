using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsPreVerificaMultimediali_BM
{
    internal interface ILuminosità
    {
        bool Brighter(int n);
        bool Darker(int n);
    }
}
