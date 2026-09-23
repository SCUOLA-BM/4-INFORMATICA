using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsRegCassa_BertoldoMatteo
{
    public enum Mat 
    {
        vetro,
        carta,
        plastica
    }
    public class CNonAlimento : CArticolo
    {
        public string Materiale { get; set; }

        public CNonAlimento() : base()
        {
            Materiale = string.Empty;
        }

        public override void Sconta()
        {
            if(this.Materiale == Mat.vetro.ToString() || this.Materiale == Mat.carta.ToString() || this.Materiale == Mat.plastica.ToString()) this.Prezzo = Prezzo * 90 / 100;
        }

        public override string Print()
        {
            return base.Print() + "\nMATERIALE : " + Materiale;
        }
    }
}
