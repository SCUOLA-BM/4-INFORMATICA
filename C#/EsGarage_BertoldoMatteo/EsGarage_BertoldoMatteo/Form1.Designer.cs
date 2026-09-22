namespace EsGarage_BertoldoMatteo
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblAnno = new System.Windows.Forms.Label();
            this.txtAnno = new System.Windows.Forms.TextBox();
            this.lblCilindrata = new System.Windows.Forms.Label();
            this.txtCilindrata = new System.Windows.Forms.TextBox();
            this.pnlAuto = new System.Windows.Forms.Panel();
            this.lblAuto = new System.Windows.Forms.Label();
            this.cmbAlimentazione = new System.Windows.Forms.ComboBox();
            this.lblAlimentazione = new System.Windows.Forms.Label();
            this.lblPorte = new System.Windows.Forms.Label();
            this.txtNumPorte = new System.Windows.Forms.TextBox();
            this.pnlMoto = new System.Windows.Forms.Panel();
            this.lblMoto = new System.Windows.Forms.Label();
            this.cmbTempi = new System.Windows.Forms.ComboBox();
            this.lblTempi = new System.Windows.Forms.Label();
            this.pnlFurgone = new System.Windows.Forms.Panel();
            this.lblFurgone = new System.Windows.Forms.Label();
            this.lblCapacità = new System.Windows.Forms.Label();
            this.txtCapacità = new System.Windows.Forms.TextBox();
            this.cmbVeicolo = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnElim = new System.Windows.Forms.Button();
            this.lstGarage = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTipoVeicolo = new System.Windows.Forms.Label();
            this.pnlAuto.SuspendLayout();
            this.pnlMoto.SuspendLayout();
            this.pnlFurgone.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(15, 72);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(100, 22);
            this.txtMarca.TabIndex = 0;
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(21, 52);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(55, 16);
            this.lblMarca.TabIndex = 1;
            this.lblMarca.Text = "MARCA";
            // 
            // lblAnno
            // 
            this.lblAnno.AutoSize = true;
            this.lblAnno.Location = new System.Drawing.Point(21, 113);
            this.lblAnno.Name = "lblAnno";
            this.lblAnno.Size = new System.Drawing.Size(46, 16);
            this.lblAnno.TabIndex = 3;
            this.lblAnno.Text = "ANNO";
            // 
            // txtAnno
            // 
            this.txtAnno.Location = new System.Drawing.Point(12, 132);
            this.txtAnno.Name = "txtAnno";
            this.txtAnno.Size = new System.Drawing.Size(100, 22);
            this.txtAnno.TabIndex = 2;
            this.txtAnno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAnno_KeyPress);
            // 
            // lblCilindrata
            // 
            this.lblCilindrata.AutoSize = true;
            this.lblCilindrata.Location = new System.Drawing.Point(21, 174);
            this.lblCilindrata.Name = "lblCilindrata";
            this.lblCilindrata.Size = new System.Drawing.Size(86, 16);
            this.lblCilindrata.TabIndex = 5;
            this.lblCilindrata.Text = "CILINDRATA";
            // 
            // txtCilindrata
            // 
            this.txtCilindrata.Location = new System.Drawing.Point(12, 193);
            this.txtCilindrata.Name = "txtCilindrata";
            this.txtCilindrata.Size = new System.Drawing.Size(100, 22);
            this.txtCilindrata.TabIndex = 4;
            // 
            // pnlAuto
            // 
            this.pnlAuto.BackColor = System.Drawing.Color.Silver;
            this.pnlAuto.Controls.Add(this.lblAuto);
            this.pnlAuto.Controls.Add(this.cmbAlimentazione);
            this.pnlAuto.Controls.Add(this.lblAlimentazione);
            this.pnlAuto.Controls.Add(this.lblPorte);
            this.pnlAuto.Controls.Add(this.txtNumPorte);
            this.pnlAuto.Location = new System.Drawing.Point(8, 241);
            this.pnlAuto.Name = "pnlAuto";
            this.pnlAuto.Size = new System.Drawing.Size(157, 165);
            this.pnlAuto.TabIndex = 6;
            this.pnlAuto.Visible = false;
            // 
            // lblAuto
            // 
            this.lblAuto.AutoSize = true;
            this.lblAuto.Location = new System.Drawing.Point(14, 10);
            this.lblAuto.Name = "lblAuto";
            this.lblAuto.Size = new System.Drawing.Size(45, 16);
            this.lblAuto.TabIndex = 10;
            this.lblAuto.Text = "AUTO";
            // 
            // cmbAlimentazione
            // 
            this.cmbAlimentazione.FormattingEnabled = true;
            this.cmbAlimentazione.Location = new System.Drawing.Point(17, 123);
            this.cmbAlimentazione.Name = "cmbAlimentazione";
            this.cmbAlimentazione.Size = new System.Drawing.Size(121, 24);
            this.cmbAlimentazione.TabIndex = 9;
            // 
            // lblAlimentazione
            // 
            this.lblAlimentazione.AutoSize = true;
            this.lblAlimentazione.Location = new System.Drawing.Point(14, 104);
            this.lblAlimentazione.Name = "lblAlimentazione";
            this.lblAlimentazione.Size = new System.Drawing.Size(114, 16);
            this.lblAlimentazione.TabIndex = 5;
            this.lblAlimentazione.Text = "ALIMENTAZIONE";
            // 
            // lblPorte
            // 
            this.lblPorte.AutoSize = true;
            this.lblPorte.Location = new System.Drawing.Point(14, 40);
            this.lblPorte.Name = "lblPorte";
            this.lblPorte.Size = new System.Drawing.Size(88, 16);
            this.lblPorte.TabIndex = 3;
            this.lblPorte.Text = "NUM PORTE";
            // 
            // txtNumPorte
            // 
            this.txtNumPorte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumPorte.Location = new System.Drawing.Point(17, 59);
            this.txtNumPorte.Name = "txtNumPorte";
            this.txtNumPorte.Size = new System.Drawing.Size(100, 22);
            this.txtNumPorte.TabIndex = 2;
            this.txtNumPorte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumPorte_KeyPress);
            // 
            // pnlMoto
            // 
            this.pnlMoto.BackColor = System.Drawing.Color.Silver;
            this.pnlMoto.Controls.Add(this.lblMoto);
            this.pnlMoto.Controls.Add(this.cmbTempi);
            this.pnlMoto.Controls.Add(this.lblTempi);
            this.pnlMoto.Location = new System.Drawing.Point(12, 258);
            this.pnlMoto.Name = "pnlMoto";
            this.pnlMoto.Size = new System.Drawing.Size(156, 117);
            this.pnlMoto.TabIndex = 7;
            this.pnlMoto.Visible = false;
            // 
            // lblMoto
            // 
            this.lblMoto.AutoSize = true;
            this.lblMoto.Location = new System.Drawing.Point(12, 10);
            this.lblMoto.Name = "lblMoto";
            this.lblMoto.Size = new System.Drawing.Size(47, 16);
            this.lblMoto.TabIndex = 11;
            this.lblMoto.Text = "MOTO";
            // 
            // cmbTempi
            // 
            this.cmbTempi.FormattingEnabled = true;
            this.cmbTempi.Location = new System.Drawing.Point(15, 69);
            this.cmbTempi.Name = "cmbTempi";
            this.cmbTempi.Size = new System.Drawing.Size(121, 24);
            this.cmbTempi.TabIndex = 10;
            // 
            // lblTempi
            // 
            this.lblTempi.AutoSize = true;
            this.lblTempi.Location = new System.Drawing.Point(35, 41);
            this.lblTempi.Name = "lblTempi";
            this.lblTempi.Size = new System.Drawing.Size(48, 16);
            this.lblTempi.TabIndex = 3;
            this.lblTempi.Text = "TEMPI";
            // 
            // pnlFurgone
            // 
            this.pnlFurgone.BackColor = System.Drawing.Color.Silver;
            this.pnlFurgone.Controls.Add(this.lblFurgone);
            this.pnlFurgone.Controls.Add(this.lblCapacità);
            this.pnlFurgone.Controls.Add(this.txtCapacità);
            this.pnlFurgone.Location = new System.Drawing.Point(15, 276);
            this.pnlFurgone.Name = "pnlFurgone";
            this.pnlFurgone.Size = new System.Drawing.Size(156, 115);
            this.pnlFurgone.TabIndex = 8;
            this.pnlFurgone.Visible = false;
            // 
            // lblFurgone
            // 
            this.lblFurgone.AutoSize = true;
            this.lblFurgone.Location = new System.Drawing.Point(15, 13);
            this.lblFurgone.Name = "lblFurgone";
            this.lblFurgone.Size = new System.Drawing.Size(74, 16);
            this.lblFurgone.TabIndex = 12;
            this.lblFurgone.Text = "FURGONE";
            // 
            // lblCapacità
            // 
            this.lblCapacità.AutoSize = true;
            this.lblCapacità.Location = new System.Drawing.Point(35, 39);
            this.lblCapacità.Name = "lblCapacità";
            this.lblCapacità.Size = new System.Drawing.Size(76, 16);
            this.lblCapacità.TabIndex = 3;
            this.lblCapacità.Text = "CAPACITA\'";
            // 
            // txtCapacità
            // 
            this.txtCapacità.Location = new System.Drawing.Point(25, 59);
            this.txtCapacità.Name = "txtCapacità";
            this.txtCapacità.Size = new System.Drawing.Size(100, 22);
            this.txtCapacità.TabIndex = 2;
            this.txtCapacità.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCapacità_KeyPress);
            // 
            // cmbVeicolo
            // 
            this.cmbVeicolo.FormattingEnabled = true;
            this.cmbVeicolo.ItemHeight = 16;
            this.cmbVeicolo.Location = new System.Drawing.Point(19, 470);
            this.cmbVeicolo.Name = "cmbVeicolo";
            this.cmbVeicolo.Size = new System.Drawing.Size(121, 24);
            this.cmbVeicolo.TabIndex = 12;
            this.cmbVeicolo.SelectedIndexChanged += new System.EventHandler(this.cmbVeicolo_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Silver;
            this.btnAdd.Location = new System.Drawing.Point(159, 456);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 50);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnElim
            // 
            this.btnElim.BackColor = System.Drawing.Color.Silver;
            this.btnElim.Location = new System.Drawing.Point(282, 456);
            this.btnElim.Name = "btnElim";
            this.btnElim.Size = new System.Drawing.Size(100, 50);
            this.btnElim.TabIndex = 14;
            this.btnElim.Text = "ELIMINA";
            this.btnElim.UseVisualStyleBackColor = false;
            this.btnElim.Click += new System.EventHandler(this.button2_Click);
            // 
            // lstGarage
            // 
            this.lstGarage.FormattingEnabled = true;
            this.lstGarage.ItemHeight = 16;
            this.lstGarage.Location = new System.Drawing.Point(202, 12);
            this.lstGarage.Name = "lstGarage";
            this.lstGarage.Size = new System.Drawing.Size(581, 420);
            this.lstGarage.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "GARAGE";
            // 
            // lblTipoVeicolo
            // 
            this.lblTipoVeicolo.AutoSize = true;
            this.lblTipoVeicolo.Location = new System.Drawing.Point(26, 441);
            this.lblTipoVeicolo.Name = "lblTipoVeicolo";
            this.lblTipoVeicolo.Size = new System.Drawing.Size(98, 16);
            this.lblTipoVeicolo.TabIndex = 17;
            this.lblTipoVeicolo.Text = "TIPO VEICOLO";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 543);
            this.Controls.Add(this.lblTipoVeicolo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlFurgone);
            this.Controls.Add(this.lstGarage);
            this.Controls.Add(this.btnElim);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cmbVeicolo);
            this.Controls.Add(this.pnlMoto);
            this.Controls.Add(this.pnlAuto);
            this.Controls.Add(this.lblCilindrata);
            this.Controls.Add(this.txtCilindrata);
            this.Controls.Add(this.lblAnno);
            this.Controls.Add(this.txtAnno);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.txtMarca);
            this.Name = "Form1";
            this.Text = "Form1";
            this.pnlAuto.ResumeLayout(false);
            this.pnlAuto.PerformLayout();
            this.pnlMoto.ResumeLayout(false);
            this.pnlMoto.PerformLayout();
            this.pnlFurgone.ResumeLayout(false);
            this.pnlFurgone.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblAnno;
        private System.Windows.Forms.TextBox txtAnno;
        private System.Windows.Forms.Label lblCilindrata;
        private System.Windows.Forms.TextBox txtCilindrata;
        private System.Windows.Forms.Panel pnlAuto;
        private System.Windows.Forms.Label lblAlimentazione;
        private System.Windows.Forms.Label lblPorte;
        private System.Windows.Forms.TextBox txtNumPorte;
        private System.Windows.Forms.Panel pnlMoto;
        private System.Windows.Forms.Label lblTempi;
        private System.Windows.Forms.Panel pnlFurgone;
        private System.Windows.Forms.Label lblCapacità;
        private System.Windows.Forms.TextBox txtCapacità;
        private System.Windows.Forms.ComboBox cmbAlimentazione;
        private System.Windows.Forms.ComboBox cmbTempi;
        private System.Windows.Forms.Label lblFurgone;
        private System.Windows.Forms.Label lblAuto;
        private System.Windows.Forms.Label lblMoto;
        private System.Windows.Forms.ComboBox cmbVeicolo;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnElim;
        private System.Windows.Forms.ListBox lstGarage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTipoVeicolo;
    }
}

