using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsPreVerificaMultimediali_BM
{
    internal class CImmagine : CMultimediale,ILuminosità
    {
        private int luminosità;

        public CImmagine(string t, int l) : base(t)
        {
            luminosità = l;
        }

        public string Show()
        {
            string str = "\n" + titolo;
            for (int i = 0; i < luminosità; i++) str += "*";

            return str;
        }

        public bool Brighter(int n)
        {
            luminosità -= n;
            if (luminosità < 0)
            {
                luminosità = 0;
                return false;
            }
            return true;
        }

        public bool Darker(int n)
        {
            luminosità += n;
            if (luminosità > 10)
            {
                luminosità = 0;
                return false;
            }
            return true;
        }

        public override string Print()
        {
            return "\nTITOLO: " + titolo + "\nLUMINOSITA'" + luminosità;
        }
    }
}
