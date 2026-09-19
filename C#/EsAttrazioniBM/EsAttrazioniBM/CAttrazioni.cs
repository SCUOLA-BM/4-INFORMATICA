using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EsAttrazioniBM
{
    internal class CAttrazione
    {
        protected string nome;
        protected float costo;

        public string Nome
        {
            get {  return nome; }
            set { if(string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("NOME NON VALIDO"); nome = value;  }
        }

        public float Costo
        {
            get{ return costo; }
            set{ if (float.IsNaN(value) || value < 0) throw new ArgumentException("COSTO NON VALIDO");  costo = value; }
        }

        public CAttrazione()
        {
            nome = null;
            costo = 0.0f;

        }

        public virtual string Info()
        {
            return "\nNOME : " + nome + "\nCOSTO : " + costo;
        }
    }
}
