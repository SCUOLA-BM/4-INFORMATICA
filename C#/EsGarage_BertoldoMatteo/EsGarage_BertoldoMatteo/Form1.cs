using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsGarage_BertoldoMatteo
{
    public partial class Form1 : Form
    {
        enum Carburanti
        {
            BENZINA,
            DIESEL
        }
        public List<string> carburanti = new List<string> { "BENZINA", "DIESEL" };
        public List<string> tempi = new List<string> { "2", "4" };
        public List<string> veicoli = new List<string> { "AUTO", "MOTO", "FURGONE"};
        CGarage garage = new CGarage();
        int id = 0;
        CVeicolo veicolo;

        public Form1()
        {
            InitializeComponent();
            lstGarage.Text = "GARAGE BERTOLDO";
            cmbAlimentazione.DataSource = carburanti;
            cmbTempi.DataSource = tempi;
            cmbVeicolo.DataSource = veicoli;
        }

        private void txtNumPorte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Clear)
            {
                e.KeyChar = (char)0;
            }
        }

        private void txtAnno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Clear)
            {
                e.KeyChar = (char)0;
            }
        }

        private void txtCapacità_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Clear)
            {
                e.KeyChar = (char)0;
            }
        }

        private void cmbVeicolo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbVeicolo.SelectedIndex == 0)
            {
                Invisible();
                pnlAuto.Visible = true;
            }
            else if (cmbVeicolo.SelectedIndex == 1)
            {
                Invisible();
                pnlMoto.Visible = true;
            }
            else
            {
                Invisible();
                pnlFurgone.Visible = true;
            }
        }
        public void Invisible()
        {
            pnlAuto.Visible = false;
            pnlMoto.Visible = false;
            pnlFurgone.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbVeicolo.SelectedIndex == 0) veicolo = new CAuto();

            else if (cmbVeicolo.SelectedIndex == 1) veicolo = new CMoto();

            else veicolo = new CFurgone();

            veicolo.Id = id;
            
            if (txtAnno.Text == "" || int.Parse(txtAnno.Text) < 1886 || int.Parse(txtAnno.Text) > DateTime.Now.Year)
            {
                MessageBox.Show("ANNO NON VALIDO");
                txtAnno.Text = "";
                return;
            }
            veicolo.Anno = int.Parse(txtAnno.Text);


            if (txtMarca.Text == "")
            {
                MessageBox.Show("MARCA NON INSERITA");
                return;
            }
            veicolo.Marca = txtMarca.Text;

            if (txtCilindrata.Text == "" || int.Parse(txtCilindrata.Text) > 13518 || int.Parse(txtCilindrata.Text) < 0)
            {
                MessageBox.Show("CILINDRATA NON VALIDA");
                txtCilindrata.Text = "";
                return;
            }
            veicolo.Cyl = int.Parse(txtCilindrata.Text);

            if (veicolo is CAuto auto)
            {
                if (txtNumPorte.Text == "" || int.Parse(txtNumPorte.Text) > 6 || int.Parse(txtNumPorte.Text) < 1)
                {
                    MessageBox.Show("NUM PORTE NON VALIDO");
                    txtNumPorte.Text = "";
                    return;
                }
                auto.NumPorte = int.Parse(txtNumPorte.Text);
                auto.Alimentazione = (cmbAlimentazione.SelectedIndex == 0);
                lstGarage.Items.Add(auto.Print());
                garage.Add(auto);
            }
            else if (veicolo is CMoto moto)
            {
                moto.Tempi = (cmbTempi.SelectedIndex == 0);
                lstGarage.Items.Add(moto.Print());
                garage.Add(moto);
            }
            else if(veicolo is CFurgone furgone)
            {

                if (txtCapacità.Text == "" || int.Parse(txtCapacità.Text) > 20 || int.Parse(txtCapacità.Text) <= 0)
                {
                    MessageBox.Show("CAPACITA' NON VALIDA");
                    txtCapacità.Text = "";
                    return;
                }
                furgone.Capacità = int.Parse(txtCapacità.Text);
                lstGarage.Items.Add(furgone.Print());
                garage.Add(furgone);
            }
            else
            {
                MessageBox.Show("ERRORE NEL PROGRAMMA");
                id--;
                return;
            }
            id++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(lstGarage.SelectedIndex == -1)
            {
                MessageBox.Show("SELEZIONA VEICOLO DA ELIMINARE");
                return;
            }
            garage.Elim(lstGarage.SelectedIndex);
            lstGarage.Items.RemoveAt(lstGarage.SelectedIndex);
        }
    }
}
