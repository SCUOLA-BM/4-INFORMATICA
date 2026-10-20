using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCampionato2JsonBM
{
    public class Program
    {
        private const string NomeFile = "partite.json";


        private static void Main()
        {
            IRepository<CPartita> repository = new RepositoryJson<CPartita>(NomeFile);

            try
            {
                repository.Carica();
                Console.WriteLine("Partite caricate: " + repository.GetElenco().Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore nella lettura di " + NomeFile + ": " + ex.Message);
            }

            bool esci = false;
            while (!esci)
            {
                StampaMenu();
                int scelta = LeggiIntero("Scelta: ", 0, 7);

                try
                {
                    if (scelta == 0 || scelta == 7)
                    {
                        esci = true;
                    }
                    else if (scelta == 1)
                    {
                        VisualizzaOrdineNaturale(repository);
                    }
                    else if (scelta == 2)
                    {
                        
                    }
                    else if (scelta == 3)
                    {
                        InserisciPartita(repository);
                    }
                    else if (scelta == 4)
                    {
                        MostraClassifica(repository);
                    }
                    else if (scelta == 5)
                    {
                        CercaSquadra(repository);
                    }
                    else if (scelta == 6)
                    {
                        EliminaPartita(repository);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("OPERAZIONE NON RIUSCITA: " + ex.Message);
                }

                Console.WriteLine();
            }

            Console.WriteLine("Arrivederci!");
        }

        private static void StampaMenu()
        {
            Console.WriteLine(" UEFA MICRONATIONS CHAMPIONCHIP\n");
            Console.WriteLine("1. Visualizza le partite in ordine naturale");
            Console.WriteLine("2. Visualizza le partite con un comparatore");
            Console.WriteLine("3. Inserisci una partita");
            Console.WriteLine("4. Mostra la classifica dei gironi");
            Console.WriteLine("5. Cerca le partite di una squadra");
            Console.WriteLine("6. Elimina una partita");
            Console.WriteLine("7. Esci (tasto 0)");
        }

        // 1. VISUALIZZA IN ORDINE NATURALE

        private static void VisualizzaOrdineNaturale(IRepository<CPartita> repository)
        {
            List<CPartita> copia = new List<CPartita>(repository.GetElenco());
            copia.Sort();
            StampaElenco(copia);
        }

        // 2. ORDINARE CON COMPARATORI

        

        // 3. INSERIMENTO DI UNA PARTITA(gironi/eliminazione, rigoti chiesti solo in caso di pareggio)

        private static void InserisciPartita(IRepository<CPartita> repository)
        {
            Console.WriteLine("Tipo di partita:");
            Console.WriteLine("  1. Fase a gironi");
            Console.WriteLine("  2. Eliminazione diretta");
            Console.WriteLine("  3. Finale (bonus)");
            int tipo = LeggiIntero("Tipo: ", 1, 3);

            int giornata = LeggiIntero("Giornata: ", 1, 100);
            string casa = LeggiTesto("Squadra di casa: ");
            string ospite = LeggiTesto("Squadra ospite: ");

            if (string.Equals(casa, ospite, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Una squadra non puo' giocare contro se stessa.");
                return;
            }

            int golCasa = LeggiIntero("Gol di " + casa + ": ", 0, 99);
            int golOspite = LeggiIntero("Gol di " + ospite + ": ", 0, 99);

            CPartita partita;

            if (tipo == 1)
            {
                partita = new CPartitaGirone(giornata, casa, ospite, golCasa, golOspite);
            }
            else if (tipo == 2)
            {
                int? rigoriCasa = null;
                int? rigoriOspite = null;

                // RIGORI CHIESTI IN CASO DI PARITA'
                if (golCasa == golOspite)
                {
                    Console.WriteLine("Partita in parita': i rigori sono obbligatori.");
                    rigoriCasa = LeggiIntero("Rigori di " + casa + ": ", 0, 99);
                    rigoriOspite = LeggiIntero("Rigori di " + ospite + ": ", 0, 99);
                }

                CPartitaEliminazione eliminazione =
                    new CPartitaEliminazione(giornata, casa, ospite, golCasa, golOspite, rigoriCasa, rigoriOspite);
                eliminazione.VerificaRigori();   // DEVE ESSERCI UN VINCITORE
                partita = eliminazione;
            }
            else
            {
                partita = new CPartitaFinale(giornata, casa, ospite, golCasa, golOspite);
            }

            if (repository.Aggiungi(partita))
            {
                repository.Salva();   // ogni modifica viene salvata subito sul file
                Console.WriteLine("Partita inserita e salvata.");
            }
            else
            {
                Console.WriteLine("Partita gia' presente: stessa giornata e stesse squadre.");
            }
        }

        // 4. CLASSIFICA GIRONI

        private static void MostraClassifica(IRepository<CPartita> repository)
        {
            List<CStatisticheSquadra> classifica = new List<CStatisticheSquadra>();

            foreach (CPartita partita in repository.GetElenco())
            {
                // La classifica considera SOLO le partite dei gironi.
                if (!(partita is CPartitaGirone))
                    continue;

                TrovaOAggiungi(classifica, partita.NomeC).Aggiungi(partita);
                TrovaOAggiungi(classifica, partita.NomeO).Aggiungi(partita);
            }

            if (classifica.Count == 0)
            {
                Console.WriteLine("Non ci sono ancora partite di girone.");
                return;
            }

            classifica.Sort();   // usa IComparable<StatisticheSquadra>.CompareTo

            Console.WriteLine("{0,-4}{1,-20}{2,4}{3,4}{4,4}{5,4}{6,5}{7,5}{8,5}{9,6}",
                "Pos", "Squadra", "G", "V", "P", "S", "GF", "GS", "DR", "Pti");

            int posizione = 1;
            foreach (CStatisticheSquadra riga in classifica)
            {
                Console.WriteLine("{0,-4}{1,-20}{2,4}{3,4}{4,4}{5,4}{6,5}{7,5}{8,5}{9,6}",
                    posizione, riga.Squadra, riga.Giocate, riga.Vinte, riga.Pareggiate, riga.Perse,
                    riga.GolFatti, riga.GolSubiti, riga.DifferenzaReti, riga.Punti);
                posizione++;
            }
        }

        private static CStatisticheSquadra TrovaOAggiungi(List<CStatisticheSquadra> classifica, string squadra)
        {
            foreach (CStatisticheSquadra riga in classifica)
            {
                if (string.Equals(riga.Squadra, squadra, StringComparison.OrdinalIgnoreCase))
                    return riga;
            }

            CStatisticheSquadra nuova = new CStatisticheSquadra(squadra);
            classifica.Add(nuova);
            return nuova;
        }

        // 5. CERCA PARTITE DI UNA SQUADRA

        private static void CercaSquadra(IRepository<CPartita> repository)
        {
            string nome = LeggiTesto("Nome della squadra: ");

            List<CPartita> trovate = new List<CPartita>();
            foreach (CPartita partita in repository.GetElenco())
            {
                bool inCasa = string.Equals(partita.NomeC, nome, StringComparison.OrdinalIgnoreCase);
                bool fuori = string.Equals(partita.NomeO, nome, StringComparison.OrdinalIgnoreCase);
                if (inCasa || fuori)
                    trovate.Add(partita);
            }

            if (trovate.Count == 0)
            {
                Console.WriteLine("Nessuna partita trovata per " + nome + ".");
                return;
            }

            trovate.Sort();   // ordine naturale (giornata, poi squadra di casa)
            Console.WriteLine("Partite trovate per " + nome + ":");
            StampaElenco(trovate);
        }

        // 6. ELIMINA PARTITA

        private static void EliminaPartita(IRepository<CPartita> repository)
        {
            IReadOnlyList<CPartita> elenco = repository.GetElenco();

            if (elenco.Count == 0)
            {
                Console.WriteLine("L'repository e' vuoto.");
                return;
            }

            for (int i = 0; i < elenco.Count; i++)
            {
                Console.WriteLine("  " + (i + 1) + ") " + elenco[i].Descrizione());
            }

            int scelta = LeggiIntero("Numero della partita da eliminare (0 per annullare): ", 0, elenco.Count);
            if (scelta == 0)
            {
                Console.WriteLine("Eliminazione annullata.");
                return;
            }

            if (repository.Rimuovi(elenco[scelta - 1]))
            {
                repository.Salva(); //SALVO NEL JSON MODIFICHE
                Console.WriteLine("Partita eliminata e file aggiornato.");
            }
        }

        private static void StampaElenco(IEnumerable<CPartita> elenco)
        {
            int contatore = 0;
            foreach (CPartita partita in elenco)
            {
                Console.WriteLine("  " + partita.Descrizione());
                contatore++;
            }

            if (contatore == 0)
                Console.WriteLine("  (nessuna partita)");
        }

        private static int LeggiIntero(string messaggio, int minimo, int massimo)
        {
            while (true)
            {
                Console.Write(messaggio);
                string? risposta = Console.ReadLine();

                int valore;
                if (int.TryParse(risposta, out valore) && valore >= minimo && valore <= massimo)
                    return valore;

                Console.WriteLine("Valore non valido: inserire un numero fra " + minimo + " e " + massimo + ".");
            }
        }

        private static string LeggiTesto(string messaggio)
        {
            while (true)
            {
                Console.Write(messaggio);
                string? risposta = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(risposta))
                    return risposta.Trim();

                Console.WriteLine("Il testo non puo' essere vuoto.");
            }
        }
    }
}
