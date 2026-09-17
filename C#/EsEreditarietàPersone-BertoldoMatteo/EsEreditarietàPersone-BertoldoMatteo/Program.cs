namespace EsEreditarietàPersone_BertoldoMatteo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int max;

            int scelta = 0;


            Console.WriteLine("BENVENUTO NEL MIO PROGRAMMA GESTIONE SCOLASTICA");
            //chiedi quante persone si vuole inserire e fai for inserimento persone specificando il tipo di persona con try catch e alla fine stampa elenco
            do
            {
                Console.WriteLine("Quante persone vuoi inserire?");
            } while (!int.TryParse(Console.ReadLine(), out max));

            CElencoPersone elenco = new CElencoPersone(max);

            for (int i = 0; i<max; i++)
            {
                try
                {
                    CPersona persona;
                    do
                    {
                        Console.WriteLine("INSERISCI (PERSONA->0 / STUDENTE->1 / DOCENTE->2)");
                    } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta > 2);


                    if (scelta == 1) persona = new CStudente();
                    else if (scelta == 2) persona = new CDocente();
                    else persona = new CPersona();

                    Console.WriteLine("CODICE FISCALE : ");
                    persona.CodFiscale = Console.ReadLine();

                    Console.WriteLine("NOME : ");
                    persona.Nome = Console.ReadLine();

                    Console.WriteLine("COGNOME : ");
                    persona.Cognome = Console.ReadLine();



                    if (persona is CStudente studente)
                    {
                        Console.WriteLine("MATRICOLA : ");
                        studente.Matricola = Console.ReadLine();
                        Console.WriteLine("UNIVERSITA' : ");
                        studente.Università = Console.ReadLine();
                    }
                    else if (persona is CDocente docente)
                    {
                        float salario = 0.0f;
                        Console.WriteLine("MATERIA : ");
                        docente.Materia = Console.ReadLine();
                        Console.WriteLine("SALARIO' : ");
                        if (!float.TryParse(Console.ReadLine(), out salario)) throw new ArgumentException("SALARIO NON INSERITO\n");
                        else docente.Salario = salario;
                    }
                    elenco.Add(persona);

                }catch(ArgumentException ex)
                {
                    Console.WriteLine("\nERRORE : "+ex.Message);
                    i--;
                }
            }
            Console.WriteLine("\nELENCO DI TUTTE LE PERSONE: \n");
            Console.WriteLine(elenco.Print()+"\n");
            Console.WriteLine("N° STUDENTI : "+ elenco.ContaStudenti()+"\n");
            Console.WriteLine(elenco.StampaDocentiConStipendioAlto(2000));

        }
    }
}
