using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EsRegCassa_BertoldoMatteo
{
    internal class CRegistratore
    {

        public List<CScontrino> Scontrini { get; set; }


        public CRegistratore()
        {
            Scontrini = new List<CScontrino>();
        }

        public void EmettiScontrino(float somma, DateTime data)
        {
            CScontrino scontrino = new CScontrino();
            scontrino.Ammontare = somma;
            scontrino.DataE = data;
            scontrino.Id = Scontrini.Count;

        }

        public void Cancella(int n)
        {
            Scontrini.RemoveAt(n);
        }

        public void AggScontrino(CScontrino scontrino)
        {
            Scontrini.Add(scontrino);
        }

        

    }
}
