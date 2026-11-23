using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using System;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace EsBattagliaNavaleBertoldoMatteo.Views
{
    public partial class Gioco : UserControl
    {
        public Button[,] bottoni;
        public CCella[,] celle;
        public List<CNave> navi;
        public CGestione G;

        public delegate void Cambio();
        public event Cambio? PartitaFinita;

        int mosse, colpite, acqua;

        public Gioco(CGestione g)
        {
            InitializeComponent();
            G = g;
            mosse = 0; colpite = 0; acqua = 0;
            bottoni = new Button[10, 10];
            bottoni = g.Bottoni;
            celle = g.Celle;
            navi = g.Navi;
            CreaStruttura();
        }

        public void CreaStruttura()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button btn = new Button
                    {
                        Content = "🌊",
                        Margin = new Thickness(2),
                        Tag = celle[i,j]
                    };
                    if (celle[i,j].Nave)
                    {
                        btn.Click += Click_Nave;
                    }
                    else
                    {
                        btn.Click += Click_Acqua;
                    }

                    bottoni[i, j] = btn;
                    Griglia.Children.Add(btn);
                }
            }
        }

        private void Click_Nave(object? sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                CCella? c = btn.Tag as CCella;
                if (c != null)
                {
                    AggiornaStat(true);
                    btn.Content = "💥";
                    btn.IsEnabled = false;
                    foreach (CNave n in navi)
                    {
                        if (n.Cerca(c))
                        {
                            ScriviLog("\n Colpito in posizione ( X: " + (c.X + 1) + ", Y: " + (c.Y + 1) + ") ");
                            if (n.Rimaste == 0)
                            {
                                ScriviLog("\nNAVE "+ (n.Id+1).ToString() + " AFFONDATA");
                                G.NaviRimaste--;
                                if (G.NaviRimaste == 0)
                                {
                                    NaviRim.Text = "VITTORIA";
                                    Fine();
                                    PartitaFinita?.Invoke();
                                }
                                else NaviRim.Text = "NAVI " + G.NaviRimaste;
                            }
                        }
                    }
                }
            }
        }

        private void Fine()
        {
            foreach(var b in bottoni)
            {
                b.IsEnabled = false;
            }
            return;
        }

        private void Click_Acqua(object? sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                CCella? c = btn.Tag as CCella;
                if (c != null)
                {
                    AggiornaStat(false);
                    btn.Content = "💦";
                    btn.IsEnabled = false;
                    ScriviLog("\nAcqua!!");
                }
            }
        }

        private void ScriviLog(string riga)
        {
            log.Text += riga;
            Dispatcher.UIThread.Post(() => LogScroll.ScrollToEnd());
        }

        private void AggiornaStat(bool b)
        {
            Mosse.Text = "MOSSE " + mosse++;
            if (b)
            {
                colpite++;
                Colpite.Text = "COLPITE " + colpite;
            }
            else
            {
                acqua++;
                Acqua.Text = "MANCATE " + acqua;
            }
        }
    }
}