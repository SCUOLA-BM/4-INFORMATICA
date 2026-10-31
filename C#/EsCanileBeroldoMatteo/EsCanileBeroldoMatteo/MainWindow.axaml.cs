using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Media;
using System;

namespace EsCanileBeroldoMatteo;

public partial class MainWindow : Window
{
    CCane cane;
    CListaCani cani;

    private WindowNotificationManager not;

    public MainWindow()
    {
        InitializeComponent();

        cani = new CListaCani();

        cani.Carica();

        not = new WindowNotificationManager(TopLevel.GetTopLevel(this) ?? this);

        StampaGrid("ID,NOME,ANNO DI NASCITA,RAZZA,DATA INGRESSO,STATO,INF. UTILI");

        foreach(CCane c in cani.ListaCani)
        {
            StampaGrid(c.Descrizione());
        }
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        try
        {
            if (anno.SelectedDate == null || data.SelectedDate == null)
            {
                not.Show(new Notification("Attenzione", "Compilare tutte le date obbligatorie!", NotificationType.Warning));
                return;
            }

            cane = new CCane
            {
                Nome = nome.Text ?? string.Empty,
                AnnoNascita = anno.SelectedDate.Value.Year,
                Razza = (Erazza)razza.SelectedIndex,
                DataIngresso = data.SelectedDate.Value.DateTime,
                Stato = salute.IsChecked ?? false,
                Informazioni = descrizione.Text ?? string.Empty
            };

            cani.Add(cane);
            StampaGrid(cane.Descrizione());
            cani.Salva();
        }
        catch (Exception ex)
        {
            not.Show(new Notification("Errore", "Si e verificato un errore durante l'inserimento.", NotificationType.Error));
        }
    }

    public void StampaGrid(string str)
    {
        string[] split = str.Split(',');

        dataGridView.RowDefinitions.Add(new RowDefinition(GridLength.Auto));
        int r = dataGridView.RowDefinitions.Count - 1;

        for (int i = 0; i < split.Length; i++)
        {
            if (i >= dataGridView.ColumnDefinitions.Count) break;

            var cella = new TextBlock
            {
                Text = split[i],
                VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center,
                HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                FontFamily = "Lexend",
                FontSize = 15,
                Foreground = Brushes.Black,
                TextWrapping = TextWrapping.Wrap
            };

            var cellaBordo = new Border
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(2, 2, 2, 2),
                Child = cella
            };

            Grid.SetColumn(cellaBordo, i);
            Grid.SetRow(cellaBordo, r);

            dataGridView.Children.Add(cellaBordo);
        }
    }

    public void AggiornaGrid()
    {
        dataGridView.Children.Clear();
        dataGridView.RowDefinitions.Clear();

        StampaGrid("ID,NOME,ANNO DI NASCITA,RAZZA,DATA INGRESSO,STATO,INF. UTILI");

        foreach (var c in cani.ListaCani)
        {
            StampaGrid(c.Descrizione());
        }
    }

    private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        int id;
        CCane? elimcane = null;
        if (Elim.Text == "") throw new ArgumentException("INSERIRE ID CANE DA DARE IN ADOZIONE");
        if (!int.TryParse(Elim.Text, out id)) throw new ArgumentException("INSERIRE ID CANE VALIDO");

        foreach(CCane c in cani.ListaCani)
        {
            if(c.Id == id)
            {
                elimcane = c;
                break;
            }
        }
        cani.Elimina(elimcane);
        AggiornaGrid();
    }
}