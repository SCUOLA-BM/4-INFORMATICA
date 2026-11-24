using Avalonia.Controls;
using Avalonia.LogicalTree;
using Avalonia.Media;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace EsReGuardiePedoniBertoldoMatteo;

public partial class MainWindow : Window
{
    string[] comandi;
    CGestionale g;
    public MainWindow()
    {
        InitializeComponent();
        comandi = new string[100];
        g = new CGestionale();
        g.Fine += OnFine;
        g.Attacca += OnColori;
    }

    public string OnColori()
    {
        Re.Background = Brushes.Red;
        Guardie.Background = Brushes.LightBlue;
        Pedoni.Background = Brushes.Yellow;
        return "";
    }

    private string OnFine()
    {
        Prossimo.IsEnabled = false;
        EseguiTutto.IsEnabled = false;
        return "Simulazione Terminata";
    }

    private void CaricaFile(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        ListaFileInput.ItemsSource = g.LeggiFile();
        Prossimo.IsEnabled = true;
        EseguiTutto.IsEnabled = true;
        CaricaFigure();
    }

    public void CaricaFigure()
    {
        Pedoni.ItemsSource = g.PedoniString;
        Guardie.ItemsSource = g.GuardieString;
        ListaFileOutput.ItemsSource = g.Output;
        Re.Content = "♔" + g.Re.Nome;
    }

    private async void Passo(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        g.Passo();
        await Task.Delay(1000);

        Re.Background = Brushes.Black;
        Guardie.Background = Brushes.Black;
        Pedoni.Background = Brushes.Black;
        ListaFileInput.SelectedIndex = g.Index;


    }

    private async void eseguiTutto(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        for(int i = 0; i< g.NumComandi; i++ )
        {
            Passo(sender, e);
            await Task.Delay(2000);
        }
    }
}