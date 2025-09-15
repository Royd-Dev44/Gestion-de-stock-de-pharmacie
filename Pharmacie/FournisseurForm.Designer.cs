namespace Pharmacie
{
    partial class FournisseurForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvFournisseur = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRecherche = new System.Windows.Forms.TextBox();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFournisseur)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvFournisseur
            // 
            this.dgvFournisseur.BackgroundColor = System.Drawing.Color.White;
            this.dgvFournisseur.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFournisseur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFournisseur.Location = new System.Drawing.Point(0, 0);
            this.dgvFournisseur.Name = "dgvFournisseur";
            this.dgvFournisseur.Size = new System.Drawing.Size(1174, 726);
            this.dgvFournisseur.TabIndex = 0;
            this.dgvFournisseur.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFournisseur_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtRecherche);
            this.panel1.Controls.Add(this.btnAjouter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1174, 135);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(689, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "Recherche";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(433, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 30);
            this.label1.TabIndex = 20;
            this.label1.Text = "GESTION DES FOURNISSEURS";
            // 
            // txtRecherche
            // 
            this.txtRecherche.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecherche.Location = new System.Drawing.Point(765, 88);
            this.txtRecherche.Name = "txtRecherche";
            this.txtRecherche.Size = new System.Drawing.Size(360, 25);
            this.txtRecherche.TabIndex = 19;
            // 
            // btnAjouter
            // 
            this.btnAjouter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouter.Location = new System.Drawing.Point(49, 83);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(221, 30);
            this.btnAjouter.TabIndex = 18;
            this.btnAjouter.Text = "Ajouter  un fournisseur";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvFournisseur);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 135);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1174, 726);
            this.panel2.TabIndex = 2;
            // 
            // FournisseurForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 861);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FournisseurForm";
            this.Text = "FournisseurForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFournisseur)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFournisseur;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRecherche;
        private System.Windows.Forms.Button btnAjouter;
    }
}