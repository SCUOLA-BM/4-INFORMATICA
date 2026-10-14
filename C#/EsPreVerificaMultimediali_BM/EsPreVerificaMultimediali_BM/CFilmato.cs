using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsPreVerificaMultimediali_BM
{
    internal class CFilmato : CMultimediale,IRiproducibile,ILuminosità, IEquatable<CFilmato>
    {
        public int Durata { get; }
        private int volume;
        private int luminosità;

        public CFilmato(string t, int d, int v, int l) : base(t)
        {
            Durata = d;
            volume = v;
            luminosità = l;
        }

        public string Play()
        {
            string str = "\n" + titolo;
            for (int i = 0; i < Durata; i++) str += "!";
            str += "\n";
            for (int i = 0; i < luminosità; i++) str += "*";

            return str;
        }

        public bool Weaker(int n)
        {
            volume -= n;
            if (volume < 0)
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
            return "TITOLO: " + titolo + "\nDURATA: " + Durata + "\nVOLUME: " + volume+"\nLUMINOSITA'"+ luminosità+"\n";
        }

        public bool Equals(CFilmato f)
        {
            return (this.titolo == f.titolo);
        }
    }
}
