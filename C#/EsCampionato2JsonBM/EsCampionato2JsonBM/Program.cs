using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCampionato2JsonBM
{
    internal class Program
    {
        private const string NomeFile = "partite.json";


        private static void Main()
        {
            CRepositoryPartite repository = new CRepositoryPartite(NomeFile);

            try
            {
                repository.Carica();
                Console.WriteLine("PARTITE CARICATE: " + repository.GetElenco().Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERRORE DI LETTURA DI " + NomeFile + ": " + ex.Message);
            }

            bool esci = false;
            while (!esci)
            {
                StampaMenu();
                int scelta = LeggiIntero("SCELTA: ", 0, 6);

                try
                {
                    if (scelta == 0)
                    {
                        esci = true;
                    }
                    else if (scelta == 1)
                    {
                        VisualizzaOrdineNaturale(repository);
                    }
                    else if (scelta == 2)
                    {
                        VisualizzaPartiteOrdinate(repository);
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
            Console.WriteLine("0. Esci");
        }

        // 1. VISUALIZZA IN ORDINE NATURALE

        private static void VisualizzaOrdineNaturale(CRepositoryPartite r)
        {
            CPartita.Criterio = "naturale";   // FORZO L'ORDINE NATURALE (IL CRITERIO E' STATICO)
            List<CPartita> copia = new List<CPartita>(r.GetElenco());

            copia.Sort();
            StampaElenco(copia);
        }

        // 2. ORDINARE CON COMPARATORI

        private static void VisualizzaPartiteOrdinate(CRepositoryPartite r)
        {
            Console.WriteLine("TIPO ORDINAMENTO:");
            Console.WriteLine("1. NATURALE");
            Console.WriteLine("2. GOAL DECRESCENTE");
            Console.WriteLine("3. SCARTO VITTORIA DECRESCENTE");
            Console.WriteLine("4. SQUADRA DI CASA (A-Z)");
            Console.WriteLine("5. SQUADRA DI CASA (Z-A)");
            Console.WriteLine("6. DATA");
            int tipo = LeggiIntero("TIPO: ", 1, 6);
            List<CPartita> copia = new List<CPartita>(r.GetElenco());


            switch (tipo)
            {
                case 1:
                    CPartita.Criterio = "naturale";
                    break;
                case 2:
                    CPartita.Criterio = "gol";
                    break;
                case 3:
                    CPartita.Criterio = "scarto";
                    break;
                case 4:
                    CPartita.Criterio = "casaAZ";
                    break;
                case 5:
                    CPartita.Criterio = "casaZA";
                    break;
                case 6:
                    CPartita.Criterio = "data";
                    break;
                default:
                    throw new ArgumentException("ERRORE NELLA SCELTA DELL'ORDINAMENTO");
            }
            copia.Sort();
            StampaElenco(copia);
        }


        // 3. INSERIMENTO DI UNA PARTITA(gironi/eliminazione, rigoti chiesti solo in caso di pareggio)

        private static void InserisciPartita(CRepositoryPartite repository)
        {
            Console.WriteLine("TIPO PARTITA:");
            Console.WriteLine("1. FASE GIRONI");
            Console.WriteLine("2. ELIMINAZIONE DIRETTA");
            Console.WriteLine("3. FINALE (bonus)");
            int tipo = LeggiIntero("TIPO: ", 1, 3);

            int g = LeggiIntero("Giornata: ", 1, 100);
            string casa = LeggiTesto("Squadra di casa: ");
            string ospite = LeggiTesto("Squadra ospite: ");

            if (casa.ToUpper().Trim() == ospite.ToUpper().Trim())
            {
                Console.WriteLine("IMPOSSIBILE AVERE SQUADRE CON LO STESSO NOME");
                return;
            }

            int goalc = LeggiIntero("GOAL DI " + casa + ": ", 0, 99);
            int goalo = LeggiIntero("GOAL DI " + ospite + ": ", 0, 99);

            // DATA DELLA PARTITA (OPZIONALE, INVIO PER SALTARE)
            DateTime? dataPartita = LeggiData("Data della partita (dd/MM/yyyy, Invio per saltare): ");

            CPartita partita;

            if (tipo == 1)
            {
                partita = new CPartitaGirone(g, casa, ospite, goalc, goalo, dataPartita);
            }
            else if (tipo == 2)
            {
                int? rigoriCasa = null;
                int? rigoriOspite = null;

                // RIGORI CHIESTI IN CASO DI PARITA'
                if (goalc == goalo)
                {
                    Console.WriteLine("PARTITA IN PARITA', RIGORI OBBLIGATORI.");
                    rigoriCasa = LeggiIntero("RIGORI DI " + casa + ": ", 0, 99);
                    rigoriOspite = LeggiIntero("RIGORI DI " + ospite + ": ", 0, 99);
                }

                CPartitaEliminazione eliminazione =
                    new CPartitaEliminazione(g, casa, ospite, goalc, goalo, rigoriCasa, rigoriOspite, dataPartita);
                eliminazione.VerificaRigori();   // DEVE ESSERCI UN VINCITORE
                partita = eliminazione;
            }
            else
            {
                partita = new CPartitaFinale(g, casa, ospite, goalc, goalo, dataPartita);
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

        private static void MostraClassifica(CRepositoryPartite repository)
        {
            List<CStatisticheSquadra> classifica = new List<CStatisticheSquadra>();

            foreach (CPartita partita in repository.GetElenco())
            {
                // LA CLASSIFICA CONSIDERA SOLO GIRONI.
                if (!(partita is CPartitaGirone))
                    continue;

                TrovaOAggiungi(classifica, partita.SquadraCasa).Aggiungi(partita);
                TrovaOAggiungi(classifica, partita.SquadraOspite).Aggiungi(partita);
            }

            if (classifica.Count == 0)
            {
                Console.WriteLine("Non ci sono ancora partite di girone.");
                return;
            }

            classifica.Sort();   // USA IComparable<CStatisticheSquadra>.CompareTo

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
                if (riga.Squadra.ToUpper().Trim() == squadra.ToUpper().Trim())
                    return riga;
            }

            CStatisticheSquadra nuova = new CStatisticheSquadra(squadra);
            classifica.Add(nuova);
            return nuova;
        }

        // 5. CERCA PARTITE DI UNA SQUADRA

        private static void CercaSquadra(CRepositoryPartite repository)
        {
            string nome = LeggiTesto("Nome della squadra: ");

            List<CPartita> trovate = new List<CPartita>();
            foreach (CPartita partita in repository.GetElenco())
            {
                bool inCasa = string.Equals(partita.SquadraCasa, nome, StringComparison.OrdinalIgnoreCase);
                bool fuori = string.Equals(partita.SquadraOspite, nome, StringComparison.OrdinalIgnoreCase);
                if (inCasa || fuori)
                    trovate.Add(partita);
            }

            if (trovate.Count == 0)
            {
                Console.WriteLine("Nessuna partita trovata per " + nome + ".");
                return;
            }

            CPartita.Criterio = "naturale";   // FORZO L'ORDINE NATURALE (IL CRITERIO E' STATICO)
            trovate.Sort();   // ordine naturale (giornata, poi squadra di casa)
            Console.WriteLine("Partite trovate per " + nome + ":");
            StampaElenco(trovate);
        }

        // 6. ELIMINA PARTITA

        private static void EliminaPartita(CRepositoryPartite repository)
        {
            IReadOnlyList<CPartita> elenco = repository.GetElenco();

            if (elenco.Count == 0)
            {
                Console.WriteLine("L'elenco e' vuoto.");
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

        private static int LeggiIntero(string m, int min, int max)
        {
            while (true)
            {
                Console.Write(m);
                string? risposta = Console.ReadLine();

                if (risposta is null)   // INPUT TERMINATO (EOF): EVITA IL LOOP INFINITO
                    return min;

                int valore;
                if (int.TryParse(risposta, out valore) && valore >= min && valore <= max)
                    return valore;

                Console.WriteLine("VALORE NON VALIDO: INSERIRE NUMERO NELL'INTERVALLO: " + min + " - " + max);
            }
        } //LEGGE NUMERO INTERO IN INPUT INSERENDO MESSAGGIO, VALORE MAX E MIN

        private static string LeggiTesto(string messaggio)
        {
            while (true)
            {
                Console.Write(messaggio);
                string? risposta = Console.ReadLine();

                if (risposta is null)   // INPUT TERMINATO (EOF)
                    throw new InvalidOperationException("INPUT TERMINATO");

                if (!string.IsNullOrWhiteSpace(risposta))
                    return risposta.Trim();

                Console.WriteLine("Il testo non puo' essere vuoto.");
            }
        }

        private static DateTime? LeggiData(string messaggio)
        {
            while (true)
            {
                Console.Write(messaggio);
                string? risposta = Console.ReadLine();

                if (risposta is null || string.IsNullOrWhiteSpace(risposta))
                    return null;   // DATA OPZIONALE: INVIO PER SALTARE

                DateTime data;
                if (DateTime.TryParseExact(risposta.Trim(), "dd/MM/yyyy",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out data))
                    return data;

                Console.WriteLine("FORMATO NON VALIDO. Usare dd/MM/yyyy (es. 15/06/2026).");
            }
        }
    }
}
