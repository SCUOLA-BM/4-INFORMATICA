using Avalonia;
using Avalonia.Controls;
using System.Runtime.ConstrainedExecution;
using System.Security;

namespace EsGeometriaBertoldoMatteo;

public partial class MainWindow : Window
{
    public double n1, n2;
    public int select = 0;
    public MainWindow()
    {
        InitializeComponent();
    }
    private void Combo_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (Combo == null || l1 == null || l2 == null || t2 == null) return;
        select = Combo.SelectedIndex;
        if (select == 0)
        {
            l1.Content = "INSERSCI ALTEZZA: ";
            t2.IsVisible = true;
            l2.IsVisible = true;
            l2.Content = "INSERSICI BASE: ";
        }
        else if (select == 1)
        {
            l1.Content = "INSERISCI LATO: ";
            l2.IsVisible = false;
            t2.IsVisible = false;
        }
        else
        {
            l1.Content = "INSERISCI RAGGIO: ";
            l2.IsVisible = false;
            t2.IsVisible = false;
        }
    }

    private bool Verifica(string? lat1, string? lat2, bool controllaSecondoDato)
    {
        if (string.IsNullOrEmpty(lat1)) return false;
        
        if (controllaSecondoDato)
        {
            if (string.IsNullOrEmpty(lat2)) return false;
            return double.TryParse(lat1, out n1) && double.TryParse(lat2, out n2);
        }

        return double.TryParse(lat1, out n1);
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (select == 0)
        {
            if (Verifica(t1.Text, t2.Text, true))
            {
                CRettangolo f = new CRettangolo("RETTANGOLO", n1, n2);
                per.Text = "PERIMETRO : " + f.CalcolaPerimetro();
                are.Text = "AREA : " + f.CalcolaArea();
                desc.Text = f.Descrizione();
            }
            else
            {
                per.Text = "VALORI NON VALIDI";
                are.Text = "VALORI NON VALIDI";
                desc.Text = "ERRORE";
            }
        }
        else if (select == 1)
        {
            if (Verifica(t1.Text, null, false))
            {
                CQuadrato q = new CQuadrato("QUADRATO", n1, n1);
                per.Text = "PERIMETRO : " + q.CalcolaPerimetro();
                are.Text = "AREA : " + q.CalcolaArea();
                desc.Text = q.Descrizione();
            }
            else
            {
                per.Text = "LATO NON VALIDO";
                are.Text = "LATO NON VALIDO";
                desc.Text = "ERRORE";
            }
        }
        else
        {
            if (Verifica(t1.Text, null, false))
            {
                CCerchio c = new CCerchio("CERCHIO", n1);
                per.Text = "PERIMETRO : " + c.CalcolaPerimetro();
                are.Text = "AREA : " + c.CalcolaArea();
                desc.Text = c.Descrizione();
            }
            else
            {
                per.Text = "RAGGIO NON VALIDO";
                are.Text = "RAGGIO NON VALIDO";
                desc.Text = "ERRORE";
            }
        }
    }
}