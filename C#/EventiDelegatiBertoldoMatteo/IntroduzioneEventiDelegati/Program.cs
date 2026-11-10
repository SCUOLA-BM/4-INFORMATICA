using System;
using System.Collections.Generic;
using System.Linq;


namespace IntroduzioneEventiDelegati
{
    internal class Program
    {
        delegate double Operazione(double a, double b);

        static double Addizione(double a, double b) { return a + b;}

        static double Sottrazione(double a, double b) { return a - b; }

        static double Moltiplicazione(double a, double b) { return a * b; }

        static double Divisione(double a, double b) { return (b == 0) ? throw new ArgumentException("Divisione per zero non consentita") : a / b; }

        static void Main(string[] args)
        {
            double a, b;

            do
            {
                Console.WriteLine("Inserisci il primo numero:");
            }
            while (!double.TryParse(Console.ReadLine(), out a));

            do
            {
                Console.WriteLine("Inserisci il secondo numero:");
            }
            while (!double.TryParse(Console.ReadLine(), out b));

            char scelta;

            do
            {
                Console.WriteLine("Scegli un'operazione (1-4):");
                Console.WriteLine("+ Addizione");
                Console.WriteLine("- Sottrazione");
                Console.WriteLine("* Moltiplicazione");
                Console.WriteLine("/ Divisione");
            }
            while (!char.TryParse(Console.ReadLine(), out scelta) || (scelta != '+' && scelta != '-' && scelta != '*' && scelta != '/'));

            Operazione op;

            switch(scelta)
            {
                case '+':
                    Console.WriteLine("Hai scelto l'addizione.");
                    op = Addizione;
                    break;
                case '-':
                    Console.WriteLine("Hai scelto la sottrazione.");
                    op = Sottrazione;
                    break;
                case '*':
                    Console.WriteLine("Hai scelto la moltiplicazione.");
                    op = Moltiplicazione;
                    break;
                case '/':
                    Console.WriteLine("Hai scelto la divisione.");
                    op = Divisione;
                    break;
                default:
                    throw new InvalidOperationException("Operazione non valida.");
                }

            double risultato = EseguiOperazione(a, b, op);
            Console.WriteLine($"Risultato: {risultato}");
        }

        static double EseguiOperazione(double a, double b, Operazione op)
        {
            double risultato = op(a, b);
            return risultato;
        }
    }
}