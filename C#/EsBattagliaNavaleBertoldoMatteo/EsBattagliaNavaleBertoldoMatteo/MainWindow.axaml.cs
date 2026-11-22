using Avalonia.Controls;
using EsBattagliaNavaleBertoldoMatteo.Views;

namespace EsBattagliaNavaleBertoldoMatteo;

public partial class MainWindow : Window
{
    CGestione g;
    Posiziona posiziona;
    Gioco gioca;
    public MainWindow()
    {
        InitializeComponent();
        g = new CGestione();
        posiziona = new Posiziona(g);
        posiziona.PosizionamentoCompletato += AbilitaTermina;
        Control.Content = posiziona;
        Nuova.IsEnabled = true;
        Termina.IsEnabled = false;
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        posiziona = new Posiziona(g);
        posiziona.PosizionamentoCompletato += AbilitaTermina;
        Control.Content = posiziona;
        g = posiziona.RitornaGestionale();
    }

    private void Button1_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        gioca = new Gioco(g);
        gioca.PartitaFinita += PartitaTerminata;
        Control.Content = gioca;
    }

    private void AbilitaTermina()
    {
        Termina.IsEnabled = true;
    }

    private void PartitaTerminata()
    {
        Termina.IsEnabled = false;
    }
}