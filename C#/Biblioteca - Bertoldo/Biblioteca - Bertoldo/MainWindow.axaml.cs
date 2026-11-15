using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.IO;

namespace Biblioteca___Bertoldo;

public partial class MainWindow : Window
{
    string codice;
    string titolo;
    int anno;
    bool disponibile;
    string autore;
    int numuscita;
    int durata;

    CGestioneBibioteca l;
    List<string> lDescrizione;

    public MainWindow()
    {
        InitializeComponent();
        Anno.Maximum = DateTime.Now.Year;
        l = new CGestioneBibioteca();
        lDescrizione = new List<string>();
        Start();
    }

    public void Start()
    {
        l.Aggiungi(new CLibro("1SRTGY56G", "GGG", 1986, "Franklin Tudor"));
        l.Aggiungi(new CRivista("2RTGH$%IL", "ANNA FRANK", 1948, 0000));
        l.Aggiungi(new CAudioLibro("ER45HYLI67", "SUS", 1967, "JakiDale", 67));
        AggiornaLista();
    }

    private void ComboBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (cmbMateriale.SelectedIndex == 0)
        {
            PanelAutore.IsVisible = true;
            PanelDurata.IsVisible = false;
            PanelNumUscita.IsVisible = false;
        }
        else if (cmbMateriale.SelectedIndex == 1)
        {
            PanelAutore.IsVisible = true;
            PanelDurata.IsVisible = true;
            PanelNumUscita.IsVisible = false;
        }
        else if (cmbMateriale.SelectedIndex == 2)
        {
            PanelAutore.IsVisible = false;
            PanelDurata.IsVisible = false;
            PanelNumUscita.IsVisible = true;
        }
    }

    private void Prestito_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (ListaMateriali.SelectedIndex == -1)
        {
            Errore("Seleziona materiale su cui compiere azione");
            return;
        }
        if (Nome.Text == "")
        {
            Errore("Inserisci nome di chi ha fatto prestito");
            return;
        }

        CMateriale m = l.Lista[ListaMateriali.SelectedIndex];

        if (!m.Disponibile) Errore("Libro non disponibile per il prestito");

        m.Disponibile = false;
        m.DataPrestito = DateTime.Now;
        m.Nome = Nome.Text;
        AggiornaLista();

        DataRitorno.Text = m.CalcolaRitorno();

    }

    private void Restituzione_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (ListaMateriali.SelectedIndex == -1)
        {
            Errore("Seleziona materiale su cui compiere azione");
            return;
        }

        CMateriale m = l.Lista[ListaMateriali.SelectedIndex];

        if (m.Disponibile)
        {
            Errore("Libro già disponibile");
            return;
        }

        Penale.Text = m.CalcoloPenale().ToString();

        m.Disponibile = true;
        m.DataPrestito = null;
        m.Nome = null;

        AggiornaLista();
    }

    private void CreaMateriale_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        CMateriale m;
        if (cmbMateriale.SelectedIndex == -1)
        {
            Errore("Inserisci mtipo di materiale che vuoi aggiungere");
            return;
        }
        if (Codice.Text == "")
        {
            Errore("Inserisci codice");
            return;
        }
        if (Titolo.Text == "")
        {
            Errore("Inserisci titolo");
            return;
        }
        if (Anno.Value == null || !int.TryParse(Anno.Text, out anno))
        {
            Errore("Inserisci anno pubblicazione");
            return;
        }

        codice = Codice.Text;
        titolo = Titolo.Text;


        if (cmbMateriale.SelectedIndex == 0)
        {
            if (Autore.Text == "")
            {
                Errore("Inserisci autore libro");
                return;
            }
            autore = Autore.Text;

            m = new CLibro(codice, titolo, anno, autore);
        }
        else if (cmbMateriale.SelectedIndex == 1)
        {
            if (Autore.Text == "")
            {
                Errore("Inserisci autore libro");
                return;
            }
            autore = Autore.Text;

            if (DurataMinuti.Text == "" || !int.TryParse(DurataMinuti.Text, out durata))
            {
                Errore("Inserisci durata audiolibro");
                return;
            }

            m = new CAudioLibro(codice, titolo, anno, autore, durata);
        }
        else
        {
            if (NumeroUscita.Value == null || !int.TryParse(NumeroUscita.Text, out numuscita))
            {
                Errore("Inserisci numero dell'uscita rivista");
                return;
            }

            m = new CRivista(codice, titolo, anno, numuscita);
        }
        l.Aggiungi(m);
        AggiornaLista();
    }

    public void AggiornaLista()
    {
        lDescrizione = new List<string>();
        foreach (var m in l.Lista)
        {
            lDescrizione.Add(m.Descrizione());
        }

        ListaMateriali.ItemsSource = null;
        ListaMateriali.ItemsSource = lDescrizione;
    }

    public void Errore(string err)
    {
        error.Text = err;
        return;
    }

    private void ListaMateriali_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (ListaMateriali.SelectedIndex != -1)
        {
            if (l.Lista[ListaMateriali.SelectedIndex].Disponibile)
            {
                Prestito.IsVisible = true;
                Restituzione.IsVisible = false;
            }
            else
            {
                Prestito.IsVisible = false;
                Restituzione.IsVisible = true;
            }
        }
    }
}