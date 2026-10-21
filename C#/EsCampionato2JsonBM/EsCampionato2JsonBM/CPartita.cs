using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCampionato2JsonBM
{
    // ATTRIBUTI PER SERIALIZZARE/DESERIALIZZARE IL TIPO ASTRATTO CON DISCRIMINATORE "tipo"
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "tipo")]
    [JsonDerivedType(typeof(CPartitaGirone), "girone")]
    [JsonDerivedType(typeof(CPartitaEliminazione), "eliminazione")]
    [JsonDerivedType(typeof(CPartitaFinale), "finale")]
    internal abstract class CPartita : IRisultato, IStampabile, IEquatable<CPartita>, IComparable<CPartita>
    {
        private int giornata;
        private string squadraCasa = string.Empty;
        private string squadraOspite = string.Empty;
        private int golCasa;
        private int golOspite;
        private DateTime? data;

        public int Giornata
        {
            get { return giornata; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("GIORNATA DEVE ESSERE > 0");
                giornata = value;
            }
        }
        public string SquadraCasa
        {
            get { return squadraCasa; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("NOME SQUADRA CASA VUOTO");
                if (squadraOspite.Length > 0 &&
                    string.Equals(value.Trim(), squadraOspite, StringComparison.OrdinalIgnoreCase))
                    throw new ArgumentException("SQUADRA NON PUO' GIOCARE CONTRO SE STESSA");
                squadraCasa = value.Trim();
            }
        }
        public string SquadraOspite
        {
            get { return squadraOspite; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("NOME SQUADRA OSPITE VUOTO");
                if (squadraCasa.Length > 0 &&
                    string.Equals(value.Trim(), squadraCasa, StringComparison.OrdinalIgnoreCase))
                    throw new ArgumentException("SQUADRA NON PUO' GIOCARE CONTRO SE STESSA");
                squadraOspite = value.Trim();
            }
        }
        public int GolCasa
        {
            get { return golCasa; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("GOAL DEGLI OSPITI NEGATIVI");
                golCasa = value;
            }
        }
        public int GolOspite
        {
            get { return golOspite; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("GOAL DEGLI OSPITI NEGATIVI");
                golOspite = value;
            }
        }

        public DateTime? Data
        {
            get { return data; }
            set { data = value; }
        }

        public static string Criterio { get; set; } = "naturale";



        //PROPRIETA' ABSTRACT (SOLO CALCOLATA: OGNI CLASSE DERIVATA LA ESCLUDE DAL JSON CON [JsonIgnore])
        public abstract string Fase { get; }

        public CPartita(int giornata, string squadraCasa, string squadraOspite, int golCasa, int golOspite, DateTime? data = null)
        {
            Giornata = giornata;
            SquadraCasa = squadraCasa;
            SquadraOspite = squadraOspite;
            GolCasa = golCasa;
            GolOspite = golOspite;
            Data = data;
        }

        //METODI ABSTRACT
        public abstract int PuntiPer(string s);

        //METODI VIRTUAL
        public virtual string? CalcolaVincitore()
        {
            if (CalcolaEsito() == Esito.VittoriaCasa)
                return SquadraCasa;
            if (CalcolaEsito() == Esito.VittoriaOspite)
                return SquadraOspite;
            return null;
        }
        public virtual string Descrizione()
        {
            string testo = "Giornata " + Giornata;
            if (Data != null)
                testo += " (" + Data.Value.ToString("dd/MM/yyyy") + ")";
            testo += " [" + Fase + "] " +
                     SquadraCasa + " " + GolCasa + "-" + GolOspite + " " + SquadraOspite;
            return testo;
        }

        // METODI DERIVATI DA IRisultato
        public int CalcolaGolTotali()
        {
            return GolCasa + GolOspite;
        }

        public int CalcolaScarto()
        {
            return Math.Abs(GolCasa - GolOspite);
        }

        public Esito CalcolaEsito()
        {
            if (GolCasa > GolOspite)
                return Esito.VittoriaCasa;
            if (GolCasa < GolOspite)
                return Esito.VittoriaOspite;
            return Esito.Pareggio;
        }

        // METODI DERIVATI DA IEquatable
        public bool Equals(CPartita? other)
        {
            if (other is null)
                return false;

            return Giornata == other.Giornata &&
                   string.Equals(SquadraCasa, other.SquadraCasa, StringComparison.OrdinalIgnoreCase) &&
                   string.Equals(SquadraOspite, other.SquadraOspite, StringComparison.OrdinalIgnoreCase);
        }

        // RIDEFINISCO Equals(object)/GetHashCode PER COERENZA CON GLI OPERATORI == E !=
        public override bool Equals(object? obj)
        {
            return Equals(obj as CPartita);
        }

        // RIDEFINISCO OPERATORI

        public static bool operator ==(CPartita? a, CPartita? b)
        {
            if (a is null && b is null)
                return true;
            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }


        public static bool operator !=(CPartita? a, CPartita? b)
        {
            return !(a == b);
        }



        // METODI DERIVATI DA IComparable
        public int CompareTo(CPartita? other)
        {
            if (other is null)
                return 1;

            if (Criterio == "gol")   // DALLA PARTITA CON PIU' GOL A QUELLA CON MENO
                return other.CalcolaGolTotali().CompareTo(CalcolaGolTotali());
            if (Criterio == "scarto")   // DALLA VITTORIA PIU' LARGA AL PAREGGIO
                return other.CalcolaScarto().CompareTo(CalcolaScarto());
            if (Criterio == "casaAZ")
                return SquadraCasa.CompareTo(other.SquadraCasa);
            if (Criterio == "casaZA")
                return other.SquadraCasa.CompareTo(SquadraCasa);
            if (Criterio == "data")   // DALLA PARTITA PIU' RECENTE ALLA PIU' VECCHIA
                return Nullable.Compare(Data, other.Data);

            // ORDINE NATURALE (default e fallback per qualunque altro criterio)
            int r = Giornata.CompareTo(other.Giornata);
            if (r == 0)
                r = SquadraCasa.CompareTo(other.SquadraCasa);
            if (r == 0)
                r = SquadraOspite.CompareTo(other.SquadraOspite);
            return r;
        }

        public void ImpostaCriterio(string criterio)
        {
            Criterio = criterio;
        }
    }
}
