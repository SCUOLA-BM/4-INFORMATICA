using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsPreVerificaMultimediali_BM
{
    internal class Program
    {
        string titolo = "";
        int volume = 0, luminosità = 0, durata = 0, n = 0;
        public CMultimediale[] array;
        static void Main(string[] args)
        {
            Program p = new Program();
            try
            {
                p.Input();
                do
                {
                    p.Scelte();
                } while (true);
                
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public void Input()
        {
            array = new CMultimediale[5];
            for(int i = 0; i < 5; i++)
            {
                do
                {
                    Console.WriteLine("INSERISCI ELEMENTO MULTIMEDIALE");
                    Console.WriteLine("1 -> AUDIO");
                    Console.WriteLine("2 -> FILMATO");
                    Console.WriteLine("3 -> IMMAGINE");
                } while (!int.TryParse(Console.ReadLine(), out n) || n<1 || n>3);

                Console.WriteLine("ELEMENTO N° "+ (i+1));

                do
                {
                    Console.Write("INSERISCI TITOLO: ");
                    titolo = Console.ReadLine();
                } while (titolo == "");

                if (n != 3)
                {
                    
                }

                switch (n)
                {
                    case 1:
                        DurataVolume();
                        CAudio audio = new CAudio(titolo, durata, volume);
                        array[i] = audio;
                        break;
                    case 2:
                        DurataVolume();
                        Luminosità();
                        CFilmato filmato = new CFilmato(titolo, durata, volume, luminosità);
                        array[i] = filmato;
                        break;
                    case 3:
                        Luminosità();
                        CImmagine immagine = new CImmagine(titolo, luminosità);
                        array[i] = immagine;
                        break;
                    default:
                        Console.WriteLine("ERRORE NEL PROGRAMMA!!");
                        return;
                }
            }
        }


        public void DurataVolume()
        {
            do
            {
                Console.Write("DURATA: ");
            } while (!int.TryParse(Console.ReadLine(), out durata) || durata < 0 || durata > 30);

            do
            {
                Console.Write("VOLUME: ");
            } while (!int.TryParse(Console.ReadLine(), out volume) || volume <0 || volume > 20);
        }

        public void Luminosità()
        {
            do
            {
                Console.Write("LUMINOSITA': ");
            } while (!int.TryParse(Console.ReadLine(), out luminosità) || luminosità < 0 || luminosità > 10);
        }

        public void Scelte()
        {
            Console.WriteLine("1 -> ESEGUIRE ELEMENTO MULTIMEDIALE");
            Console.WriteLine("2 -> REGOLARE PARAMETRI");
            Console.WriteLine("3 -> FILMATI DURATA INFERIORE INSERITA");
            Console.WriteLine("4 -> ORDINARE PER TITOLO");
            Console.WriteLine("5 -> VERIFICARE FILM UGUALI");

            do
            {
                Console.Write("INSERIRE NUMERO AZIONE CHE VUOI SVOLGERE : ");
            } while (!int.TryParse(Console.ReadLine(), out n) || n<1 || n>5);

            switch (n)
            {
                case 1:
                    Esegui();
                    break;
                case 2:
                    Parametri();
                    break;
                case 3:
                    FilmatiDurataInf();
                    break;
                case 4:
                    OrdinaPerTitolo();
                    break;
                case 5:
                    FilmUguali();
                    break;
            }
            
        }

        public void Print()
        {
            int i = 0;
            foreach(var e in array)
            {
                i++;
                Console.WriteLine("N° "+i);
                Console.WriteLine(e.Print());
            }
        }

        public int Elemento()
        {
            do
            {
                Print();
                Console.Write("INSERIRE ELEMENTO(1-5): ");
            } while (!int.TryParse(Console.ReadLine(), out n) || n < 1 || n > 5);
            return n;
        }

        public void Esegui()
        {
            n = Elemento();

            if (array[n-1] is CImmagine i)
            {
                Console.WriteLine(i.Show());
            }
            else if (array[n-1] is CAudio a)
            {
                Console.WriteLine(a.Play());
            }
            else if (array[n-1] is CFilmato f)
            {
                Console.WriteLine(f.Play());
            }
        }

        public void Parametri()
        {
            n = Elemento();
            if (array[n] is CImmagine i)
            {
                do
                {
                    Console.Write("Luminosità (0 -> NIENTE / 1 -> AUMENTA / 2 -> DIMINUISCI) : ");
                } while (!int.TryParse(Console.ReadLine(), out n) || n < 0 || n > 2);
                
                if(n == 1)
                {
                    do
                    {
                        Console.Write("AUMETA LUMINOSITA' DI : ");
                    } while (!int.TryParse(Console.ReadLine(), out n) || n < 0 || n > 100);
                    i.Brighter(n);
                }
                else if(n == 2)
                {
                    do
                    {
                        Console.Write("DIMINUISCI LUMINOSITA' DI : ");
                    } while (!int.TryParse(Console.ReadLine(), out n) || n < 0 || n > 100);
                    i.Darker(n);
                }
                Console.WriteLine(i.Print());

            }
            else if (array[n] is CAudio a)
            {
                do
                {
                    Console.Write("VOLUME (0 -> NIENTE / 1 -> AUMENTA / 2 -> DIMINUISCI) : ");
                } while (!int.TryParse(Console.ReadLine(), out n) || n < 0 || n > 2);

                if (n == 1)
                {
                    do
                    {
                        Console.Write("AUMETA VOLUME' DI : ");
                    } while (!int.TryParse(Console.ReadLine(), out n) || n < 0 || n > 100);
                    a.Louder(n);
                }
                else if (n == 2)
                {
                    do
                    {
                        Console.Write("DIMINUISCI VOLUME' DI : ");
                    } while (!int.TryParse(Console.ReadLine(), out n) || n < 0 || n > 100);
                    a.Weaker(n);
                }
                Console.WriteLine(a.Print());
            }
            else if (array[n] is CFilmato f)
            {
                do
                {
                    Console.Write("LUMINOSITA' (0 -> NIENTE / 1 -> AUMENTA / 2 -> DIMINUISCI) : ");
                } while (!int.TryParse(Console.ReadLine(), out n) || n < 0 || n > 2);

                if (n == 1)
                {
                    do
                    {
                        Console.Write("AUMETA LUMINOSITA' DI : ");
                    } while (!int.TryParse(Console.ReadLine(), out n) || n < 0 || n > 100);
                    f.Brighter(n);
                }
                else if (n == 2)
                {
                    do
                    {
                        Console.Write("DIMINUISCI LUMINOSITA' DI : ");
                    } while (!int.TryParse(Console.ReadLine(), out n) || n < 0 || n > 100);
                    f.Darker(n);
                }

                do
                {
                    Console.Write("VOLUME (0 -> NIENTE / 1 -> AUMENTA / 2 -> DIMINUISCI) : ");
                } while (!int.TryParse(Console.ReadLine(), out n) || n < 0 || n > 2);

                if (n == 1)
                {
                    do
                    {
                        Console.Write("AUMETA VOLUME' DI : ");
                    } while (!int.TryParse(Console.ReadLine(), out n) || n < 0 || n > 100);
                    f.Louder(n);
                }
                else if (n == 2)
                {
                    do
                    {
                        Console.Write("DIMINUISCI VOLUME' DI : ");
                    } while (!int.TryParse(Console.ReadLine(), out n) || n < 0 || n > 100);
                    f.Weaker(n);
                }
                Console.WriteLine(f.Print());
            }
        }

        public void FilmatiDurataInf()
        {
            do
            {
                Console.Write("INSERISCI DURATA MASSIMA (max 300): ");
            } while (!int.TryParse(Console.ReadLine(), out n) || n < 0 || n > 300);

            foreach(var e in array) 
                if (e is CFilmato f && f.Durata < n) 
                        Console.WriteLine(f.Print());
        }

        public void OrdinaPerTitolo() => Array.Sort(array);

        public void FilmUguali()
        {
            do
            {
                Print();
                Console.Write("INSERIRE PRIMO FILM(1-5): ");
            } while (!int.TryParse(Console.ReadLine(), out n) || n < 1 || n > 5);

            if(array[n] is CFilmato f)
            {
                do
                {
                    Print();
                    Console.Write("INSERIRE SECONDO FILM(1-5): ");
                } while (!int.TryParse(Console.ReadLine(), out n) || n < 1 || n > 5);
                if (array[n] is CFilmato f2)
                {
                    Console.WriteLine( f.Equals(f2) ? "FILMATI UGUALI" : "FILMATI DIVERSI");
                }
            }

            


        }
    }
}
