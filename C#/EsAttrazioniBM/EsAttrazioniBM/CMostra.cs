using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EsAttrazioniBM
{
    internal class CMostra : CAttrazione
    {
        private string autore;
        private List<string> opere;

        public string Autore
        {
            get {  return autore; }
            set { if(string.IsNullOrWhiteSpace(value)) throw new ArgumentException("AUTORE NON VALIDO"); autore = value; }
        }

        public List<string> Opere
        {
            get { return opere; }
            set { if (opere == null) throw new ArgumentException("LISTA OPERE NON VALIDA"); opere = value;  }
        }

        public CMostra() : base()
        {
            autore = null;
            opere = new List<string>();
        }

        public void AddOpere(string ope)
        {
            opere.Add(ope);
        }
        public string InfoOpere()
        {
            string str = "\nOPERE: ";
            foreach (var o in opere) str+= "\n"+o;
            return str;
        }

        public override string Info()
        {
            return "\n   GIOSTRA" + base.Info() + "\nAUTORE : " + autore  + InfoOpere();
        }
    }
}
