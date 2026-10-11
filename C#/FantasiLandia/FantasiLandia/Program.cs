using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasiLandia
{
    internal class Program
    {
        public List<IFixable> Strutture;
        public List<CAttrazione> Attrazioni;
        public List<CVisitatore> Visitatori;

        public int tempoR = 0, costoR = 0, tot=0;
        public string stato = "";

        static void Main(string[] args)
        {
            Program p = new Program()
            {
                Strutture = new List<IFixable>(),
                Attrazioni = new List<CAttrazione>(),
                Visitatori = new List<CVisitatore>()
            };
            Console.WriteLine("BENVENUTO NEL SOFTWARE GESTIONALE DEL PARCO");
            do
            {
                try
                {
                    p.Input();
                    Console.WriteLine("\nTERMINARE IL PROGRAMMA? (SI/..)?");
                    if (Console.ReadLine() == "SI") return;
                }
                catch(ArgumentException ex) 
                {
                    Console.WriteLine(ex.Message);
                }
            } while (true);
        }

        public void Input()
        {
            int scelta = -1;
            int lim = 4;
            Console.WriteLine("\nINSERISCI NUMERO AZIONE CHE VUOI ESEGUIRE");

            Console.WriteLine("1 -> AGGIUNGI ATTRAZIONE");
            Console.WriteLine("2 -> AGGIUNGI BAGNO");
            Console.WriteLine("3 -> AGGIUNGI CHIOSCO");
            Console.WriteLine("4 -> AGGIUNGI VISITATORE");

            if (Strutture.Count > 0)
            {
                Console.WriteLine("5 -> SEGNALA GUASTO");
                Console.WriteLine("6 -> RIPARA GUASTO");
                lim = 6;
            }

            if (Attrazioni.Count > 0)
            {
                Console.WriteLine("7 -> STAMPA LISTA IN MANUTENZIONE");
                lim = 7;
                if (Visitatori.Count > 0)
                {
                    Console.WriteLine("8 -> SALI IN UNA ATTRAZIONE");
                    Console.WriteLine("9 -> STAMPA INCASSO TOTALE");
                    lim = 9;
                }
                
            }

            do
            {
                Console.Write("SCELTA: ");
            } while (!int.TryParse(Console.ReadLine(), out scelta) || !(scelta>0 && scelta<=lim));

            switch (scelta)
            {
                case 1:
                    AggAttrazione();
                    break;
                case 2:
                    AggBagno();
                    break;
                case 3:
                    AggChiosco();
                    break;
                case 4:
                    AggVisitatore();
                    break;
                case 5:
                    Guasto();
                    break;
                case 6:
                    RipGuasto();
                    break;
                case 7:
                    StampaManutenzione();
                    break;
                case 8:
                    Attrazione();
                    break;
                case 9:
                    IncassoTotale();
                    break;
                default:
                    throw new ArgumentException("ERRORE NELPROGRAMMA");
            }
        }

        public void AggAttrazione()
        {
            string nome = "", scelta = "";
            int capienza = 0, prezzo = 0;


            do
            {
                Console.WriteLine("QUALE ATTRAZIONE VUOI AGGIUNGERE?");
                Console.WriteLine("MONTAGNA RUSSA => 0");
                Console.WriteLine("GIOSTRA => 1");
                Console.WriteLine("SALA GIOCHI => 2");
                scelta = Console.ReadLine();
            } while (scelta != "0" && scelta != "1" && scelta != "2");


            do
            {
                Console.Write("NOME: ");
                nome = Console.ReadLine();
            } while (nome == "");

            do
            {
                Console.Write("CAPIENZA: ");
            } while (!int.TryParse(Console.ReadLine(), out capienza) || capienza<1);

            do
            {
                Console.Write("STATO(FUNZIONANTE => SI / GUASTO => NO): ");
                stato = Console.ReadLine();
            } while (stato != "SI" && stato != "NO");

            do
            {
                Console.Write("TEMPO RIPARAZIONE: ");
            } while (!int.TryParse(Console.ReadLine(), out tempoR) || tempoR < 1);

            do
            {
                Console.Write("COSTO RIPARAZIONE: ");
            } while (!int.TryParse(Console.ReadLine(), out costoR) || costoR < 1);

            switch (scelta)
            {
                case "0":

                    do
                    {
                        Console.Write("PREZZO: ");
                    } while (!int.TryParse(Console.ReadLine(), out prezzo) || prezzo < 1 || prezzo > 100);

                    int altezzamin = 0;
                    do
                    {
                        Console.Write("ALTEZZA MIN: ");
                    } while (!int.TryParse(Console.ReadLine(), out altezzamin) || altezzamin < 60 || altezzamin > 180);

                    int fastpass = 0;
                    do
                    {
                        Console.Write("COSTO FASTPASS: ");
                    } while (!int.TryParse(Console.ReadLine(), out fastpass) || fastpass < 1 || fastpass > 100);

                    CMontagnaRussa mrussa = new CMontagnaRussa(nome, capienza, (stato == "SI"), tempoR, costoR, prezzo, altezzamin, fastpass);
                    Strutture.Add(mrussa);
                    Attrazioni.Add(mrussa);

                    break;
                case "1":

                    do
                    {
                        Console.Write("PREZZO: ");
                    } while (!int.TryParse(Console.ReadLine(), out prezzo) || prezzo < 1 || prezzo > 100);

                    int etamax = 0;
                    do
                    {
                        Console.Write("ETA' MASSIMA: ");
                    } while (!int.TryParse(Console.ReadLine(), out etamax) || etamax < 1 || etamax > 100);
                    CGiostra giostra = new CGiostra(nome, capienza, (stato == "SI"), tempoR, costoR, prezzo, etamax);
                    Strutture.Add(giostra);
                    Attrazioni.Add(giostra);
                    break;
                case "2":

                    do
                    {
                        Console.Write("N° GETTONI: ");
                    } while (!int.TryParse(Console.ReadLine(), out prezzo) || prezzo < 1 || prezzo > 50);

                    CSalaGiochi sgiochi = new CSalaGiochi(nome, capienza, (stato == "SI"), tempoR, costoR, prezzo);
                    Strutture.Add(sgiochi);
                    Attrazioni.Add(sgiochi);
                    break;
                default:
                    throw new ArgumentException("ERRORE NEL PROGRAMMA");
            }
            
        }

        public void AggBagno()
        {
            do
            {
                Console.Write("STATO(FUNZIONANTE => SI / GUASTO => NO): ");
                stato = Console.ReadLine();
            } while (stato != "SI" && stato != "NO");

            do
            {
                Console.Write("TEMPO RIPARAZIONE: ");
            } while (!int.TryParse(Console.ReadLine(), out tempoR) || tempoR < 1);

            do
            {
                Console.Write("COSTO RIPARAZIONE: ");
            } while (!int.TryParse(Console.ReadLine(), out costoR) || costoR < 1);

            CBagni bagno = new CBagni(tempoR, costoR, stato=="SI");

            Strutture.Add(bagno);
        }

        public void AggChiosco()
        {
            do
            {
                Console.Write("STATO(FUNZIONANTE => SI / GUASTO => NO): ");
                stato = Console.ReadLine();
            } while (stato != "SI" && stato != "NO");

            do
            {
                Console.Write("TEMPO RIPARAZIONE: ");
            } while (!int.TryParse(Console.ReadLine(), out tempoR) || tempoR < 1);

            do
            {
                Console.Write("COSTO RIPARAZIONE: ");
            } while (!int.TryParse(Console.ReadLine(), out costoR) || costoR < 1);

            CChiosco chiosco = new CChiosco(tempoR, costoR, stato == "SI");
            Strutture.Add(chiosco);
        }

        public void AggVisitatore()
        {
            string fastpass = "";
            int altezza = 0, peso = 0, età = 0;
            do
            {
                Console.Write("FASTPASS(SI / NO): ");
                fastpass = Console.ReadLine();
            } while (fastpass != "SI" && fastpass != "NO");

            do
            {
                Console.Write("ALTEZZA: ");
            } while (!int.TryParse(Console.ReadLine(), out altezza) || altezza < 1 || altezza > 245);

            do
            {
                Console.Write("PESO: ");
            } while (!int.TryParse(Console.ReadLine(), out peso) || peso < 1 || peso > 500);

            do
            {
                Console.Write("ETA': ");
            } while (!int.TryParse(Console.ReadLine(), out età) || età < 0 || età > 121);

            CVisitatore vis = new CVisitatore(fastpass == "SI", altezza, peso, età);

            Visitatori.Add(vis);
        }

        public void StampaStrutture()
        {
            int c = 0;
            foreach(var strutt in Strutture)
            {
                c++;
                Console.WriteLine("N° "+ c);
                Console.WriteLine(strutt.Print());
            }
        }

        public void StampaAttrazioni()
        {
            int c = 0;
            foreach (var attr in Attrazioni)
            {
                c++;
                Console.WriteLine("N° " + c);
                Console.WriteLine(attr.Print());
            }
        }

        public void StampaVisitatori()
        {
            foreach(var vis in Visitatori)
            {
                Console.WriteLine(vis.Print());
            }
        }

        public void Guasto()
        {
            int scelta = 0;
            Console.WriteLine("IN QUALE STRUTTURA HAI VISTO IL GUASTO?");
            StampaStrutture();
            do
            {
                Console.Write("ATTRAZIONE N°: ");
            } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > Strutture.Count);

            Strutture[scelta-1].SegnalaGuasto();
        }

        public void RipGuasto()
        {
            int scelta = 0;
            Console.WriteLine("QUALE STRUTTURA VUOI RIPARARE?");
            StampaStrutture();
            do
            {
                Console.Write("ATTRAZIONE N°: ");
            } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > Strutture.Count);

            tot-=Strutture[scelta-1].Ripara();
        }

        public void Attrazione()
        {
            int scelta = 0, scelta1 = 0;
            Console.WriteLine("QUALE VISITATORE VUOLE SALIRE");
            StampaVisitatori();
            do
            {
                Console.Write("ID VISITATORE: ");
            } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > Visitatori.Count);

            Console.WriteLine("IN QUALE ATTRAZIONE VUOLE SALIRE?");
            StampaAttrazioni();
            do
            {
                Console.Write("ATTRAZIONE N°: ");
            } while (!int.TryParse(Console.ReadLine(), out scelta1) || scelta1 < 1 || scelta1 > Attrazioni.Count);

            if(Attrazioni[scelta1-1].Verifica(Visitatori[scelta - 1]))
            {
                tot+=Attrazioni[scelta1-1].CalcolaPrezzo(Visitatori[scelta - 1]);
            }
            else
            {
                Console.WriteLine("VISITATORE NON VALIDO PER QUESTA ATTRAZIONE");
            }

            
        }

        public void StampaManutenzione()
        {
            foreach(var a in Attrazioni)
            {
                if (!a.Stato()) Console.WriteLine("\n"+a.Print());
            }
        }

        public void IncassoTotale()
        {
            Console.WriteLine("INCASSO TOTALE: "+ tot + " €");
        }
    }
}
