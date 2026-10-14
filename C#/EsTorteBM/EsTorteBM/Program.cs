using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsTorteBM
{
    internal class Program
    {
        private List<CDolce> dolci;
        private bool btorta = false, bcrostata = false;
        private string nome;
        private int punteggio;
        private CTorta t;
        private CCrostata c;
        private CDolce d;
        static void Main(string[] args)
        {
            Program p = new Program
            {
                dolci = new List<CDolce>()
            };
            Console.WriteLine("BENVENUTO NELLA COMPETIZIONE DELLA COPPA DEL LAGO DI FIMON");
            while (true)
            {
                p.Input();
            }
        }

        public void Input()
        {
            int scelta, lim = 2;
            Console.WriteLine("\n0 -> CHIUDI PROGRAMMA");
            Console.WriteLine("1 -> AGGIUNGI TORTA");
            Console.WriteLine("2 -> AGGIUNGI CROSTATA");
            if (dolci.Count > 0)
            {
                lim = 8;
                Console.WriteLine("3 -> VISUALIZZA STATO DOLCI");
                Console.WriteLine("4 -> PROVA DI CROCCANTEZZA");
                Console.WriteLine("5 -> PROVA DI SOFFICENZA");
                Console.WriteLine("6 -> RAFFINAZIONE");
                Console.WriteLine("7 -> FINALE DI DEGUSTAZIONE");
                Console.WriteLine("8 -> MODIFICHE DOLCI(CROSTATE/DOLCI)");
            }
            do
            {
                Console.Write("INSERIRE NUMERO DELL'AZIONE DA SVOLGERE: ");

            } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta > lim);

            switch (scelta)
            {
                case 0: return;
                case 1:
                    AggTorta();
                    break;
                case 2:
                    AggCrostata();
                    break;
                case 3:
                    Print();
                    break;
                case 4:
                    Croccantezza();
                    break;
                case 5:
                    Sofficezza();
                    break;
                case 6:
                    Raffinazione();
                    break;
                case 7:
                    Finale();
                    break;
                case 8:
                    Modifiche();
                    break;
                default:
                    Console.Error.WriteLine("ERRORE NEL PROGRAMMA");
                    return;
            }

        }

        public void AggTorta()
        {
            int strati = 0;
            Console.Write("DOLCE N° "+ (dolci.Count+1));
            do
            {
                Console.Write("\nNOME: ");
                nome = Console.ReadLine();
            } while (nome == "");
            do
            {
                Console.Write("PUNTEGGIO: ");
            } while (!int.TryParse(Console.ReadLine(), out punteggio) || punteggio < 0 || punteggio > 10);
            do
            {
                Console.Write("STRATI: ");
            } while (!int.TryParse(Console.ReadLine(), out strati) || strati < 0 || strati > 10);
            btorta = true;
            dolci.Add(new CTorta(nome,punteggio));
        }

        public void AggCrostata()
        {
            string str= String.Empty;
            Console.Write("DOLCE N° " + dolci.Count + 1);
            do
            {
                Console.Write("\nNOME: ");
                nome = Console.ReadLine();
            } while (nome == "");
            do
            {
                Console.Write("PUNTEGGIO: ");
            } while (!int.TryParse(Console.ReadLine(), out punteggio) || punteggio < 0 || punteggio > 10);
            bcrostata = true;
            dolci.Add(new CCrostata(nome, punteggio));
        }

        public void Print()
        {
            TortePrint();
            CrostatePrint();
        }

        public void TortePrint()
        {
            foreach (var d in dolci)
            {
                if (d is CTorta t)
                {
                    Console.WriteLine("TORTA");
                    Console.WriteLine(t.Print());
                }
            }
        }

        public void CrostatePrint()
        {
            foreach (var d in dolci)
            {
                if (d is CCrostata c)
                {
                    Console.WriteLine("CROSTATA");
                    Console.WriteLine(c.Print());
                }
            }
        }

        public CCrostata CercaCrostata(int id)
        {
            foreach (var d in dolci)
            {
                if (d is CCrostata c && c.Id == id)
                {
                    return c;
                }
            }
            return null;
        }

        public void Croccantezza()
        {
            if (!bcrostata)
            {
                Console.WriteLine("NON HAI ANCORA AGGIUNTO CROSTATE");
                return;
            }
            CrostatePrint();
            do
            {
                Console.Write("INSERIRE ID DELLA CROSTATA: ");
                c = CercaCrostata(int.Parse(Console.ReadLine()));
            } while ( c == null);
            Console.WriteLine("\nPRIMA");
            Console.WriteLine(c.Print());
            c.Croccantezza();
            Console.WriteLine("\nDOPO");
            Console.WriteLine(c.Print());
        }

        public CTorta CercaTorta(int id)
        {
            foreach (var d in dolci)
            {
                if (d is CTorta t && t.Id == id)
                {
                    return t;
                }
            }
            return null;
        }

        public void Sofficezza()
        {
            if (!btorta)
            {
                Console.WriteLine("NON HAI ANCORA AGGIUNTO TORTE");
                return;
            }
            TortePrint();
            do
            {
                Console.Write("INSERIRE ID DELLA TORTA: ");
                t = CercaTorta(int.Parse(Console.ReadLine()));
            } while (t == null);
            Console.WriteLine("\nPRIMA");
            Console.WriteLine(t.Print());
            t.Sofficezza();
            Console.WriteLine("\nDOPO");
            Console.WriteLine(t.Print());
        }

        public CDolce CercaDolce(int id)
        {
            foreach (var d in dolci)
            {
                if (d.Id == id)
                {
                    return t;
                }
            }
            return null;
        }

        public void Raffinazione()
        {
            Print();
            do
            {
                Console.WriteLine("INSERIRE ID DEL DOLCE");
                d = CercaDolce(int.Parse(Console.ReadLine()));
            } while (d == null);
            Console.WriteLine("\nPRIMA");
            Console.WriteLine(d.Print());
            d.Raffinare();
            Console.WriteLine("\nDOPO");
            Console.WriteLine(d.Print());
            
        }

        public void Finale()
        {
            Console.WriteLine("\nPRIMA");
            Print();
            foreach(var d in dolci)
            {
                d.Raffinare();
            }
            Console.WriteLine("\nDOPO");
            Print();
        }

        public void Modifiche()
        {
            foreach(var d in dolci)
            {
                if(d is CTorta t)
                {
                    Console.WriteLine("\nPRIMA");
                    Console.WriteLine(t.Print());
                    Console.WriteLine(t.AggStrato() ? "STRATO AGGIUNTO CON SUCCESSO" : "IMPOSSIBILE AGGIUNGERE STRATO");
                    Console.WriteLine("\nDOPO");
                    Console.WriteLine(t.Print());
                }
                else if(d is CCrostata c)
                {
                    Console.WriteLine("\nPRIMA");
                    Console.WriteLine(c.Print());
                    Console.WriteLine(c.Glassa() ? "GLASSATURA AVVENITA CON SUCCESSO" : "GLASSATURA GIA' ESEGUITA");
                    Console.WriteLine("\nDOPO");
                    Console.WriteLine(c.Print());
                }
            }
        }
    }
}
