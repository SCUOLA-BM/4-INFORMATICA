using System;
using System.Collections.Generic;
using System.Text;

namespace EsEreditarietà_BertoldoMatteo
{
    public class CVideo : CFile
    {
        public float Durata { get; set; }
        public CVideo() : base(".mp4", 25.0) { Durata = 3.5f; }

        public string Visualizza()
        {
            return "Sto visualizzando il video.";
        }

    }
}
