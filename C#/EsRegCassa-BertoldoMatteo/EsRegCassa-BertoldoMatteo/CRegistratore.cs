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
        public CScontrino Scontrino { get; set; }


        public CRegistratore()
        {
            Scontrini = new List<CScontrino>();
        }

        public void EmettiScontrino(int imp, DateTime data)
        {
            CScontrino scontrino = new CScontrino();
            scontrino.Ammontare = imp;
            scontrino.DataE = data;
            scontrino.Id = Scontrini.Count(s => s.DataE.Date == data.Date) + 1;
            Scontrini.Add(scontrino);
        }

        public void Cancella()
        {
            if (Scontrini.Count > 0) Scontrini.RemoveAt(Scontrini.Count - 1);
        }

        public List<CScontrino> ListaScontrini(DateTime data)
        {
            return Scontrini.Where(s => s.DataE.Date == data.Date).ToList(); //ritona la lista di scontrini emessi in una data specifica
        }



    }
}
