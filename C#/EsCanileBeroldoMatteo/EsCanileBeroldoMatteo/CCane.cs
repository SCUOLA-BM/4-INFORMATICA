using System;
using System.Collections.Generic;
using System.Text;

namespace EsCanileBeroldoMatteo
{

    internal class CCane
    {
        private string nome;
        private int annoNascita;
        private Erazza razza;

        private DateTime dataIngresso;

        private bool stato;

        private string? informazioni;


        public int Id { get; set; }
        public string Nome
        {
            get {  return nome; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Valore nome non valido!!");
                nome = value; 
            }
        }

        public int AnnoNascita
        {
            get { return annoNascita; }
            set
            {
                if (value < DateTime.Today.Year - 31 || value > DateTime.Today.Year) throw new ArgumentException("Valore anno nascita non valido!!");
                annoNascita = value;
            }
        }

        public Erazza Razza
        {
            get { return  razza; }
            set { razza = value; }
        }

        public DateTime DataIngresso
        {
            get { return dataIngresso; }
            set
            {
                if (value.Year < annoNascita || value > DateTime.Now) throw new ArgumentException("Valore data ingresso non valido");
                dataIngresso = value;
            }
        }

        public bool Stato { get; set; }

        public string? Informazioni
        {
            get { return  informazioni; }
            set
            {
                if (value == null) return;
                if (value == "") throw new ArgumentException("Valore stato non valido!!");
                informazioni = value;
            }
        }

        public CCane()
        {
            Id = 0;
            nome = "";
            annoNascita = 0;
            razza = 0;
            dataIngresso = DateTime.Now;
            stato = true;
        }

        public string Descrizione()
        {
            return Id + "," + nome + "," + annoNascita + "," + razza.ToString() + "," + dataIngresso.ToString("dd/MM/yyyy") + "," + (stato ? "SALUTE" : "AMMALATO") + "," + informazioni;
        }
    }
}
