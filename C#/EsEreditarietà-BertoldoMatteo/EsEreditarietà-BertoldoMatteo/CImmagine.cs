using System;
using System.Collections.Generic;
using System.Text;

namespace EsEreditarietà_BertoldoMatteo
{
    public class CImmagine : CFile
    {
        public int Pixel { get; set; }
        public CImmagine() : base(".jpg", 5.2) { Pixel = 1; }

        public string FiltraBiancoNero()
        {
            return "Ho applicato il filtro bianco e nero all'immagine.";
        }

    }
}
