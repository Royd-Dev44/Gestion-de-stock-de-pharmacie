namespace Pharmacie
{
    partial class VenteForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnVente = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvVente = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVente)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnVente);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1174, 135);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(433, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 30);
            this.label1.TabIndex = 20;
            this.label1.Text = "LISTE DES VENTES ";
            // 
            // btnVente
            // 
            this.btnVente.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVente.Location = new System.Drawing.Point(50, 95);
            this.btnVente.Name = "btnVente";
            this.btnVente.Size = new System.Drawing.Size(187, 30);
            this.btnVente.TabIndex = 8;
            this.btnVente.Text = "Effectuer une nouvelle Vente";
            this.btnVente.UseVisualStyleBackColor = true;
            this.btnVente.Click += new System.EventHandler(this.btnVente_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvVente);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 135);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1174, 726);
            this.panel2.TabIndex = 1;
            // 
            // dgvVente
            // 
            this.dgvVente.BackgroundColor = System.Drawing.Color.White;
            this.dgvVente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVente.Location = new System.Drawing.Point(0, 0);
            this.dgvVente.Name = "dgvVente";
            this.dgvVente.Size = new System.Drawing.Size(1174, 726);
            this.dgvVente.TabIndex = 1;
            this.dgvVente.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVente_CellContentClick);
            // 
            // VenteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 861);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "VenteForm";
            this.Text = "VenteForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVente)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnVente;
        private System.Windows.Forms.DataGridView dgvVente;
        private System.Windows.Forms.Label label1;
    }
}