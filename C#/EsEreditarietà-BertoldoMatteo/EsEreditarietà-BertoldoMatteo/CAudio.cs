using System;
using System.Collections.Generic;
using System.Text;

namespace EsEreditarietà_BertoldoMatteo
{
    public class CAudio : CFile
    {
        public int Volume { get; set; }
        public CAudio() : base(".mp3", 3.5) { Volume = 100; }

        public string Riproduci()
        {
            return "Sto riproducendo l’audio.";
        }

    }
}
