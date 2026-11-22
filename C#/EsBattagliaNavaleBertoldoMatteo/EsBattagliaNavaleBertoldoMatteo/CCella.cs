using System;
using System.Collections.Generic;
using System.Text;

namespace EsBattagliaNavaleBertoldoMatteo
{
    public class CCella
    {
        public int X {  get; set; }
        public int Y { get; set; }
        public bool Verticale { get; set; }
        public bool Nave {  get; set; }
        public CCella(int y, int x)
        {
            X = x;
            Y = y;
            Verticale = false;
            Nave = false;
        }
    }
}
