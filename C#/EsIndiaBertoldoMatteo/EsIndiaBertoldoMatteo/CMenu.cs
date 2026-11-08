using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace EsIndiaBertoldoMatteo
{
    internal class CMenu
    {
        public List<CPiatto> menu {  get; }
        private List<string> lista;
        public CMenu()
        {
            menu = new List<CPiatto>();
            lista = new List<string>();
            Popola();
        }

        public void Popola()
        {
            menu.Add(new CPiatto("Samosa", "antipasto", 12.0));
            menu.Add(new CPiatto("Pakora", "antipasto",11.0));
            menu.Add(new CPiatto("Chicken Tikka", "piatto principale", 11.0));
            menu.Add(new CPiatto("Butter Chicken", "piatto principale",11.9));
            menu.Add(new CPiatto("Chicken Curry","piatto principale",14.7));
            menu.Add(new CPiatto("Palak Paneer", "piatto principale",11.3));
            menu.Add(new CPiatto("Dal", "piatto principale",11.2));
            menu.Add(new CPiatto("Naan", "pane",11.2));
            menu.Add(new CPiatto("Biryani", "piatto principale",6.7));
            menu.Add(new CPiatto("Gulab Jamun", "dolce",7.8));
            menu.Add(new CPiatto("Mangolassi", "bevanda",7.8));
        }

        public List<string> AggiornaLista()
        {
            lista = new List<string>();
            foreach (var p in menu) lista.Add(p.Descrizione());
            return lista;
        }

    }
}
