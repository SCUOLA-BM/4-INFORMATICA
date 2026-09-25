using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace EsRegCassa_BertoldoMatteo
{
    internal class Program
    {
        public static List<CCliente> clienti;
        public static string stringa;
        public static int numint, id, cl, scelta, mes, sett;
        public static float prezzo;
        public static long codice;
        public static DateTime data;


        public static CArticolo articolo;
        public static CCliente cliente;
        public static CScontrino scontrino;
        public static CRegistratore registratore;
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; //per stampare in UTF-8
            registratore = new CRegistratore();
            clienti = new List<CCliente>();

            Console.WriteLine("BENVENUTO NEL REGISTRATORE CASSA");
            do
            {
                Console.WriteLine("QUANTI CLIENTI VUOI INSERIRE?");
            } while (!int.TryParse(Console.ReadLine(), out cl) || cl < 1);

            for(int j = 0; j < cl; j++)
            {
                Console.WriteLine("\nCLIENTE N° "+(j+1));
                InserimentoCliente();
                InserimentoArticoli();
                cliente.AggiornaPrezzo();
            }
            
            Output();
        }

        public static void InserimentoCliente()
        {
            cliente = new CCliente();

            do
            {
                Console.Write("NOME: ");
                cliente.Nome = Console.ReadLine();
            } while (cliente.Nome == "");

            do
            {
                Console.Write("COGNOME: ");
                cliente.Cognome = Console.ReadLine();
            } while (cliente.Cognome == "");

            do
            {
                Console.Write("FEDELTA'(SI / NO): ");
                stringa = Console.ReadLine();
            } while (stringa != "SI" && stringa != "NO");
            cliente.Tessera = (stringa == "SI");
        }

        public static void InserimentoArticoli()
        {

            for(int i = 0; i < 5; i++)
            {
                if(i < 3)
                {
                    articolo = new CAlimento();
                    Console.WriteLine("\nALIMENTO N° " + i);
                }
                else
                {
                    articolo = new CNonAlimento();
                    Console.WriteLine("\nNON ALIMENTO N° " + i);
                }

                do
                {
                    Console.Write("CODICE A BARRE: ");
                } while (!long.TryParse(Console.ReadLine(), out codice) || codice.ToString().Length != 13);
                articolo.Codice = codice;

                do
                {
                    Console.Write("DESCRIZIONE: ");
                    articolo.Descrizione = Console.ReadLine();
                } while (articolo.Descrizione == "");

                do
                {
                    Console.Write("PREZZO: ");
                } while (!float.TryParse(Console.ReadLine(), out prezzo) || prezzo < 1);
                articolo.Prezzo = prezzo;

                if (articolo is CAlimento alimento)
                {
                    do
                    {
                        Console.Write("ANNO SCADENZA: ");
                    } while (!int.TryParse(Console.ReadLine(), out numint) || numint < 2026);
                    alimento.AnnoScadenza = numint;
                    cliente.Add(alimento);
                }
                else if (articolo is CNonAlimento nalimento)
                {
                    do
                    {
                        Console.Write("MATERIALE: ");
                        nalimento.Materiale = Console.ReadLine();
                    } while (nalimento.Materiale == "");
                    cliente.Add(nalimento);
                }
            }
            clienti.Add(cliente);
            do
            {
                Console.WriteLine("DATA EMISSIONE: (G/M/A)");
            } while (!DateTime.TryParseExact(Console.ReadLine(), "d/M/yyyy", null, System.Globalization.DateTimeStyles.None, out data));

            registratore.EmettiScontrino(prezzo,data);
        }

        public static void Output()
        {
            numint = 1;
            prezzo = 0;

            foreach (var c in clienti)
            {
                Console.WriteLine("\n\nCLIENTE N° "+numint);
                Console.WriteLine(c.Print());
                Console.WriteLine("\nIMPORTA DA PAGARE: "+c.Somma());
                prezzo += c.Somma();
                numint++;
            }

            do
            {
                Console.WriteLine("STAMPA PER SETTIMANE = 0/ MESE = 1:");
            } while (!int.TryParse(Console.ReadLine(), out scelta) || !(scelta == 0 || scelta == 1));



            if (scelta == 0)
            {
                do
                {
                    Console.WriteLine("N° SETTIMANA:");
                } while (!int.TryParse(Console.ReadLine(), out sett) || sett < 1 || sett > 52);
                StampaPerSett(sett);
            }
            else
            {
                do
                {
                    Console.WriteLine("N° MESE:");
                } while (!int.TryParse(Console.ReadLine(), out mes) || mes < 1 || mes > 12);
                StampaPerMes(mes);
            }
        }

        public static void StampaPerSett(int sett)
        {
            Console.WriteLine("PER SETTIMANA: ");
            foreach(var s in registratore.Scontrini)
            {
                if(numint == CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(s.DataE, CalendarWeekRule.FirstDay, DayOfWeek.Monday))
                {
                    Console.WriteLine(s.Print());
                }
            }

        }

        public static void StampaPerMes(int mes)
        {
            Console.WriteLine("PER MESE: ");
            foreach (var s in registratore.Scontrini)
            {
                if (mes == s.DataE.Month)
                {
                    Console.WriteLine(s.Print());
                }
            }

        }
    }
}
