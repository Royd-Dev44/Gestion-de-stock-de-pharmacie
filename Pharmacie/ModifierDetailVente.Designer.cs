namespace Pharmacie
{
    partial class ModifierDetailVente
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numQuantite = new System.Windows.Forms.NumericUpDown();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblPrixUnitaire = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantite)).BeginInit();
            this.SuspendLayout();
            // 
            // cbMedicament
            // 
            this.cbMedicament.FormattingEnabled = true;
            this.cbMedicament.Location = new System.Drawing.Point(35, 58);
            this.cbMedicament.Name = "cbMedicament";
            this.cbMedicament.Size = new System.Drawing.Size(226, 21);
            this.cbMedicament.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Quantité :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Médicament :";
            // 
            // numQuantite
            // 
            this.numQuantite.Location = new System.Drawing.Point(33, 132);
            this.numQuantite.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numQuantite.Name = "numQuantite";
            this.numQuantite.Size = new System.Drawing.Size(228, 20);
            this.numQuantite.TabIndex = 22;
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(179, 259);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(75, 23);
            this.btnAnnuler.TabIndex = 27;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
         
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.Location = new System.Drawing.Point(48, 259);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(75, 23);
            this.btnEnregistrer.TabIndex = 26;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(64, 206);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(37, 13);
            this.lblTotal.TabIndex = 28;
            this.lblTotal.Text = "Total :";
            // 
            // lblPrixUnitaire
            // 
            this.lblPrixUnitaire.AutoSize = true;
            this.lblPrixUnitaire.Location = new System.Drawing.Point(64, 180);
            this.lblPrixUnitaire.Name = "lblPrixUnitaire";
            this.lblPrixUnitaire.Size = new System.Drawing.Size(67, 13);
            this.lblPrixUnitaire.TabIndex = 29;
            this.lblPrixUnitaire.Text = "Prix unitaire :";
            // 
            // ModifierDetailVente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 327);
            this.Controls.Add(this.lblPrixUnitaire);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.cbMedicament);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numQuantite);
            this.Name = "ModifierDetailVente";
            this.Text = "ModifierDetailVente";
            ((System.ComponentModel.ISupportInitialize)(this.numQuantite)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbMedicament;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numQuantite;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblPrixUnitaire;
    }
}