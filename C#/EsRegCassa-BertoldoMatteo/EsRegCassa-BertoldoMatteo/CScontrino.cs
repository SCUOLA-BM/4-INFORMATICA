using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsRegCassa_BertoldoMatteo
{
    internal class CScontrino
    {
        public float Ammontare { get; set; }
        public DateTime DataE { get; set; }
        public int Id { get; set; }

        public CScontrino()
        {
            Ammontare = 0;
            DataE = DateTime.MinValue;
            Id = 0;
        }

        public string Print()
        {
            return "\nSCONTRINO N. " + Id + "\nDATA EMISSIONE: " + DataE.ToString("dd/MM/yyyy") + "\nAMMONTARE: " + Ammontare + " \u20AC";
        }
    }
}
