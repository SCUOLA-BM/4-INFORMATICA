namespace Es1AvaloniBM.Models;

/// <summary>
/// Model: dati puri, senza riferimenti all'interfaccia grafica.
/// È la stessa classe che il DataGrid e la ListBox mostrano tramite il binding.
/// </summary>
public class Utente
{
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Eta { get; set; }
}
