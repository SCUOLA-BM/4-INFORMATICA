using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace EsPreVerificaMultimediali_BM
{
    internal class CAudio : CMultimediale,IRiproducibile
    {
        private int durata;
        private int volume;

        public CAudio(string t,int d, int v) : base(t)
        {
            durata = d;
            volume = v;
        }

        public string Play()
        {
            string str = "\n"+titolo;
            for (int i = 0; i < durata; i++) str += "\n!";
            return str;
        }

        public bool Weaker(int n)
        {
            volume -= n;
            if(volume<0)
            {
                volume = 0;
                return false;
            }
            return true;
        }

        public bool Louder(int n)
        {
            volume += n;
            if (volume > 20)
            {
                volume = 0;
                return false;
            }
            return true;
        }

        public override string Print()
        {
            return "TITOLO: " + titolo + "\nDURATA: " + durata + "\nVOLUME: " + volume+ "\n";
        }
    }
}
