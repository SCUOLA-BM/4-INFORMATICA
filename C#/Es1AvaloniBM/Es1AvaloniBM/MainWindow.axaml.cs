using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Es1AvaloniBM.ViewModels;

namespace Es1AvaloniBM;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // DataContext: il ponte tra View (XAML) e ViewModel (C#).
        DataContext = new MainWindowViewModel();
    }

    // Esempio volutamente "classico": il Click arriva al code-behind, non al ViewModel.
    // Serve a confrontarlo con Command="{Binding IncrementaCommand}".
    private void OnClickDemo(object? sender, RoutedEventArgs e)
    {
        ClickResult.Text = $"Click gestito nel code-behind alle {DateTime.Now:HH:mm:ss}.";
    }
}