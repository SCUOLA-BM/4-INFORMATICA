using System;
using System.Collections.Generic;
using System.Text;

namespace EsBattagliaNavaleBertoldoMatteo
{
    public class CNave
    {
        public int Lung {  get; set; }
        public int Rimaste {  get; set; }
        public int Id { get; }
        public bool Posizionata { get; set; }
        public List<CCella> Celle { get; set; }

        public CNave(int l, int id)
        {
            Lung = l;
            Rimaste = l;
            Id = id;
            Posizionata = false;
            Celle = new List<CCella>();
        }

        public bool Cerca(CCella cella)
        {
            foreach(var c in Celle)
            {
                if(c == cella)
                {
                    Rimaste--;
                    return true;
                }
            }
            return false;
        }
    }
}
