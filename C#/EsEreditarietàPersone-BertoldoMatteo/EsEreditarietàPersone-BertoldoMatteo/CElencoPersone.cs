using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.Versioning;
using System.Text;

namespace EsEreditarietàPersone_BertoldoMatteo
{
    internal class CElencoPersone
    {
        private List<CPersona> listaPersone;
        public List<CPersona> ListaPersone
        {
            get {  return new List<CPersona>();}
            set
            {
                if (value != null) listaPersone = value;
                else throw new ArgumentException("Elenco persone non valida\n");
            }
        }
        
        protected int max;

        public CElencoPersone(int n)
        {
            listaPersone = new List<CPersona>();
            max = n;
        }

        public CElencoPersone(List<CPersona> listPersone, int n)
        {
            listaPersone = listPersone;
            max = n;
        }

        public string Add(CPersona persona)
        {
            if (ListaPersone.Count != max)
            {
                listaPersone.Add(persona);
                return "AGGIUNTO CON SUCCESSO";
            }
            else return "RAGGIUNTO LIMITE PERONE";
        }

        public string Print()
        {
            string str = "ELENCO PERSONE :\n";
            int count = 1;
            foreach(var p in listaPersone)
            {
                str +="\nSTUDENTE N°"+count+ p.Print() + "\n";
                count++;
            }
            return str;
        }

        public int ContaStudenti()
        {
            int n = 0;
            foreach (var p in listaPersone)
            {
                if (p is CStudente) n++;
            }
            return n;
        }

        public string StampaDocentiConStipendioAlto(double soglia)
        {
            string str = "ELENCO DOCENTI CON STIPENDIO > "+soglia+ ": \n";
            foreach (CPersona p in listaPersone)
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
            foreach (CPersona p in listaPersone)
            {
                if (p is CDocente) str += "DOCENTE : \n";
                else str += "STUDENTE : \n";

                str += p.Print();
            }
            return str;
        }
    }
}
