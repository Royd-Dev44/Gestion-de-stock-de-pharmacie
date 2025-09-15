namespace Pharmacie
{
    partial class DetailVenteForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblIdClient = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblClient = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();

            // panelHeader (remplace panel1)
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelHeader.Controls.Add(this.lblIdClient);
            this.panelHeader.Controls.Add(this.label4);
            this.panelHeader.Controls.Add(this.lblTotal);
            this.panelHeader.Controls.Add(this.lblClient);
            this.panelHeader.Controls.Add(this.label2);
            this.panelHeader.Controls.Add(this.lblDate);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(800, 64);
            this.panelHeader.TabIndex = 0;

            // lblIdClient
            this.lblIdClient.AutoSize = true;
            this.lblIdClient.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblIdClient.Location = new System.Drawing.Point(86, 26);
            this.lblIdClient.Name = "lblIdClient";
            this.lblIdClient.Size = new System.Drawing.Size(38, 17);
            this.lblIdClient.TabIndex = 10;
            this.lblIdClient.Text = "label";

            // label4
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(564, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Valeur total : ";

            // lblTotal
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(650, 26);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(38, 17);
            this.lblTotal.TabIndex = 8;
            this.lblTotal.Text = "label";

            // lblClient
            this.lblClient.AutoSize = true;
            this.lblClient.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblClient.Location = new System.Drawing.Point(130, 26);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(42, 17);
            this.lblClient.TabIndex = 5;
            this.lblClient.Text = "label ";

            // label2
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(19, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Client N°: ";

            // lblDate
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(348, 26);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(45, 17);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "label2";

            // dgvDetails
            this.dgvDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(0, 64);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.Size = new System.Drawing.Size(800, 386);
            this.dgvDetails.TabIndex = 1; // Changé de 0 à 1 pour éviter les conflits

            // DetailVenteForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.panelHeader);
            this.Name = "DetailVenteForm";
            this.Text = "DetailVente";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblIdClient;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DataGridView dgvDetails;
    }
}