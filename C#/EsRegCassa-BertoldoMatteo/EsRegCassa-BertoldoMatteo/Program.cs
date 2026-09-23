using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace EsRegCassa_BertoldoMatteo
{
    internal class Program
    {
        public static List<CCliente> clienti;
        public static string stringa;
        public static int numint;
        public static int cl;
        public static long codice;
        public static CArticolo articolo;
        public static CCliente cliente;
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; //per stampare in UTF-8

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
                } while (!int.TryParse(Console.ReadLine(), out numint) || numint < 1);
                articolo.Prezzo = numint;

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
        }

        public static void Output()
        {
            cl = 1;
            foreach (var c in clienti)
            {
                Console.WriteLine("\n\nCLIENTE N° "+cl);
                Console.WriteLine(c.Print());
                Console.WriteLine("\nIMPORTA DA PAGARE: "+c.Somma());
                cl++;
            }
            
        }
    }
}
