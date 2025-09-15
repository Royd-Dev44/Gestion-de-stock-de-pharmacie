using System;
using System.Windows.Forms;

namespace Pharmacie
{
    partial class MedicamentForm
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
            this.dgvMedicaments = new System.Windows.Forms.DataGridView();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTout = new System.Windows.Forms.Button();
            this.btnEnstock = new System.Windows.Forms.Button();
            this.btnRupture = new System.Windows.Forms.Button();
            this.btnExpire = new System.Windows.Forms.Button();
            this.txtRecherche = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicaments)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMedicaments
            // 
            this.dgvMedicaments.AllowUserToOrderColumns = true;
            this.dgvMedicaments.BackgroundColor = System.Drawing.Color.White;
            this.dgvMedicaments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicaments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMedicaments.Location = new System.Drawing.Point(0, 0);
            this.dgvMedicaments.Name = "dgvMedicaments";
            this.dgvMedicaments.Size = new System.Drawing.Size(1174, 726);
            this.dgvMedicaments.TabIndex = 0;
            this.dgvMedicaments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMedicaments_CellContentClick);
            // 
            // btnAjouter
            // 
            this.btnAjouter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouter.Location = new System.Drawing.Point(22, 91);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(187, 30);
            this.btnAjouter.TabIndex = 1;
            this.btnAjouter.Text = "Ajouter  un produit";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnAjouter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1174, 135);
            this.panel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(426, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "GESTION ET VUE D\'ENSEMBLE DES PRODUITS ";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.btnTout);
            this.panel3.Controls.Add(this.btnEnstock);
            this.panel3.Controls.Add(this.btnRupture);
            this.panel3.Controls.Add(this.btnExpire);
            this.panel3.Controls.Add(this.txtRecherche);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(459, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(715, 135);
            this.panel3.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Recherche";
            // 
            // btnTout
            // 
            this.btnTout.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTout.Location = new System.Drawing.Point(34, 91);
            this.btnTout.Name = "btnTout";
            this.btnTout.Size = new System.Drawing.Size(149, 30);
            this.btnTout.TabIndex = 15;
            this.btnTout.Text = "Tout";
            this.btnTout.UseVisualStyleBackColor = true;
            this.btnTout.Click += new System.EventHandler(this.btnTout_Click);
            // 
            // btnEnstock
            // 
            this.btnEnstock.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnstock.Location = new System.Drawing.Point(202, 91);
            this.btnEnstock.Name = "btnEnstock";
            this.btnEnstock.Size = new System.Drawing.Size(149, 30);
            this.btnEnstock.TabIndex = 14;
            this.btnEnstock.Text = "En stock";
            this.btnEnstock.UseVisualStyleBackColor = true;
            this.btnEnstock.Click += new System.EventHandler(this.btnEnstock_Click);
            // 
            // btnRupture
            // 
            this.btnRupture.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRupture.Location = new System.Drawing.Point(371, 91);
            this.btnRupture.Name = "btnRupture";
            this.btnRupture.Size = new System.Drawing.Size(149, 30);
            this.btnRupture.TabIndex = 13;
            this.btnRupture.Text = "Rupture";
            this.btnRupture.UseVisualStyleBackColor = true;
            this.btnRupture.Click += new System.EventHandler(this.btnRupture_Click);
            // 
            // btnExpire
            // 
            this.btnExpire.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpire.Location = new System.Drawing.Point(535, 91);
            this.btnExpire.Name = "btnExpire";
            this.btnExpire.Size = new System.Drawing.Size(149, 30);
            this.btnExpire.TabIndex = 12;
            this.btnExpire.Text = "Expirés";
            this.btnExpire.UseVisualStyleBackColor = true;
            this.btnExpire.Click += new System.EventHandler(this.btnExpire_Click);
            // 
            // txtRecherche
            // 
            this.txtRecherche.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecherche.Location = new System.Drawing.Point(202, 34);
            this.txtRecherche.Name = "txtRecherche";
            this.txtRecherche.Size = new System.Drawing.Size(482, 25);
            this.txtRecherche.TabIndex = 11;
            this.txtRecherche.TextChanged += new System.EventHandler(this.txtRecherche_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvMedicaments);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 135);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1174, 726);
            this.panel2.TabIndex = 8;
            // 
            // MedicamentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 861);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MedicamentForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MedicamentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicaments)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        
        #endregion

        private System.Windows.Forms.DataGridView dgvMedicaments;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Panel panel3;
        private Button btnTout;
        private Button btnEnstock;
        private Button btnRupture;
        private Button btnExpire;
        private TextBox txtRecherche;
        private Label label1;
        private Label label2;
    }
}