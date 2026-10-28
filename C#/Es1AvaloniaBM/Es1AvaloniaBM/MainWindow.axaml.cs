using Avalonia.Controls;
using Avalonia.Interactivity;
using Tmds.DBus.Protocol;

namespace Es1AvaloniaBM;

public partial class MainWindow : Window
{
    float num1=0, num2=0;
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Somma(object? sender, RoutedEventArgs e)
    {
        if(Verifica()) ris.Text = "" + (num1 + num2);
    }

    private void Differenza(object? sender, RoutedEventArgs e)
    {
        if(Verifica()) ris.Text = "" + (num1 - num2);
    }

    private void Prodotto(object? sender, RoutedEventArgs e)
    {
        if(Verifica()) ris.Text = "" + (num1 * num2);
    }

    private void Divisione(object? sender, RoutedEventArgs e)
    {
        if (Verifica()) ris.Text = "" + (num1 / num2);
    }


    private bool Verifica()
    {
        if (n1.Text == null || n1.Text == "" || n2.Text == null || n2.Text == "")
        {
            ris.Text = "Inserisci i numeri";
            return false;
        }
        else if (!float.TryParse(n1.Text?.Trim(), out num1) || !float.TryParse(n2.Text?.Trim(), out num2))
        {
            ris.Text = "Inserisci numeri validi, non stringhe";
            return false;
        }
        return true;
    }
}