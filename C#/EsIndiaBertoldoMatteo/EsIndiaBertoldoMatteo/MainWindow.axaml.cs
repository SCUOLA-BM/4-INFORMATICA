using Avalonia.Controls;
using System.ComponentModel;
using System.Text;

namespace EsIndiaBertoldoMatteo;

public partial class MainWindow : Window
{

    CMenu m = new CMenu();
    CSala s;
    CTavolo t;
    CPiatto p;
    COrdine o;
    CStorico storico;
    CSalajson salajson;
    public MainWindow()
    {
        InitializeComponent();
        storico = new CStorico();
        salajson = new CSalajson();
        s = salajson.Carica();
        Menu.ItemsSource = m.AggiornaLista();
        listatavoli.ItemsSource = s.AggiornaLista();
        o = new COrdine();
        Storico.Text = storico.Descrizione();
    }

    private void AggOrd(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (Menu.SelectedIndex != -1)
        {
            if (int.TryParse(Quant.Text, out int n) && n > 0)
            {
                o.Agg(m.menu[Menu.SelectedIndex], n);
                ListaOrdini.ItemsSource = null;
                ListaOrdini.ItemsSource = o.Lista;
                Quant.Text = "";
                error.Text = "Piatti aggiunti all'ordine con successo";
                inviaOrd.IsEnabled = true;
            }
            else
            {
                error.Text = "Numero di piatti non valido";
            }
        }
        else
        {
            error.Text = "Piatto non selezionato";
        }
    }

    private void InviaOrd(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (o != null && Menu.SelectedIndex != -1)
        {
            TermConto.IsEnabled = true;
            t.Ordina(o);
            listatavoli.ItemsSource = null;
            listatavoli.ItemsSource = s.AggiornaLista();
            ListaOrdini.ItemsSource = null;
            DescrTav.Text += o.Descrizione(t.Ordini.Count);
            error.Text = "Ordine aggiunto con successo";
            o = new COrdine();
            inviaOrd.IsEnabled = false;
        }
        else error.Text = "Ordine non riuscito";
    }

    private void listatavoli_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (listatavoli.SelectedIndex != -1)
        {
            t = s.tavoli[listatavoli.SelectedIndex];
            Ordine.Header = "TAVOLO N° " + t.Id;
            Ordini.Header = "ORDINE";
            DescrTav.Text = "";
            for(int i = 0; i < t.Lista.Count; i++)
            {
                DescrTav.Text += t.Lista[i];
            }
            Npersone.Focus();
            if (t.Libero)
            {
                Input.IsVisible = false;
                ElencoOrdini.IsVisible = false;
                Riserva.IsEnabled = true;
            }
            else
            {
                Input.IsVisible = true;
                ElencoOrdini.IsVisible = true;
                Riserva.IsEnabled = false;
            }
            if (t.Ordini.Count != 0) TermConto.IsEnabled = true;
            else TermConto.IsEnabled = false;

        }
        else
        {
            Riserva.IsEnabled = false;
        }

    }

    private void RiservaTavolo(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (t.Libero)
        {
            if (int.TryParse(Npersone.Text, out int n) && t.PMax >= n && n > 0)
            {
                t.Poccupati = n;
                t.Libero = false;
                listatavoli.ItemsSource = null;
                listatavoli.ItemsSource = s.AggiornaLista();
                error.Text = "Tavolo riservato con successo";
                Input.IsVisible = true;
                ElencoOrdini.IsVisible = true;
                ResFinale.Text = "";
                if (listatavoli.SelectedIndex == -1) aggOrd.IsEnabled = false;
                if (o.piatti.Count == 0) inviaOrd.IsEnabled = false;
            }
            else
            {
                error.Text = "Numero di persone non valido";
            }
        }
        else
        {
            error.Text = "Tavolo occupato";
        }

    }

    private void Menu_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (o.piatti.Count == 0) inviaOrd.IsEnabled = false;
        if (Menu.SelectedIndex != -1)
        {
            p = m.menu[Menu.SelectedIndex];
            Quant.Focus();
            aggOrd.IsEnabled = true;
        }
        else
        {
            aggOrd.IsEnabled = false;
        }
    }

    private void ChiudiConto(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        storico.Salva(t);
        Storico.Text = storico.Descrizione();
        TermConto.IsEnabled = false;
        ResFinale.Text = "TOT DA PAGARE : "+t.Conto().ToString("F2");
        ListaOrdini.ItemsSource = null;
        error.Text = "Chiusura conto avvenuta con successo";
        DescrTav.Text = "";
        t.Reset();
        listatavoli.ItemsSource = s.AggiornaLista();
    }

    protected override void OnClosing(WindowClosingEventArgs e)
    {
        if (salajson != null && s != null)
        {
            salajson.Salva(s);
        }

        base.OnClosing(e); //chiudere Window
    }

}