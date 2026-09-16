using System;
using System.Collections.Generic;
using System.Runtime.Versioning;
using System.Text;

namespace EsEreditarietàPersone_BertoldoMatteo
{
    internal class CElencoPersone
    {
        protected List<CPersona> ListaPersone { get; set; }
        protected const int max = 10;

        public CElencoPersone(int n)
        {
            ListaPersone = new List<CPersona>();
        }

        public CElencoPersone(List<CPersona> listaPersone)
        {
            ListaPersone = listaPersone;
        }

        public string Add(CPersona persona)
        {
            if (ListaPersone.Count != max)
            {
                ListaPersone.Add(persona);
                return "AGGIUNTO CON SUCCESSO";
            }
            else return "RAGGIUNTO LIMITE PERONE";
        }

        public string Print()
        {
            string str = "ELENCO PERSONE :\n";
            foreach(CPersona p in ListaPersone)
            {
                str += p.Print() + "\n";
            }
            return str;
        }

        public int ConsaStudenti()
        {
            int n = 0;
            foreach (CPersona p in ListaPersone)
            {
                if (p is CStudente) n++;
            }
            return n;
        }

        public string StampaDocentiConStipendioAlto(double soglia)
        {
            string str = "ELENCO DOCENTI CON STIPENDIO > "+soglia+ "\n";
            foreach (CPersona p in ListaPersone)
            {
                if(p is CDocente doc && doc.Salario > soglia)
                {
                    str += p.Print() + "\n";
                }
            }
            return str;
        }

        public string StampaTipo()
        {
            string str = "ELENCO PERSONE :\n";
            foreach (CPersona p in ListaPersone)
            {
                if (p is CDocente) str += "DOCENTE : \n";
                else str += "STUDENTE : \n";

                str += p.Print();
            }
            return str;
        }
    }
}
