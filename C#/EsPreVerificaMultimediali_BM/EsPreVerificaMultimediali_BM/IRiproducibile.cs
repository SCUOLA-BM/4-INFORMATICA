using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace EsPreVerificaMultimediali_BM
{
    internal interface IRiproducibile
    {
        string Play();
        bool Weaker(int n);
        bool Louder(int n);
    }
}
