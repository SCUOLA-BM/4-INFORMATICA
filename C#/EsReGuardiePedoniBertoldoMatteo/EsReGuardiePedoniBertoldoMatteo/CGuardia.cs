using System;
using System.Collections.Generic;
using System.Text;

namespace EsReGuardiePedoniBertoldoMatteo
{
    internal class CGuardia
    {
        public string Nome { get; set; }
        CGestionale G;

        public CGuardia(string n, CGestionale g)
        {
            Nome = n;
            G = g;
            G.Attacca += OnAttacca;
        }

        private string OnAttacca()
        {
            return "Guardia " + Nome + " sta difendendo";
        }

        public void Cattura()
        {
            G.Attacca -= OnAttacca;
        }
    }
}
