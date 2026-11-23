using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;

namespace EsBattagliaNavaleBertoldoMatteo.Views
{
    public partial class Posiziona : UserControl
    {
        public CCella[,] celle;
        public Button[,] bottoni;
        List<CNave> navi;
        int numnavi = 0;
        CGestione G;


        public delegate void Cambio();
        public event Cambio? PosizionamentoCompletato;
        public Posiziona(CGestione g)
        {
            InitializeComponent();
            G = g;
            bottoni = new Button[10, 10];
            celle = new CCella[10, 10];
            navi = new List<CNave>();
            CreaStruttura();
            CreaNavi();
        }

        public void CreaNavi()
        {
            navi.Add(new CNave(2, 0));
            navi.Add(new CNave(2, 1));
            navi.Add(new CNave(3, 2));
            navi.Add(new CNave(4, 3));
            navi.Add(new CNave(4, 4));
            navi.Add(new CNave(5, 5));
        }

        public void CreaStruttura()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    celle[i, j] = new CCella(i, j);
                    Button btn = new Button
                    {
                        Content = "🌊",
                        Margin = new Thickness(2),
                        Tag = celle[i,j]
                    };
                    btn.Click += Button_Click;

                    bottoni[i,j] = btn;
                    Griglia.Children.Add(btn);
                }
            }
        }

        private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Pulisci();
            if (sender is Button btn && btn.Tag is CCella c)
            {
                if(ComboNave.SelectedIndex != -1)
                {
                    Seleziona(btn, c, navi[ComboNave.SelectedIndex]);
                }
                else error.Text = "Seleziona nave da posizionare";
            }
            else
            {
                error.Text = "errore nei bottoni";
                return;
            }
            
        }

        public void Seleziona(Button btn,CCella c, CNave nave)
        {
            int x = c.X;
            int y = c.Y;
            if (celle[y, x].Verticale)
            {
                celle[y, x].Verticale = false;
                if (y+nave.Lung > 9) y = 10 - nave.Lung;                           //se la nave supera il limite
                Pulisci();                                                        //ripulisce tutta la griglia;
                for (int i = 0; i < nave.Lung; i++)
                {
                    if (Distante(y + i, x))
                    {
                        bottoni[y + i, x].Content = "X"; //marca le future navi
                    }
                    else
                    {
                        error.Text = "Non puoi posizionare la nave";
                        Pulisci();
                        return;
                    }
                }
            }
            else
            {
                celle[y, x].Verticale = true;
                if (x + nave.Lung > 9) x = 10 - nave.Lung ; //se la nave supera il limite
                Pulisci();
                for (int i = 0; i < nave.Lung; i++)
                {
                    if (Distante(y , x + i)) bottoni[y, x + i].Content = "X"; //marca le future navi
                    else
                    {
                        error.Text = "Non puoi posizionare la nave";
                        Pulisci();
                        return;
                    }
                    
                }
            }
            error.Text = "Clicca Posiziona per posizionare la nave";
        }

        public bool Distante(int y, int x)
        {
            if (celle[y, x].Nave) return false; //se clicco sopra barca
            if (celle[y + 1 <10 ? y + 1: y , x].Nave) return false;                            //bottone sotto
            if (celle[y + 1 < 10 ? y + 1 : y , x + 1 < 10 ? x + 1 : x].Nave) return false;//bottone sotto-destra
            if (celle[y, x + 1 < 10 ? x + 1 : x].Nave) return false;                     //bottone destra
            if (celle[y - 1 >=0 ? y - 1: y, x + 1 < 10 ? x + 1 : x].Nave) return false;   //bottone alto-destra
            if (celle[y - 1 >=0 ? y - 1 : y, x].Nave) return false;                      //bottone alto
            if (celle[y - 1 >=0 ? y - 1 : y, x - 1 >=0 ? x - 1 : x].Nave) return false;  //bottone alto-sinistra
            if (celle[y, x - 1 >=0 ? x - 1 : x].Nave) return false;                      //bottone sinistra
            if (celle[y + 1 < 10 ? y + 1 : y, x - 1 >=0 ? x - 1 : x].Nave) return false;       //bottone basso-sinistra
            return true;
        }

        public void Pulisci()
        {
            for (int i = 0; i < 10; i++) for (int j = 0; j < 10; j++) if (bottoni[i, j].Content == "X") bottoni[i, j].Content = "🌊";
        }

        private void Conferma_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            bool trovata = false;
            if(ComboNave.SelectedIndex != -1)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (bottoni[i, j].Content == "X")
                        {
                            trovata = true;
                            navi[ComboNave.SelectedIndex].Celle.Add(celle[i,j]);
                            celle[i,j].Nave = true;
                            bottoni[i, j].Content = "🚢";
                        }
                    }
                }
                if (!trovata)
                {
                    error.Text = "Nessuna nave temporanea selezionata";
                }
                else
                {
                    if(ComboNave.SelectedItem is ComboBoxItem item) item.IsEnabled = false;

                    ComboNave.SelectedIndex = -1;
                    error.Text = "Nave posizionata!";
                    numnavi++;
                    if(numnavi >= 6)
                    {
                        error.Text = "Tutte le navi sono state selezionate.";
                        Conferma.IsEnabled = false;
                        BloccaCelle();
                        G.Bottoni = bottoni;
                        G.Celle = celle;
                        G.Navi = navi;
                        PosizionamentoCompletato?.Invoke();
                    }
                }
            }
            else
            {
                error.Text = "Seleziona nave sulla ComboBox";
                return;
            }
        }

        public void BloccaCelle()
        {
            for (int i = 0; i < 10; i++) for (int j = 0; j < 10; j++) bottoni[i, j].IsEnabled = false;
        }

        public CGestione RitornaGestionale()
        {
            return G;
        }
    }
}