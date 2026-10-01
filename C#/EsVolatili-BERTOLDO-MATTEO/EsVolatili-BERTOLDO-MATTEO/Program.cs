using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace EsVolatili_BERTOLDO_MATTEO
{
    internal class Program
    {
        public string str;
        public float alare;
        public DateTime data;
        public List<CPennuto> pennuti;

        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine("Benvenuto nel programma di gestione dei pennuti!");
            p.Input();
            p.VisualizzaPennuti();
            p.Elimina();
            p.Avvistamenti();
            p.CercaMigratori();
            p.MostraNCat();

        }

        public void Input()
        {
            pennuti = new List<CPennuto>();
            int numint;
            do
            {
                Console.WriteLine("Quanti pennuti vuoi inserire?");
            } while (!int.TryParse(Console.ReadLine(), out numint));

            for (int i = 0; i < numint; i++)
            {
                Console.WriteLine("\nInserisci le informazioni per il pennuto " + (i + 1) + ":");
                CPennuto pennuto = new CPennuto();
                do
                {
                    Console.Write(" RAPACE    -> 0\n CANTERINO -> 1 \n ACQUATICO -> 2\nTIPO PENNUTO : ");
                    str = Console.ReadLine();
                } while (str != "0" && str != "1" && str != "2");

                if (str == "0")
                {
                    pennuto = new CRapace();
                }
                else if (str == "1")
                {
                    pennuto = new CCanterino();
                }
                else
                {
                    pennuto = new CAcquatico();
                }

                pennuto.CodUniv = pennuti.Count;
                do
                {
                    Console.Write("Specie: ");
                    pennuto.Specie = Console.ReadLine();
                } while (pennuto.Specie == "");

                do
                {
                    Console.Write("Habitat: ");
                    pennuto.Habitat = Console.ReadLine();
                } while (pennuto.Habitat == "");

                do
                {
                    Console.Write("Migratore (0 => true/ 1 => false): ");
                    str = Console.ReadLine();
                } while (str != "0" && str != "1");
                pennuto.Migratore = str == "0";
                do
                {
                    Console.Write("Apertura alare: ");
                } while (!float.TryParse(Console.ReadLine(), out alare) || alare <= 0);
                pennuto.Alare = alare;

                if (pennuto is CRapace rapace)
                {
                    do
                    {
                        Console.Write("DIETA: ");
                        rapace.Dieta = Console.ReadLine();
                    } while (rapace.Dieta == "");
                    pennuti.Add(rapace);
                }
                else if (pennuto is CCanterino canterino)
                {
                    do
                    {
                        Console.Write("CANTO CARATTERISTICO: ");
                        canterino.CantoCaratt = Console.ReadLine();
                    } while (canterino.CantoCaratt == "");
                    pennuti.Add(canterino);
                }
                else if (pennuto is CAcquatico acquatico)
                {
                    do
                    {
                        Console.Write("TIPO ACQUA (0 => dolce/ 1 => salata): ");
                        str = Console.ReadLine();
                    } while (str != "0" && str != "1");
                    acquatico.TipoAcqua = str == "0";
                    pennuti.Add(acquatico);
                }

            }
        }

        public void VisualizzaPennuti()
        {
            Console.WriteLine("\nPENNUTI: ");
            foreach (var p in pennuti)
            {
                Console.WriteLine(p.ToString());
            }
        }

        public void Elimina()
        {
            int cod = 0;
            do
            {
                Console.Write("INSERISCI CODICE DEL PENNUTO CHE VUOI ELIMINARE: ");
            } while (!int.TryParse(Console.ReadLine(), out cod) || cod < 0 || cod >= pennuti.Count);

            pennuti.RemoveAt(cod);

        }

        public void Avvistamenti()
        {
            CAvvistamento avvistamento;
            int cod = 0, navv = 0;
            do
            {
                Console.Write("\nINSERISCI CODICE UNIVOCO DEL PENNUTO A CUI VUOI AGGIUNGERE AVVISTAMENTO: ");
            } while (!int.TryParse(Console.ReadLine(), out cod) || cod < 0 || cod >= pennuti.Count);


            do
            {
                Console.Write("\nQUANTI AVVISTAMENTI VUOI INSERIRE?(MAX 20) : ");
            } while (!int.TryParse(Console.ReadLine(), out navv) || navv < 0 || navv > 20);

            for (int i = 1; i <= navv; i++)
            {
                avvistamento = new CAvvistamento();
                Console.WriteLine("AVVISTAMENTO N° " + i);

                do
                {
                    Console.Write("DATA: ");
                } while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out data) || data > DateTime.Now);
                avvistamento.Data = data;

                do
                {
                    Console.Write("LUOGO: ");
                    avvistamento.Luogo = Console.ReadLine();
                } while (avvistamento.Luogo == "");

                do
                {
                    Console.Write("NOTE: ");
                    avvistamento.Note = Console.ReadLine();
                } while (avvistamento.Note == "");


                pennuti[cod].AddAvvist(avvistamento);
            }
            Console.WriteLine("\nAVVISTAMENTI : "+ pennuti[cod].AvvistToString());
        }

        public void CercaMigratori()
        {
            bool tr = false;
            Console.WriteLine("\nRICERCA PER CATEGORIA DI MIGRATORI");
            do
            {
                Console.Write("\n RAPACE -> 0\n CANTERINO -> 1 \n ACQUATICO -> 21\nTIPO PENNUTO :");
                str = Console.ReadLine();
            } while (str != "0" && str != "1" && str != "2");

            if (str == "0")
            {
                foreach (var p in pennuti)
                {
                    if (p is CRapace rapace && p.Migratore)
                    {
                        Console.WriteLine(rapace.ToString());
                        tr = true;
                    }

                }
                    
            }
            else if (str == "1")
            {
                foreach (var pe in pennuti)
                {
                    if (pe is CCanterino canterino && pe.Migratore)
                    {
                        Console.WriteLine(canterino.ToString());
                        tr = true;
                    }
                        
                }
                    
            }
            else
            {
                foreach (var pen in pennuti)
                {
                    if (pen is CAcquatico acquatico && pen.Migratore)
                    {
                        Console.WriteLine(acquatico.ToString());
                        tr = true;
                    }
                        
                }    
            }
            if (!tr)
            {
                Console.WriteLine("NESSUN AVVISTAMENTO");
            }

        }

        public void MostraNCat()
        {
            int rap = 0, can = 0, acq = 0, avv=0;
            Console.WriteLine("\nN° ESEMPLARI PER CATEGORIA: ");
            foreach(var p in pennuti)
            {
                avv += p.Avvistamenti.Count;
                if (p is CRapace) rap++;
                else if (p is CCanterino) can++;
                else acq++;
            }
            Console.WriteLine("RAPACI = "+rap+"\nCANTERINI = "+can+"\nACQUATICI = "+acq);
            Console.WriteLine("AVVISTAMENTI TOT = "+avv);
                   
        }
    }
}
