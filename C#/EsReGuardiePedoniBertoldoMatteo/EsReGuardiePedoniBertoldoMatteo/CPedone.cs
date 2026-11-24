using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace EsReGuardiePedoniBertoldoMatteo
{
    internal class CPedone
    {
        public string Nome { get; set; }
        CGestionale G;

        public CPedone(string n, CGestionale g)
        {
            Nome = n;
            G = g;
            G.Attacca += OnAttacca;
        }

        private string OnAttacca()
        {
            return "Pedone " + Nome + " si sta preparando";
        }

        public void Cattura()
        {
            G.Attacca -= OnAttacca;
        }
    }
}
