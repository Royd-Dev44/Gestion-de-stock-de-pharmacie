namespace Pharmacie
{
    partial class ModifierLots
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
            this.label1 = new System.Windows.Forms.Label();
            this.numQuantite = new System.Windows.Forms.NumericUpDown();
            this.dtpExpiration = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrix = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.txtLot = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPrixTotal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbStatut = new System.Windows.Forms.ComboBox();
            this.cbMedicament = new System.Windows.Forms.ComboBox();
            this.txtAjout = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantite)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Modification du ";
            // 
            // numQuantite
            // 
            this.numQuantite.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numQuantite.Location = new System.Drawing.Point(50, 204);
            this.numQuantite.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numQuantite.Name = "numQuantite";
            this.numQuantite.Size = new System.Drawing.Size(228, 25);
            this.numQuantite.TabIndex = 2;
            // 
            // dtpExpiration
            // 
            this.dtpExpiration.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpExpiration.Location = new System.Drawing.Point(50, 348);
            this.dtpExpiration.Name = "dtpExpiration";
            this.dtpExpiration.Size = new System.Drawing.Size(228, 25);
            this.dtpExpiration.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Médicament :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Quantité :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(47, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Prix Unitaire :";
            // 
            // txtPrix
            // 
            this.txtPrix.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrix.Location = new System.Drawing.Point(50, 279);
            this.txtPrix.Name = "txtPrix";
            this.txtPrix.Size = new System.Drawing.Size(87, 25);
            this.txtPrix.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(49, 327);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Date d\'expiration :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(47, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Ajouté le ";
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnregistrer.Location = new System.Drawing.Point(52, 472);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(90, 30);
            this.btnEnregistrer.TabIndex = 11;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.Location = new System.Drawing.Point(188, 472);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(90, 30);
            this.btnAnnuler.TabIndex = 12;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click_1);
            // 
            // txtLot
            // 
            this.txtLot.AutoSize = true;
            this.txtLot.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLot.Location = new System.Drawing.Point(154, 31);
            this.txtLot.Name = "txtLot";
            this.txtLot.Size = new System.Drawing.Size(20, 17);
            this.txtLot.TabIndex = 24;
            this.txtLot.Text = "M";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(182, 255);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Prix Total :";
            // 
            // txtPrixTotal
            // 
            this.txtPrixTotal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrixTotal.Location = new System.Drawing.Point(181, 279);
            this.txtPrixTotal.Name = "txtPrixTotal";
            this.txtPrixTotal.Size = new System.Drawing.Size(97, 25);
            this.txtPrixTotal.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(82, 404);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 17);
            this.label8.TabIndex = 19;
            this.label8.Text = "Statut :";
            // 
            // cbStatut
            // 
            this.cbStatut.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStatut.FormattingEnabled = true;
            this.cbStatut.Location = new System.Drawing.Point(141, 401);
            this.cbStatut.Name = "cbStatut";
            this.cbStatut.Size = new System.Drawing.Size(121, 25);
            this.cbStatut.TabIndex = 20;
            // 
            // cbMedicament
            // 
            this.cbMedicament.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMedicament.FormattingEnabled = true;
            this.cbMedicament.Location = new System.Drawing.Point(52, 130);
            this.cbMedicament.Name = "cbMedicament";
            this.cbMedicament.Size = new System.Drawing.Size(226, 25);
            this.cbMedicament.TabIndex = 21;
            // 
            // txtAjout
            // 
            this.txtAjout.AutoSize = true;
            this.txtAjout.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAjout.Location = new System.Drawing.Point(112, 54);
            this.txtAjout.Name = "txtAjout";
            this.txtAjout.Size = new System.Drawing.Size(16, 17);
            this.txtAjout.TabIndex = 22;
            this.txtAjout.Text = "n";
            // 
            // ModifierLots
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 538);
            this.Controls.Add(this.txtLot);
            this.Controls.Add(this.txtAjout);
            this.Controls.Add(this.cbMedicament);
            this.Controls.Add(this.cbStatut);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPrixTotal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPrix);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpExpiration);
            this.Controls.Add(this.numQuantite);
            this.Controls.Add(this.label1);
            this.Name = "ModifierLots";
            this.Text = "ModifierLots";
            ((System.ComponentModel.ISupportInitialize)(this.numQuantite)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numQuantite;
        private System.Windows.Forms.DateTimePicker dtpExpiration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrix;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Label txtLot;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPrixTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbStatut;
        private System.Windows.Forms.ComboBox cbMedicament;
        private System.Windows.Forms.Label txtAjout;
    }
}