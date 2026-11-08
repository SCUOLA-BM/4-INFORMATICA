using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Tmds.DBus.Protocol;

namespace EsIndiaBertoldoMatteo
{
    internal class CTavolo
    {
        private static int id = 0;
        public int Id { get; set; }
        public int PMax { get; set; }
        public int Poccupati { get; set; }
        public bool Libero { get; set; }
        public List<COrdine> Ordini { get; set; }
        public List<string> Lista {  get; set; }
        public double Tot { get; set; }
        public DateTime Data { get; set; }

        public CTavolo(int pmax)
        {
            Id = id++;
            PMax = pmax;
            Poccupati = 0;
            Libero = true;
            Ordini = new List<COrdine>();
            Lista = new List<string>();
        }

        public bool AggClienti(int n)
        {
            if (n <= PMax)
            {
                Poccupati = n;
                return true;
            }
            return false;
        }

        public void Ordina(COrdine o)
        {
            Lista.Add(o.Descrizione(Ordini.Count+1));
            Ordini.Add(o);
            Data = DateTime.Now;
        }

        public double Conto()
        {
            double conto = 0;
            foreach(var o in Ordini)
            {
                conto += o.CalcolaPrezzo();
            }
            Libero = true;
            Tot = conto;
            return conto;
        }

        public string Descrizione()
        {
            return Id.ToString("D1") + " - " + Poccupati + "/" + PMax + " - " + (Libero ? "LIBERO" : "OCCUPATO")+" - "+Ordini.Count+" ORDINI";
        }

        public void Reset()
        {
            Poccupati = 0;
            Libero = true;
            Ordini = new List<COrdine>();
            Lista = new List<string>();
        }

        public string DescrStorico()
        {
            return Id.ToString("D1") + " - " + Data.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture) + " - " + Ordini.Count + " ORDINI - "+ Conto().ToString("F2")+"€";
        }
    }
}
