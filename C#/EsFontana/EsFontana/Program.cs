using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks.Sources;

namespace EsFontana
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            int n2;
            float numfloat;
            string manute;
            Console.WriteLine("BENVENUTO IN GESTIONE FONTANE");
            do
            {
                Console.WriteLine("QUANTE STRUTTURE VUOI INSERIRE?");
            } while (!int.TryParse(Console.ReadLine(), out n));

            CFontana[] elenco = new CFontana[n];

            for (int i = 0; i < n; i++)
            {
                try
                {
                    CFontana fontana;
                    do
                    {
                        Console.WriteLine("INSERISCI (PIAZZA->0 / FONTANA->1)");
                    } while (!int.TryParse(Console.ReadLine(), out n2) || n2 < 0 || n2 > 1);


                    if (n2 == 1) fontana = new CFontana();
                    else fontana = new CPiazza();

                    Console.WriteLine("NOME FONTANA : ");
                    fontana.Nome = Console.ReadLine();

                    Console.WriteLine("CONSUMO ACQUA : ");
                    if (!float.TryParse(Console.ReadLine(), out numfloat)) throw new ArgumentException("VALORE ACQUA NON VALIDO\n");
                    else fontana.Cacqua = (float)numfloat;

                    Console.WriteLine("STATO (ATTIVA NOTTE -> 0 SPENTA NOTTE -> 1) : ");
                    if (!int.TryParse(Console.ReadLine(), out n2) || (n2 != 0 && n2 != 1)) throw new ArgumentException("VALORE STATO NON VALIDO");
                    if (n == 1) fontana.Stato = false;

                    do
                    {
                        Console.WriteLine("INSERISCI MANUTENZIONI (0 -> INTERROMPI / 1-> ELIMINA ELENCO) : ");
                        manute = Console.ReadLine();
                        if (manute == "0") break;
                        if (manute == "1") fontana.ElimManute();
                        fontana.AggManute(manute);
                    } while (true);

                    Console.WriteLine("AUTORE FONTANA : ");
                    fontana.Autore = Console.ReadLine();


                    if (fontana is CPiazza piazza)
                    {
                        Console.WriteLine("DIAMETRO : ");
                        if (!float.TryParse(Console.ReadLine(), out numfloat)) throw new ArgumentException("DIAMETRO NON INSERITO\n");
                        else piazza.Diametro = (float)numfloat;

                        Console.WriteLine("CITTA' : ");
                        piazza.Città = Console.ReadLine();

                        Console.WriteLine("NOME : ");
                        piazza.Nome = Console.ReadLine();
                        elenco[i] = piazza;
                    }
                    else elenco[i] = fontana;

                    Console.WriteLine("\nINSERISCI N° GIORNI :");
                    if (!float.TryParse(Console.ReadLine(), out numfloat)) throw new ArgumentException("GIORNI NON INSERITI\n");
                    else Console.WriteLine("LA FONTANA HA CONSUMATO "+fontana.Consumo(numfloat)+" LITRI IN "+numfloat+" GIORNI\n");
                    
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("\nERRORE : " + ex.Message);
                    i--;
                }
            }
            Console.WriteLine(Stampa(elenco, n));
        }

        public static string Stampa(CFontana[] elenco, int lung)
        {
            string str = "ELENCO STRUTTURE\n";
            for(int i=0; i<lung; i++)
            {
                str += "\nSTRUTTURA N° "+(i+1);
                str+= elenco[i].Print();
            }
            return str;
        }
    }
}
