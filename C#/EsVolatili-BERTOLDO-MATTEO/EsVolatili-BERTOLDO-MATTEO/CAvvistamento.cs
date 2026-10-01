using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsVolatili_BERTOLDO_MATTEO
{
    internal class CAvvistamento : CPennuto
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

        public override string ToString()
        {
            return "Data: " + Data + "\nLuogo: " + Luogo + "\nNote: " + Note;
        }

    }
}
