using System;
using System.Collections.Generic;
using System.Text;

namespace EsFontana
{
    internal class CFontana
    {
        private string nome;
        private float cacqua;
        private bool stato; //vero = accesa di notte - falso = spenta di notte
        private List<string> manutenzione;
        private string autore;


        public string Nome
        {
            get
            {
                return nome;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) nome = value;
                else throw new ArgumentException("NOME FONTANA NON INSERITO");
            }
        }

        public float Cacqua
        {
            get
            {
                return cacqua;
            }
            set
            {
                if (float.IsNaN(value) || value >= 0.0f) cacqua = value;
                else throw new ArgumentException("VALORE CONSUMO ACQUA NON VALIDO");
            }
        }

        public bool Stato
        {
            get
            {
                return stato;
            }
            set
            {
                stato = value;
            }
        }

        public List<string> Manutenzione
        {
            get
            {
                return manutenzione;
            }
            set
            {
                if(manutenzione != null) manutenzione = value;
                else throw new ArgumentException("LISTA MANUTENZIONE NON VALIDA");
            }
        }

        public string Autore
        {
            get
            {
                return autore;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) autore = value;
                else throw new ArgumentException("NOME AUTORE NON INSERITO");
            }
        }

        public CFontana()
        {
            nome = string.Empty;
            cacqua = 0.0f;
            stato = true;
            manutenzione = new List<string>();
            autore = string.Empty;
        }

        public void AggManute(string str)
        {
            if (str != "") manutenzione.Add(str);
            else throw new ArgumentException("MANUTENZIONE NON VALIDA");
        }

        public void ElimManute()
        {
            manutenzione.Clear();
        }

        public float Consumo(float g)
        {
            g *= cacqua;
            return g;
        }

        public string StampaManu()
        {
            string str = "MANUTENZIONI : ";
            foreach (string s in manutenzione) str += "\n-"+s;
            return str;
        }

        public virtual string Print()
        {
            return "\n--FONTANA\nNOME : " + nome + "\nCONSUM0 GIORNALIERO : " + cacqua + "\nSTATO NOTTURNO  : " + (stato ? "SI" : "NO") +"\n"+StampaManu()
                +"\nAUTORE : " + autore;
        }

    }
}
