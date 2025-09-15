namespace Pharmacie
{
    partial class AjouterProduitVente
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
            this.cbMedicament = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numQuantite = new System.Windows.Forms.NumericUpDown();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnTerminer = new System.Windows.Forms.Button();
            this.dgvProduit = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduit)).BeginInit();
            this.SuspendLayout();
            // 
            // cbMedicament
            // 
            this.cbMedicament.FormattingEnabled = true;
            this.cbMedicament.Location = new System.Drawing.Point(46, 54);
            this.cbMedicament.Name = "cbMedicament";
            this.cbMedicament.Size = new System.Drawing.Size(239, 21);
            this.cbMedicament.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Médicament :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(354, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Quantité :";
            // 
            // numQuantite
            // 
            this.numQuantite.Location = new System.Drawing.Point(357, 54);
            this.numQuantite.Name = "numQuantite";
            this.numQuantite.Size = new System.Drawing.Size(234, 20);
            this.numQuantite.TabIndex = 3;
            // 
            // btnAjouter
            // 
            this.btnAjouter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouter.Location = new System.Drawing.Point(276, 99);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(90, 30);
            this.btnAjouter.TabIndex = 4;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.Location = new System.Drawing.Point(340, 509);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(90, 30);
            this.btnAnnuler.TabIndex = 5;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // btnTerminer
            // 
            this.btnTerminer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTerminer.Location = new System.Drawing.Point(227, 509);
            this.btnTerminer.Name = "btnTerminer";
            this.btnTerminer.Size = new System.Drawing.Size(90, 30);
            this.btnTerminer.TabIndex = 6;
            this.btnTerminer.Text = "Terminer";
            this.btnTerminer.UseVisualStyleBackColor = true;
            this.btnTerminer.Click += new System.EventHandler(this.btnTerminer_Click);
            // 
            // dgvProduit
            // 
            this.dgvProduit.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvProduit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduit.Location = new System.Drawing.Point(12, 185);
            this.dgvProduit.Name = "dgvProduit";
            this.dgvProduit.Size = new System.Drawing.Size(622, 273);
            this.dgvProduit.TabIndex = 7;
            this.dgvProduit.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduit_CellContentClick);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(273, 477);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 17);
            this.lblTotal.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(319, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Liste des produits pour cette vente";
            // 
            // AjouterProduitVente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 568);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvProduit);
            this.Controls.Add(this.btnTerminer);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.numQuantite);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbMedicament);
            this.Name = "AjouterProduitVente";
            this.Text = "AjouterProduitVente";
            ((System.ComponentModel.ISupportInitialize)(this.numQuantite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbMedicament;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numQuantite;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Button btnTerminer;
        private System.Windows.Forms.DataGridView dgvProduit;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label3;
    }
}