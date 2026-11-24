using System;
using System.Collections.Generic;
using System.Text;

namespace EsReGuardiePedoniBertoldoMatteo
{
    internal class CRe
    {
        public string Nome {  get; set; }
        CGestionale G;

        public CRe(string n, CGestionale g)
        {
            Nome = n;
            G = g;
            G.Attacca += OnAttacca;
        }

        private string OnAttacca()
        {
            return "Il Re " + Nome + " è sotto attacco";
        }

        public void Cattura()
        {
            G.Attacca -= OnAttacca;
        }
    }
}
