using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasiLandia
{
    internal class CVisitatore
    {
        private static int id = 0;
        public int Id { get; }
        public bool FastPass {  get; set; }
        public int Altezza {  get; set; }
        public int Peso {  get; set; }
        public int Eta {  get; set; }

        public CVisitatore(bool f,int a, int p, int e)
        {
            id++;
            Id = id;
            FastPass = f;
            Altezza = a;
            Peso = p;
            Eta = e;
        }

        public string Print()
        {
            return "\nID: " + Id + "\nFASTPASS: " + (FastPass ? "SI" : "NO") + "\nALTEZZA: " + Altezza + "\nPESO: " + Peso + "\nETA': " + Eta;
        }
    }
}
