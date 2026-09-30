using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EsVolatili_BERTOLDO_MATTEO
{
    internal class CPennuto
    {
        public int CodUniv { get; set; }
        public string Specie { get; set; }
        public string Habitat { get; set; }
        public bool Migratore { get; set; }
        public float Alare { get; set; }
        public List<CAvvistamento> Avvistamenti { get; set; }
        public CPennuto()
        {
            CodUniv = 0;
            Specie = String.Empty;
            Habitat = String.Empty;
            Migratore = false;
            Alare = 0.0f;
            Avvistamenti = new List<CAvvistamento>();
        }

        public virtual string ToString()
        {
            return "\nCodUniv: "+CodUniv+"\nSpecie: "+Specie+"\nHabitat: "+Habitat+"\nMigratore: "+Migratore+"\nAlare: "+Alare;
        }

        public void AddAvvist(CAvvistamento avvistamento)
        {
            Avvistamenti.Add(avvistamento);
        }

        public string AvvistToString()
        {
            string result = "";
            foreach (CAvvistamento avvistamento in Avvistamenti)
            {
                result += avvistamento.ToString() + "\n";
            }
            return result;
        }
    }
}
