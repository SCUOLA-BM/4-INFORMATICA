using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace EsRipassoRobotBertoldoMatteo
{
    internal class Program
    {
        public bool valido;
        public int n, stato, anno;
        public string modello, str;
        public float potenza;
        public CRobot robot;
        public List<CRobot> listaRob = new List<CRobot>();
        public List<CRobot> listaRobOrdinata = new List<CRobot>();
        static void Main(string[] args)
        {
            Program prog= new Program();
            Console.WriteLine("Benvenuto nel nostro registro robot!");
            prog.AggiungiRobot();
            Console.WriteLine(prog.Operativi());
            Console.WriteLine(prog.FiltroPot());
            Console.WriteLine(prog.OrdinaAnno());

        }

        //aggiunge robot alla lista
        public void AggiungiRobot()
        {
            valido = true;
            modello = "";
            do
            {
                Console.WriteLine("Quanti robot vuoi registrare?(max 100)");
            } while (!int.TryParse(Console.ReadLine(), out n) || n < 1 || n > 100);

            for (int i = 1; i <= n; i++){
                Console.WriteLine("\nROBOT N° " + i);
                do
                {
                    Console.Write("Modello : ");
                    modello = Console.ReadLine();
                } while (modello == "");

                do
                {
                    Console.Write("Potenza : ");
                } while (!float.TryParse(Console.ReadLine(), out potenza) || potenza <= 0);

                do
                {
                    Console.Write("Stato : ");
                } while (!int.TryParse(Console.ReadLine(), out stato) || stato < 0);

                do
                {
                    Console.Write("Anno : ");
                } while (!int.TryParse(Console.ReadLine(), out anno) || anno < 2000 || anno > DateTime.Now.Year);

                robot = new CRobot(modello, potenza, stato, anno);

                listaRob.Add(robot);

            }
        }

        //stampa robot operativi
        public string Operativi()
        {
            n = 1;
            str = "\nROBOT OPERATIVI\n";
            foreach(CRobot rob in listaRob)
            {
                str+="\nROBOT N° " + n;
                if (rob.Stato() > 0)
                {
                    str +="\n"+ rob.Print()+"\n";
                }
                else
                {
                    str += "\nnon operativo"+"\n";
                }
                n++;
            }
            return str;
        }

        //filtro per potenza
        public string FiltroPot()
        {
            str = "";
            float pot = 0;
            n = 1;
            do
            {
                Console.Write("Potenza massima: ");
            } while (!float.TryParse(Console.ReadLine(), out pot) || pot <= 0);
            foreach (CRobot rob in listaRob)
            {
                str += "\nROBOT N° " + n;
                if (rob.Potenza() <= pot)
                {
                    str += "\n" + rob.Print() + "\n";
                }
                else
                {
                    str += "\npotenza maggiore" + "\n";
                }
                n++;
            }
            return str;
        }

        public string OrdinaAnno()
        {
            str = "ORDINE ROBOT PER ANNO\n";
            int lung = listaRob.Count;
            for (int i= 0; i < lung; i++)
            {
                n = 0;
                for (int j=0; j < listaRob.Count; j++)
                {
                    if (listaRob[j].Anno() <= listaRob[n].Anno()) n = j;
                }
                listaRobOrdinata.Add(listaRob[n]);
                listaRob.RemoveAt(n);
                
            }
            n = 0;
            foreach (CRobot rob in listaRobOrdinata)
            {
                n++;
                str += "\nROBOT N° " + n;
                str += "\n"+rob.Print()+"\n";
            }
            str += "\nROBOT PIU' RECENTE\n" + listaRobOrdinata[listaRobOrdinata.Count - 1].Print();
            return str;
        }

    }
}
