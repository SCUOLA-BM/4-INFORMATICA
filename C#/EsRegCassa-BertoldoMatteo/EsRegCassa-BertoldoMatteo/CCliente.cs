using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EsRegCassa_BertoldoMatteo
{
    public class CCliente
    {
        public bool Tessera {  get; set; }
        public List<CArticolo> Articoli { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public CCliente()
        {
            Nome = string.Empty;
            Cognome = string.Empty;
            Tessera = true;
            Articoli = new List<CArticolo>();
        }

        public string Print()
        {
            return "\nNOME:"+Nome+"\nCOGNOME: "+Cognome+"\nTESSERA: " +(Tessera ? "SI" : "NO") + "\n\nARTICOLI:" + StampaLista();
        }

        public string StampaLista()
        {
            string str = string.Empty;
            foreach (var a in Articoli)
            {
                str += "\n"+a.Print();
            }
            return str;
        }

        public void Add(CArticolo articolo)
        {
            Articoli.Add(articolo);
        }

        public void AggiornaPrezzo()
        {
            foreach(var a in Articoli)
            {
                if(this.Tessera) a.Sconta();
            }
        }

        public float Somma()
        {
            float somma = 0;
            foreach (var a in Articoli)
            {
                somma += a.Prezzo;
            }
            return somma;
        }
    }
}
