using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsVolatili_BERTOLDO_MATTEO
{
    internal class CAvvistamento
    {
        public DateTime Data { get; set; }
        public string Luogo { get; set; }
        public string Note { get; set; }
        public CAvvistamento() : base()
        {
            Data = DateTime.Now;
            Luogo = String.Empty;
            Note = String.Empty;
        }

        public virtual string ToString()
        {
            return "\nData: " + Data + "\nLuogo: " + Luogo + "\nNote: " + Note;
        }

    }
}
