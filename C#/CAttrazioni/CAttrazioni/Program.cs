using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EsAttrazioniBM
{
    internal class Program
    {
        public static CAttrazione attrazione;
        public static CConcerto concerto;
        public static CGiostra giostra;
        public static CMostra mostra;

        public static float numfloat;
        public static int numint;
        public static string opera;
        public static TimeSpan ora;
        public static CAttrazione[] elenco;
        static void Main(string[] args)
        {
            elenco = new CAttrazione[6];
            

            for(int i = 0; i<6; i++)
            {
                try
                {
                    Attrazioni(i);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    i--;
                }
                
            }

            Console.WriteLine("\nMOSTRE DI MARIETTO : ");
            bool find = false;
            foreach (var i in elenco)
            {
                if (i is CMostra mostra && mostra.Autore == "Marietto")
                {
                    Console.WriteLine("\n" + mostra.Nome);
                    find = true;
                }
            }
            if (!find) Console.WriteLine("NESSUNA MOSTRA");

            Console.WriteLine("\nATTRAZIONI: ");

            foreach (var i in elenco)
            {
                Console.WriteLine(i.Info());
            }
        }

        public static void Attrazioni(int n)
        {
            
            switch (n/2)
            {
                case 0:
                    Console.WriteLine("\n     INSERISCI CONCERTO  ");
                    attrazione = new CConcerto();
                    break;
                case 1:
                    Console.WriteLine("\n     INSERISCI GIOSTRA  ");
                    attrazione = new CGiostra();
                    break;
                case 2:
                    Console.WriteLine("\n     INSERISCI MOSTRA   ");
                    attrazione = new CMostra();
                    break;
            }

            Console.Write("NOME: ");
            attrazione.Nome = Console.ReadLine();

            Console.Write("COSTO: ");
            if (!float.TryParse(Console.ReadLine(), out numfloat)) throw new ArgumentException("COSTO NON VALIDO\n");
            else attrazione.Costo = numfloat;

            if(attrazione is CConcerto concerto)
            {
                Console.Write("ORA INIZIO (formato HH:mm): ");
                if (!TimeSpan.TryParseExact(Console.ReadLine(),@"hh\:mm",null, out ora)) throw new ArgumentException("FORMATO ORA NON VALIDO!\n");
                concerto.OraInizio = ora;

                Console.Write("NUM POSTI: ");
                if (!int.TryParse(Console.ReadLine(), out numint)) throw new ArgumentException("NUM POSTI NON VALIDO\n");
                concerto.NumPosti = numint;

                elenco[n] = concerto;
            }
            else if (attrazione is CGiostra giostra)
            {
                Console.Write("NUM POSTI: ");
                if (!int.TryParse(Console.ReadLine(), out numint)) throw new ArgumentException("NUM POSTI NON VALIDO\n");
                else giostra.NumPosti = numint;

                Console.Write("TEMA: ");
                giostra.Tema = Console.ReadLine();

                elenco[n] = giostra;
            }
            else if(attrazione is CMostra mostra)
            {
                Console.Write("AUTORE: ");
                mostra.Autore = Console.ReadLine();

                Console.WriteLine("INSERISCI OPERA (0 -> INTERROMPI) : ");
                do
                {
                    opera = Console.ReadLine();
                    if (opera == "0") break;
                    if (opera == "")
                    {
                        Console.WriteLine("OPERA NON VALIDA");
                        continue;
                    }
                    mostra.AddOpere(opera);
                } while (true);

                elenco[n] = mostra;
            }
        }
    }
}
