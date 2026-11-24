using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using System.Runtime.CompilerServices;
using Avalonia.Collections;

namespace EsReGuardiePedoniBertoldoMatteo
{
    internal class CGestionale
    {
        public List<CPedone> Pedoni { get; set; }
        public ObservableCollection<string> PedoniString { get; set; }
        public List<CGuardia> Guardie { get; set; }
        public ObservableCollection<string> GuardieString { get; set; }
        public CRe Re {  get; set; }
        public ObservableCollection<string> Output { get; set; }
        private CPedone ped;
        private CGuardia gua;
        private string[] contenuto, comandi, figure;
        public int NumComandi;
        private static int index;
        public int Index { get { return index; } }
        public delegate string Azione();

        public event Azione? Attacca;
        public event Azione? Fine;

        public CGestionale()
        {
            Reset();
        }

        public string[] LeggiFile()
        {
            Reset();
            File.WriteAllText("output.txt", "");
            string percorso = "file.txt";
            if (File.Exists(percorso))
            {
                contenuto = File.ReadAllLines(percorso);
                comandi = contenuto[3..]; //copia dal 4 elemento in poi
                figure = contenuto[2].Split(" ");
                foreach(string p in figure)
                {
                    ped = new CPedone(p, this);
                    Pedoni.Add(ped);
                    PedoniString.Add("♟️ " + p);
                }
                figure = contenuto[1].Split(" ");
                foreach(string g in figure)
                {
                    gua = new CGuardia(g, this);
                    Guardie.Add(gua);
                    GuardieString.Add("♖ " + g);
                }
                Re = new CRe(contenuto[0], this);
                NumComandi = comandi.Length;
            }
            return comandi;
        }

        public void Reset()
        {
            index = 0;
            RimuoviEventi();
            comandi = new string[100];
            contenuto = new string[103];
            Pedoni = new List<CPedone>();
            Guardie = new List<CGuardia>();
            PedoniString = new ObservableCollection<string>();
            GuardieString = new ObservableCollection<string>();
            Output = new ObservableCollection<string>();

        }

        public void Passo()
        {
            string[] output = new string[100];
            string[] comando = comandi[index].Split(" ");
            if (comandi[index] == "Attacca Re")
            {
                ScatenaEvento(Attacca);
                index++;
            }
            else if (comando[0] == "Cattura")
            {
                index++;
                foreach (CPedone p in Pedoni)
                {
                    if (p.Nome == comando[1])
                    {
                        p.Cattura();
                        Pedoni.Remove(p);
                        AggiornaPedoniString();
                        return;
                    }
                }
                foreach(CGuardia g in Guardie)
                {
                    if (g.Nome == comando[1])
                    {
                        g.Cattura();
                        Guardie.Remove(g);
                        AggiornaGuardieString();
                        return;
                    }
                }
            }
            else if (comandi[index] == "End")
            {
                ScatenaEvento(Fine);
            }
            else
            {
                Output.Add("> " + comandi[index]);
                Output.Add("Comando non valido");
                ScriviFile("Comando non valido");
            }

        }

        public void RimuoviEventi()
        {
            if (Re != null)
            {
                foreach (CPedone p in Pedoni)
                {
                    p.Cattura();
                }
                foreach (CGuardia g in Guardie)
                {
                    g.Cattura();
                }
                Re.Cattura();
            }
                
        }

        public void AggiornaPedoniString()
        {
            PedoniString.Clear();
            foreach (CPedone p in Pedoni)
            {
                PedoniString.Add("♟️ " + p.Nome);
            }
        }

        public void AggiornaGuardieString()
        {
            GuardieString.Clear();
            foreach (CGuardia g in Guardie)
            {
                GuardieString.Add("♖ " + g.Nome);
            }
        }

        public void ScatenaEvento(Azione? evento)
        {
            if (evento == null) return;
            Output.Clear();
            Output.Add("> "+ comandi[index]);
            ScriviFile("\n> "+ comandi[index]+"\n");
            foreach ( Azione a in evento.GetInvocationList())
            {
                string ris = a.Invoke();
                if (!string.IsNullOrWhiteSpace(ris))
                {
                    Output.Add(ris);
                    ScriviFile(ris);
                }
            }
        }

        public void ScriviFile(string str)
        {
            string percorso = "output.txt";
            File.AppendAllText(percorso, str+"\n");
        }
    }
}
