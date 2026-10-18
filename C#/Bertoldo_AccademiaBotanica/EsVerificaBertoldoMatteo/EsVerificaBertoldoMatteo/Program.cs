using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace EsVerificaBertoldoMatteo
{
    internal class Program
    {
        string nome, specie;
        int temperatura, luminosità, umidità, mese, età, umimin, lummin, tempide, totpiante, tottrop, totmed, tottemp, scelta;
        bool foglie;
        List<CHabitat> habitats;
        CHabitat habitat;
        static void Main(string[] args)
        {
            Program p = new Program();
            p.habitats = new List<CHabitat>();
            p.totmed = 0; p.tottemp = 0; p.tottrop = 0;
            Console.WriteLine("BENVENUTO NEL SOFTWARE DI GESTIONE PIANTE DI ERNESTO FLORIS\n");
            try
            {
                do
                {
                    Console.WriteLine("AZIONI DISPONIBILI :");
                } while (p.Input());
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public bool Input()  // MENU' PRINCIPALE
        {
            Console.WriteLine("0 -> ESCI DAL PROGRAMMA");
            Console.WriteLine("1 -> CREA HABITAT");
            Console.WriteLine("2 -> SELEZIONA HABITAT");
            do
            {
                Console.Write("INSERISCI NUMERO DELL' AZIONE CHE VUOI SVOLGERE: ");
            } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta <0 || scelta > 2);

            switch (scelta)
            {
                case 0:
                    return false;
                case 1:
                    AggHabitat();
                    return true;
                case 2:
                    SelHabitat();
                    return true;
                default:
                    Console.WriteLine("ERRORE NEL PROGRAMMA!!");
                    return false;
            }
            
        }

        public bool DuplicatiH(CHabitat habitat)  // CONTROLLO SE SONO PRESENTI DUPLICATI
        {
            foreach (CHabitat h in habitats)
            {
                if (h.Equals(habitat)) return true;
            }
            return false;
        }

        public bool CercaNomeHabitat(string nome)  // CERCO HABITAT PER NOME
        {
            foreach(CHabitat h in habitats)
            {
                if (h.Nome == nome) return true;
            }
            return false;
        }

        public CHabitat RicercaHabitat(string nome)  // RESTITUISCE HABITAT DATO IL NOME
        {
            foreach (CHabitat h in habitats)
            {
                if (h.Nome == nome) return h;
            }
            return null;
        }

        public void AggHabitat()  // CREA UN NUOVO HABITAT
        {
            Console.WriteLine("CREAZIONE HABITAT...");
            do
            {
                Console.Write("NOME: ");
                nome = Console.ReadLine();
            } while (nome == "" || CercaNomeHabitat(nome));

            do
            {
                Console.Write("TEMPERATURA: ");
            } while (!int.TryParse(Console.ReadLine(), out temperatura) || temperatura < -5 || temperatura > 35);

            do
            {
                Console.Write("LUMINOSITA': ");
            } while (!int.TryParse(Console.ReadLine(), out luminosità) || luminosità < 0 || luminosità > 100);

            do
            {
                Console.Write("UMIDITA': ");
            } while (!int.TryParse(Console.ReadLine(), out umidità) || umidità < 0 || umidità > 100);

            do
            {
                Console.Write("MESE CORRENTE': ");
            } while (!int.TryParse(Console.ReadLine(), out mese) || mese < 1 || mese > 12);

            CHabitat h = new CHabitat(nome, temperatura, luminosità, umidità, mese);
            if (DuplicatiH(h)) Console.WriteLine("TENTATIVO DI DUPLICAGGIO");
            else habitats.Add(h);
        }

        public void SelHabitat()  // SELEZIONA UN HABITAT
        {
            habitats.Sort();
            foreach(var h in habitats)
            {
                Console.WriteLine(h.Print());
            }
            do
            {
                Console.Write("NOME HABITAT DA SELEZIONARE: ");
                nome = Console.ReadLine();
            } while (!CercaNomeHabitat(nome));
            habitat = RicercaHabitat(nome);
            while (AzioniHabitat());
        }

        public bool AzioniHabitat()  // MENU' AZIONI HABITAT
        {
            Console.WriteLine("0 -> ESCI DA AZIONI HABITAT");
            Console.WriteLine("1 -> AGGIUNGI PIANTA");
            Console.WriteLine("2 -> RIMUOVI PIANTA");
            Console.WriteLine("3 -> VISUALIZZA PIANTE");
            Console.WriteLine("4 -> MODIFICA VALORI SENSORI E MESE");
            Console.WriteLine("5 -> ESEGUIRE CONTROLLO GENERALE");
            Console.WriteLine("6 -> CERCA PIANTA");
            do
            {
                Console.Write("INSERISCI NUMERO DELL' AZIONE CHE VUOI SVOLGERE: ");
            } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta > 6);

            switch (scelta)
            {
                case 0:
                    return false;
                case 1:
                    AggPianta();
                    return true;
                case 2:
                    RimPianta();
                    return true;
                case 3:
                    PrintPiante();
                    return true;
                case 4:
                    Modifica();
                    return true;
                case 5:
                    ControlloG();
                    return true;
                case 6:
                    CercaPianta();
                    return true;
                default:
                    Console.WriteLine("ERRORE NEL PROGRAMMA!!");
                    return false;
            }
        }

        public bool RicercaPianta(string n)  // VERIFICA LA PRESENZA DI QUESTA PIANTA ATTRAVERSO IL NOME
        {
            foreach (CPianta p in habitat.Piante)
            {
                if (p.Nome == n) return true;
            }
            return false;
        }

        public CPianta RestituisciPianta(CPianta p)  // RESTITUISCE LA PIANTA UGUALE A P
        {
            foreach (CPianta x in habitat.Piante)
            {
                if (x.Equals(p)) return x;
            }
            return null;
        }

        public bool DuplicatiP(CPianta pianta)  // CONTROLLA SE PIANTA E' DUPLICATA
        {
            foreach (CPianta p in habitat.Piante)
            {
                if (p.Equals(pianta)) return true;
            }
            return false;
        }

        public void AggPianta()  // AGGIUNGE UNA PIANTA
        {
            Console.WriteLine("1 -> TROPICALE");
            Console.WriteLine("2 -> TEMPERATA");
            Console.WriteLine("3 -> MEDITERRANEA");
            do
            {
                Console.Write("INSERISCI TIPO PIANTA DA CREARE: ");
            } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > 3);

            string str = "";
            Console.WriteLine("CREAZIONE PIANTA...");
            do
            {
                Console.Write("NOME: ");
                nome = Console.ReadLine();
            } while (nome == "");

            do
            {
                Console.Write("SPECIE: ");
                specie = Console.ReadLine();
            } while (specie == "");

            do
            {
                Console.Write("ETA': ");
            } while (!int.TryParse(Console.ReadLine(), out età) || età < -5 || età > 35);

            do
            {
                Console.Write("FOGLIE' (SI/NO): ");
                str = Console.ReadLine();
            } while (str != "SI" && str != "NO");
            foglie = str == "SI";

            switch (scelta)
            {
                case 1:

                    do
                    {
                        Console.Write("UMIDITA' MIN: ");
                    } while (!int.TryParse(Console.ReadLine(), out umimin) || umimin < 0 || umimin > 100);
                    CTropicale trop = new CTropicale(nome, età, foglie, umimin);
                    if (DuplicatiP(trop)) Console.WriteLine("TENTATIVO DI DUPLICAZIONE");
                    else
                    {
                        habitat.AddPianta(trop);
                        tottrop++;
                    }
                    break;
                case 2:
                    do
                    {
                        Console.Write("TEMPERATURA IDEALE: ");
                    } while (!int.TryParse(Console.ReadLine(), out tempide) || tempide < -5 || tempide > 35);
                    CTemperata temp = new CTemperata(nome, età, foglie, tempide);

                    if (DuplicatiP(temp)) Console.WriteLine("TENTATIVO DI DUPLICAZIONE");
                    else
                    {
                        habitat.AddPianta(temp);
                        tottemp++;
                    }
                    break;
                case 3:
                    do
                    {
                        Console.Write("LUMINOSITA' MIN: ");
                    } while (!int.TryParse(Console.ReadLine(), out lummin) || lummin < -5 || lummin > 35);
                    CMediterranea med = new CMediterranea(nome, età, foglie, lummin);

                    if (DuplicatiP(med)) Console.WriteLine("TENTATIVO DI DUPLICAZIONE");
                    else
                    {
                        habitat.AddPianta(med);
                        totmed++;
                    }
                    break;
                default:
                    Console.WriteLine("ERRORE NEL PROGRAMMA!!");
                    return;
            }
        }

        public void PrintPiante()  // MOSTRA ELENCO DI PIANTE DELL'HABITAT CORRENTE
        {
            habitat.Piante.Sort();
            foreach(CPianta p in habitat.Piante)
            {
                Console.WriteLine(p.Print());
            }
        }

        public void RimPianta()  // RIMUOVE UNA PIANTA
        {
            habitat.Piante.Sort();
            PrintPiante();
            Console.WriteLine("PIANTA DA RIMUOVERE");
            do
            {
                Console.Write("NOME: ");
                nome = Console.ReadLine();
            } while (!RicercaPianta(nome));

            do
            {
                Console.WriteLine("\n1 -> TROPICALE");
                Console.WriteLine("2 -> TEMPERATA");
                Console.WriteLine("3 -> MEDITERRANEA");
                Console.Write("SPECIE:");
            } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > 3);
            switch (scelta)
            {
                case 1:
                    CTropicale trop = new CTropicale(nome,1,true,0);
                    if (DuplicatiP(trop))
                    {
                        tottrop--;
                        habitat.Piante.Remove(trop);
                    }
                    else Console.WriteLine("Elemento non trovato");
                    break;
                case 2:
                    CTemperata temp = new CTemperata(nome, 1, true, 0);
                    if (DuplicatiP(temp))
                    {
                        tottemp--;
                        habitat.Piante.Remove(temp);
                    }
                    else Console.WriteLine("Elemento non trovato");
                    break;
                case 3:
                    CMediterranea med = new CMediterranea(nome, 1, true, 0);
                    if (DuplicatiP(med))
                    {
                        totmed--;
                        habitat.Piante.Remove(med);
                    }
                    else Console.WriteLine("Elemento non trovato");
                    break;
            }
        }

        public void Modifica()  // MODIFICA DATI DEI SENSORI E MESE
        {
            Console.WriteLine("MODIFICA HABITAT...");

            do
            {
                Console.Write("TEMPERATURA: ");
            } while (!int.TryParse(Console.ReadLine(), out temperatura) || temperatura < -5 || temperatura > 35);

            do
            {
                Console.Write("LUMINOSITA': ");
            } while (!int.TryParse(Console.ReadLine(), out luminosità) || luminosità < 0 || luminosità > 100);

            do
            {
                Console.Write("UMIDITA': ");
            } while (!int.TryParse(Console.ReadLine(), out umidità) || umidità < 0 || umidità > 100);

            do
            {
                Console.Write("MESE CORRENTE': ");
            } while (!int.TryParse(Console.ReadLine(), out mese) || mese < 1 || mese > 12);

            CCondAmb nuovo = new CCondAmb(temperatura, umidità, luminosità, mese);
            if (habitat.c.Equals(nuovo)) Console.WriteLine("Nessuna variazione nelle condizioni ambientali");
            else
            {
                habitat.c.Temperatura = temperatura;
                habitat.c.Umidità = umidità;
                habitat.c.Luminosità = luminosità;
                habitat.c.Mese = mese;
            }
        }

        public void ControlloG()  // CONTROLLO GENERALE E STAMPA STATISTICHE
        {
            int tot = totmed + tottemp + tottrop;
            foreach(CHabitat h in habitats)
            {
                h.Piante.Sort();
                foreach (CPianta p in h.Piante)
                {
                    Console.WriteLine(p.ControlloGen(h.c));
                    if (!p.CondAmb(h.c)) tot--;
                }
            }
            Console.WriteLine("\nSTATISTICHE PIANTE: ");
            Console.WriteLine("TOTALI: " + (totmed + tottemp + tottrop));
            Console.WriteLine("ADEGUATE: " + tot);
            Console.WriteLine("TROPICALI: " + tottrop);
            Console.WriteLine("MEDITERRANEE : " + totmed);
            Console.WriteLine("TEMPERATE : " + tottemp);
            Console.WriteLine("PRIMA PIANTA:" + habitats[0].Piante[0].Print());
            Console.WriteLine("ULTIMA PIANTA:" + habitats[habitats.Count - 1].Piante[habitats[habitats.Count-1].Piante.Count-1].Print());

        }

        public void CercaPianta()  // CERCA UNA PIANTA E SE ESISTE STAMPA LA SUA DESCRIZIONE
        {
            habitat.Piante.Sort();
            Console.WriteLine("PIANTA DA CERCARE");
            do
            {
                Console.Write("NOME: ");
                nome = Console.ReadLine();
            } while (!RicercaPianta(nome));

            do
            {
                Console.WriteLine("\n1 -> TROPICALE");
                Console.WriteLine("2 -> TEMPERATA");
                Console.WriteLine("3 -> MEDITERRANEA");
                Console.Write("SPECIE:");
            } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > 3);
            switch (scelta)
            {
                case 1:
                    CTropicale trop = new CTropicale(nome, 1, true, 0);
                    if (DuplicatiP(trop))
                    {
                        Console.WriteLine("\nPIANTA TROVATA");
                        Console.WriteLine("\nDESCRIZIONE: ");
                        Console.WriteLine(RestituisciPianta(trop).Print());
                    }
                    else Console.WriteLine("Elemento non trovato");
                    break;
                case 2:
                    CTemperata temp = new CTemperata(nome, 1, true, 0);
                    if (DuplicatiP(temp))
                    {
                        Console.WriteLine("\nPIANTA TROVATA");
                        Console.WriteLine("\nDESCRIZIONE: ");
                        Console.WriteLine(RestituisciPianta(temp).Print());
                    }
                    else Console.WriteLine("Elemento non trovato");
                    break;
                case 3:
                    CMediterranea med = new CMediterranea(nome, 1, true, 0);
                    if (DuplicatiP(med))
                    {
                        Console.WriteLine("\nPIANTA TROVATA");
                        Console.WriteLine("\nDESCRIZIONE: ");
                        Console.WriteLine(RestituisciPianta(med).Print());
                    }
                    else Console.WriteLine("Elemento non trovato");
                    break;
            }
        }
    }
}
