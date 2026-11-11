using System;
using System.Collections.Generic;
using System.Text;

namespace EsPreparazioneVerifica
{
    internal class CMateria
    {
        public string Nome { get; set; }
        public int OreSettimanali { get; set; }
        public double RetribuzioneOrariaDocente { get; set; }
        public CDocente? Docente {  get; set; }

        public CMateria() { }

        public CMateria(string n, int o, double r )
        {
            Nome = n;
            OreSettimanali = o;
            RetribuzioneOrariaDocente = r;
        }

        public string Descrizione()
        {
            return "MATERIA: " + Nome + " - ORE: " + OreSettimanali + " - RETRIBUZIONE : " + RetribuzioneOrariaDocente + " €" + (Docente != null ? " - NOME: " + Docente.Nome + " - ORE: " + Docente.Ora.ToString() + "SESSO : " + (Docente.Sesso ? " - UOMO" : " - DONNA") : "");
        }
    }
}
