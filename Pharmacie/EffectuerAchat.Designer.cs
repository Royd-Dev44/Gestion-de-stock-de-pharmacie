namespace Pharmacie
{
    partial class EffectuerAchat
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtFournisseur = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnTerminer = new System.Windows.Forms.Button();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpExpiration = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrix = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numQuantite = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbMedicament = new System.Windows.Forms.ComboBox();
            this.DgvLots = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLots)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtFournisseur);
            this.panel1.Controls.Add(this.txtTotal);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnAnnuler);
            this.panel1.Controls.Add(this.btnTerminer);
            this.panel1.Controls.Add(this.btnAjouter);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dtpExpiration);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtPrix);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.numQuantite);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbMedicament);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(688, 295);
            this.panel1.TabIndex = 12;
            // 
            // txtFournisseur
            // 
            this.txtFournisseur.AutoSize = true;
            this.txtFournisseur.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFournisseur.Location = new System.Drawing.Point(246, 232);
            this.txtFournisseur.Name = "txtFournisseur";
            this.txtFournisseur.Size = new System.Drawing.Size(45, 17);
            this.txtFournisseur.TabIndex = 35;
            this.txtFournisseur.Text = "label8";
            // 
            // txtTotal
            // 
            this.txtTotal.AutoSize = true;
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(457, 232);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(33, 17);
            this.txtTotal.TabIndex = 34;
            this.txtTotal.Text = "0 Ar";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 25);
            this.label1.TabIndex = 33;
            this.label1.Text = "Liste des produits pour cette achat :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(403, 232);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 17);
            this.label7.TabIndex = 32;
            this.label7.Text = "Total :";
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.Location = new System.Drawing.Point(391, 173);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(90, 30);
            this.btnAnnuler.TabIndex = 31;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // btnTerminer
            // 
            this.btnTerminer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTerminer.Location = new System.Drawing.Point(295, 173);
            this.btnTerminer.Name = "btnTerminer";
            this.btnTerminer.Size = new System.Drawing.Size(90, 30);
            this.btnTerminer.TabIndex = 30;
            this.btnTerminer.Text = "Terminer";
            this.btnTerminer.UseVisualStyleBackColor = true;
            this.btnTerminer.Click += new System.EventHandler(this.btnTerminer_Click);
            // 
            // btnAjouter
            // 
            this.btnAjouter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouter.Location = new System.Drawing.Point(199, 173);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(90, 30);
            this.btnAjouter.TabIndex = 29;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(377, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 17);
            this.label6.TabIndex = 28;
            this.label6.Text = "Date d\'expiration :";
            // 
            // dtpExpiration
            // 
            this.dtpExpiration.Location = new System.Drawing.Point(380, 112);
            this.dtpExpiration.Name = "dtpExpiration";
            this.dtpExpiration.Size = new System.Drawing.Size(230, 20);
            this.dtpExpiration.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(58, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 17);
            this.label5.TabIndex = 26;
            this.label5.Text = "Prix unitaire :";
            // 
            // txtPrix
            // 
            this.txtPrix.Location = new System.Drawing.Point(61, 115);
            this.txtPrix.Name = "txtPrix";
            this.txtPrix.Size = new System.Drawing.Size(230, 20);
            this.txtPrix.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(377, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 17);
            this.label4.TabIndex = 24;
            this.label4.Text = "Quantite :";
            // 
            // numQuantite
            // 
            this.numQuantite.Location = new System.Drawing.Point(380, 49);
            this.numQuantite.Name = "numQuantite";
            this.numQuantite.Size = new System.Drawing.Size(230, 20);
            this.numQuantite.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(152, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "Fournisseur :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "Produit :";
            // 
            // cbMedicament
            // 
            this.cbMedicament.FormattingEnabled = true;
            this.cbMedicament.Location = new System.Drawing.Point(61, 49);
            this.cbMedicament.Name = "cbMedicament";
            this.cbMedicament.Size = new System.Drawing.Size(230, 21);
            this.cbMedicament.TabIndex = 19;
            // 
            // DgvLots
            // 
            this.DgvLots.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.DgvLots.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvLots.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DgvLots.Location = new System.Drawing.Point(0, 295);
            this.DgvLots.Name = "DgvLots";
            this.DgvLots.Size = new System.Drawing.Size(688, 345);
            this.DgvLots.TabIndex = 11;
            // 
            // EffectuerAchat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 640);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DgvLots);
            this.Name = "EffectuerAchat";
            this.Text = "EffectuerAchat";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLots)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txtFournisseur;
        private System.Windows.Forms.Label txtTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Button btnTerminer;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpExpiration;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrix;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numQuantite;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMedicament;
        private System.Windows.Forms.DataGridView DgvLots;
    }
}