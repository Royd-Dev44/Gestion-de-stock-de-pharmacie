namespace Pharmacie
{
    partial class SelectionClientForm
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
            this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            this.dgvClient = new System.Windows.Forms.DataGridView();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.cbSansClient = new System.Windows.Forms.CheckBox();
            this.btnConfirmer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClient)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(76, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "sélectionnez le client ";
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CacheAge = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.EnableCaching = false;
            this.mySqlCommand1.Transaction = null;
            // 
            // dgvClient
            // 
            this.dgvClient.BackgroundColor = System.Drawing.Color.White;
            this.dgvClient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClient.Location = new System.Drawing.Point(24, 56);
            this.dgvClient.Name = "dgvClient";
            this.dgvClient.Size = new System.Drawing.Size(813, 365);
            this.dgvClient.TabIndex = 2;
            // 
            // btnAjouter
            // 
            this.btnAjouter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouter.Location = new System.Drawing.Point(644, 12);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(193, 30);
            this.btnAjouter.TabIndex = 3;
            this.btnAjouter.Text = "Ajouter un client";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.Location = new System.Drawing.Point(599, 441);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(90, 30);
            this.btnAnnuler.TabIndex = 4;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // cbSansClient
            // 
            this.cbSansClient.AutoSize = true;
            this.cbSansClient.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSansClient.Location = new System.Drawing.Point(107, 443);
            this.cbSansClient.Name = "cbSansClient";
            this.cbSansClient.Size = new System.Drawing.Size(211, 21);
            this.cbSansClient.TabIndex = 5;
            this.cbSansClient.Text = "Enregistrer sans client associé";
            this.cbSansClient.UseVisualStyleBackColor = true;
            // 
            // btnConfirmer
            // 
            this.btnConfirmer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmer.Location = new System.Drawing.Point(495, 441);
            this.btnConfirmer.Name = "btnConfirmer";
            this.btnConfirmer.Size = new System.Drawing.Size(90, 30);
            this.btnConfirmer.TabIndex = 6;
            this.btnConfirmer.Text = "Confirmer";
            this.btnConfirmer.UseVisualStyleBackColor = true;
            this.btnConfirmer.Click += new System.EventHandler(this.btnConfirmer_Click);
            // 
            // SelectionClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 488);
            this.Controls.Add(this.btnConfirmer);
            this.Controls.Add(this.cbSansClient);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.dgvClient);
            this.Controls.Add(this.label1);
            this.Name = "SelectionClientForm";
            this.Text = "SelectionClient";
            ((System.ComponentModel.ISupportInitialize)(this.dgvClient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private System.Windows.Forms.DataGridView dgvClient;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.CheckBox cbSansClient;
        private System.Windows.Forms.Button btnConfirmer;
    }
}