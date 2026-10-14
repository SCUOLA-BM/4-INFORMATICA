using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsPreVerificaMultimediali_BM
{
    public abstract class CMultimediale : IComparable
    {
        protected string titolo;

        public CMultimediale(string t)
        {
            titolo = t;
        }

        public abstract string Print();

        public int CompareTo(object obj)
        {
            if (!(obj is CMultimediale m))
                throw new ArgumentException("Object is not a Multimediale");
            return titolo.CompareTo(m.titolo);  
        }
    }
}
