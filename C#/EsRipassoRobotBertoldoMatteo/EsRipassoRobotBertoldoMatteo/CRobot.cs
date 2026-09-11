using System;
using System.Collections.Generic;
using System.Text;

namespace EsRipassoRobotBertoldoMatteo
{
    internal class CRobot
    {
        private string modello;
        private float potenza;
        private int stato;
        private int anno;

        public CRobot(string Modello, float Potenza, int Stato, int Anno)
        {
            modello = Modello;
            potenza = Potenza;
            stato = Stato;
            anno = Anno;
        }

        public string Print()
        {
            return "Modello = "+modello+"\nPotenza = "+potenza+"\nStato = "+stato+"\nAnno = "+anno;
        }

        public int Stato()
        {
            return stato;
        }
        public int Anno()
        {
            return anno;
        }

        public float Potenza()
        {
            return potenza;
        }
    }
}
