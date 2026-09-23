using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsRegCassa_BertoldoMatteo
{
    public class CAlimento : CArticolo
    {
        public int AnnoScadenza{ get; set; }
        public CAlimento() : base()
        {
            AnnoScadenza = 0;
        }

        public override void Sconta()
        {
            if (AnnoScadenza == DateTime.Now.Year) this.Prezzo = Prezzo * 80 / 100;
        }

        public override string Print()
        {
            return base.Print() + "\nANNO SCADENZA : " + this.AnnoScadenza;
        }

    }
}
