using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Es1AvaloniBM.Models;

namespace Es1AvaloniBM.ViewModels;

/// <summary>
/// ViewModel dell'esercizio unico.
/// [ObservableProperty] genera le proprietà notificanti, [RelayCommand] i comandi
/// che i controlli XAML richiamano con Command="{Binding ...Command}".
/// </summary>
public partial class MainWindowViewModel : ObservableObject
{
    // ---------- Dati mostrati da ListBox, DataGrid e ItemsControl ----------
    public ObservableCollection<Utente> Persone { get; } =
    [
        new Utente { Nome = "Mario Rossi", Email = "mario@example.com", Eta = 30 },
        new Utente { Nome = "Giulia Bianchi", Email = "giulia@example.com", Eta = 25 },
        new Utente { Nome = "Luca Verdi", Email = "luca@example.com", Eta = 40 },
        new Utente { Nome = "Eona Rossi", Email = "eona@example.com", Eta = 30 },
        new Utente { Nome = "Mark Banchi", Email = "mark@example.com", Eta = 25 },
        new Utente { Nome = "Greta Bianchi", Email = "greta@example.com", Eta = 20 }
    ];

    // ---------- Campi del form (two-way binding) ----------
    [ObservableProperty] private string _nome = "Giulia";
    [ObservableProperty] private string _email = "giulia@example.com";
    [ObservableProperty] private decimal? _eta = 18;

    // Riga scelta contemporaneamente in ListBox e DataGrid.
    [ObservableProperty] private Utente? _selezionata;

    // ---------- Stato dei controlli dimostrativi ----------
    [ObservableProperty] private double _valore = 35;
    [ObservableProperty] private bool _ricorda = true;
    [ObservableProperty] private bool _notifiche;
    [ObservableProperty] private decimal? _quantita = 3;
    [ObservableProperty] private DateTimeOffset? _data = DateTimeOffset.Now;
    [ObservableProperty] private TimeSpan? _ora = new(9, 0, 0);
    [ObservableProperty] private string? _reparto = "Informatica";
    [ObservableProperty] private int _clic;
    [ObservableProperty] private string _messaggio = "Pronto: usa il form o i pulsanti.";

    public string[] Reparti { get; } = ["Informatica", "Elettronica", "Meccanica", "Chimica"];

    // ---------- Comandi ----------
    [RelayCommand]
    private void Aggiungi()
    {
        if (string.IsNullOrWhiteSpace(Nome))
        {
            Messaggio = "Il nome è obbligatorio: scrivilo nella casella.";
            return;
        }

        var utente = new Utente
        {
            Nome = Nome.Trim(),
            Email = string.IsNullOrWhiteSpace(Email) ? "n.d." : Email.Trim(),
            Eta = (int)(Eta ?? 0)
        };

        Persone.Add(utente);
        Selezionata = utente;
        Messaggio = $"Aggiunto {utente.Nome}: la ListBox e il DataGrid si aggiornano da soli.";

        Nome = string.Empty;
        Email = string.Empty;
        Eta = 18;
    }

    [RelayCommand]
    private void Rimuovi()
    {
        if (Selezionata is null)
        {
            Messaggio = "Seleziona prima una riga nella lista o nel DataGrid.";
            return;
        }

        var nome = Selezionata.Nome;
        Persone.Remove(Selezionata);
        Selezionata = null;
        Messaggio = $"Rimosso {nome}.";
    }

    [RelayCommand]
    private void Svuota()
    {
        Persone.Clear();
        Selezionata = null;
        Messaggio = "Elenco svuotato: ObservableCollection notifica la UI a ogni modifica.";
    }

    [RelayCommand]
    private void Incrementa()
    {
        Clic++;
        Messaggio = $"Comando eseguito {Clic} {(Clic == 1 ? "volta" : "volte")}.";
    }
}
