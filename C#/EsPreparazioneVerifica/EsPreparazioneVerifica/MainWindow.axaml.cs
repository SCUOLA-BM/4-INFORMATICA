using Avalonia.Controls;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace EsPreparazioneVerifica;

public partial class MainWindow : Window
{
    List<CMateria> listaMaterie;
    List<string> materiestringhe;
    CMateria m;
    CDocente d;
    string nome;
    int ore;
    bool sesso;

    public MainWindow()
    {
        InitializeComponent();
        LeggiListaMaterie();
        ListaMaterie.ItemsSource = materiestringhe;
    }

    public void LeggiListaMaterie()
    {
        string fileName = "materie.json";
        if (File.Exists(fileName))
        {
            string testo = File.ReadAllText(fileName);
            if (testo == null)
            {
                error.Text = "json vuoto";
                listaMaterie = new List<CMateria>();
                return;
            }
            listaMaterie = JsonSerializer.Deserialize<List<CMateria>>(testo);

            AggiornaLista();
        }
        else
        {
            error.Text = "Caricamento materie non riuscito";
            listaMaterie = new List<CMateria>();
        }

    }


    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (ControlloErrori() && ListaMaterie.SelectedIndex != -1)
        {
            d = new CDocente(nome , ore, sesso);
            m.Docente = d;
            AggiornaLista();
        }
    }

    public void AggiornaLista()
    {
        materiestringhe = new List<string>();
        foreach(var mat in listaMaterie)
        {
            
            materiestringhe.Add(mat.Descrizione());
        }
        ListaMaterie.ItemsSource = materiestringhe;

        Salva();

    }

    public bool ControlloErrori()
    {
        if(Docente.Text == "")
        {
            error.Text = "INSERISCI NOME DOCENTE";
            return false;
        }
        nome = Docente.Text.Trim();

        if(!int.TryParse(Ora.Text, out ore) || ore < 1 || ore >6)
        {
            error.Text = "INSERISCI N ORE IN CUI IL DOCENTE DEVE FARE LEZIONE";
            return false;
        }

        if(Uomo.IsChecked != true && Donna.IsChecked != true)
        {
            error.Text = "SELEZIONA IL SESSO DEL DOCENTE";
            return false;
        }
        sesso = Uomo.IsChecked == true;
        return true;
    }

    private void ListaMaterie_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if(ListaMaterie.SelectedIndex != -1)
        {
            m = listaMaterie[ListaMaterie.SelectedIndex];
        }
    }

    public void Salva()
    {
        string filename = "materie.json";
        var options = new JsonSerializerOptions{ WriteIndented = true };
        string content = JsonSerializer.Serialize(listaMaterie, options);
        File.WriteAllText(filename, content);
    }
}