using Avalonia.Controls;
using System.Collections.Generic;

namespace EsAutonoleggioBM;

public partial class MainWindow : Window
{
    List<CVeicolo> veicoli;
    CVeicolo v;
    bool valido;
    bool velettrico;
    int akm;
    List<string> descrVeicoli;
    public MainWindow()
    {
        InitializeComponent();
        veicoli = new List<CVeicolo>();
        Default();
    }
    public void Default()
    {
        listaveicoli.Items.Clear();
        veicoli.Add(new CAuto("AA666BB", "Fiat Panda"));
        veicoli.Add(new CMoto("BG456LK", "Stark Varg"));
        veicoli.Add(new CFurgone("RA867IL", "DACIA Duster"));
        veicoli.Add(new CAutoElettrica("RE591HJ", "Tesla Model X", 350));
        AggiornaLista();
    }

    public void AggiornaLista()
    {
        descrVeicoli = new List<string>();
        foreach (CVeicolo v in veicoli)
        {
            descrVeicoli.Add(v.ToString());
        }
        listaveicoli.ItemsSource = descrVeicoli;
    }

    private void AggiungiFlotta(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        ControlloErrori();
    }

    public void ControlloErrori()
    {
        valido = true;
        velettrico = CmbTipo.SelectedIndex == 3;

        if (CmbTipo.SelectedIndex == -1)
        {
            error.Text = "/nINSERIRE TIPO VEICOLO";
            valido = false;
        }
        if (targa.Text == "")
        {
            error.Text += "/nINSERIRE TARGA";
            valido = false;
        }
        if (modello.Text == "")
        {
            error.Text += "/nINSERISCI MODELLO";
            valido = false;
        }
        if (velettrico && int.TryParse(autonomia.Text, out akm))
        {
            error.Text += "/nINSERISCI MODELLO";
            valido = false;
        }
        if (!valido)
        {
            switch (CmbTipo.SelectedIndex)
            {
                case 0:
                    v = new CAuto(targa.Text, modello.Text);
                    veicoli.Add(v);
                    break;
                case 1:
                    v = new CMoto(targa.Text, modello.Text);
                    veicoli.Add(v);
                    break;
                case 2:
                    v = new CFurgone(targa.Text, modello.Text);
                    veicoli.Add(v);
                    break;
                case 3:
                    v = new CAutoElettrica(targa.Text, modello.Text, akm);
                    veicoli.Add(v);
                    autonomia.Text = "";
                    break;
                default:
                    error.Text += "/nErrore del sistema";
                    return;
            }
            veicoli.Add(v);
            targa.Text = "";
            modello.Text = "";
            CmbTipo.SelectedIndex = -1;
        }

    }
    private void CalcolaPreventivo(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if(listaveicoli.SelectedIndex == -1) error.Text = "/nSeleziona veicolo dalla lista";
        else
        {
            v = veicoli[listaveicoli.SelectedIndex];
            preventivo.Text = "PREVENTIVO VEICOLO : "+v.ToString() ;
            preventivo.Text += "/nCOSTO NOLEGGIO : " + v.CalcolaCosto((int)giorni.Value);
            if (assicurazione.IsChecked == true)
            {
                preventivo.Text += "/nCOSTO ASSICURAZIONE : " + (15 * (int)giorni.Value);
                preventivo.Text += "/nTOTALE : " + (v.CalcolaCosto((int)giorni.Value) + (15 * (int)giorni.Value));
            }
            else preventivo.Text += "/nTOTALE : " + v.CalcolaCosto((int)giorni.Value);
            if (velettrico) preventivo.Text += "/nRICARICA INCLUSA - AUTONOMIA " + akm + " km";
        }

    }

    private void CmbTipo_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if(CmbTipo.SelectedIndex == 3) AutPanel.IsVisible = true;
        else AutPanel.IsVisible = false;
    }
}