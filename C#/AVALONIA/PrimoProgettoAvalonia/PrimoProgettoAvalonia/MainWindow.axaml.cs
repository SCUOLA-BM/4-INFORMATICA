using Avalonia.Controls;
using Avalonia.Interactivity;

namespace PrimoProgettoAvalonia;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    // Questo metodo viene chiamato quando premi il pulsante Salutami.
    private void Saluta_Click(object? sender, RoutedEventArgs e)
    {
        string nome = NomeTextBox.Text?.Trim() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(nome))
        {
            SalutoTextBlock.Text = "Scrivi prima il tuo nome.";
            NomeTextBox.Focus();
            return;
        }
        SalutoTextBlock.Text = $"Ciao, {nome}! Benvenuto in Avalonia.";
    }
}
