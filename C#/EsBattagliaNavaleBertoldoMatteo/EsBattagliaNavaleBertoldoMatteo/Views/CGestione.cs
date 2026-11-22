using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace EsBattagliaNavaleBertoldoMatteo.Views
{
    public class CGestione
    {
        public List<CNave> Navi { get; set; }
        public Button[,] Bottoni { get; set; }
        public CCella[,] Celle { get; set; }
        public int NaviRimaste {  get; set; }

        public CGestione()
        {
            Navi = new List<CNave>();
            Bottoni = new Button[10,10];
            Celle = new CCella[10,10];
            NaviRimaste = 6;
        }
    }
}
