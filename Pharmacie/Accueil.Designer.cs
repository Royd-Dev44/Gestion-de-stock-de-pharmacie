namespace Pharmacie
{
    partial class Accueil
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panelKPIs = new System.Windows.Forms.Panel();
            this.lblValeurStock = new System.Windows.Forms.Label();
            this.lblValeurStockDesc = new System.Windows.Forms.Label();
            this.lblMedicamentsRupture = new System.Windows.Forms.Label();
            this.lblMedicamentsRuptureDesc = new System.Windows.Forms.Label();
            this.lblMedicamentsExpires = new System.Windows.Forms.Label();
            this.lblMedicamentsExpiresDesc = new System.Windows.Forms.Label();
            this.lblTotalMedicaments = new System.Windows.Forms.Label();
            this.lblTotalMedicamentsDesc = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelCalendar = new System.Windows.Forms.Panel();
            this.panelExpiring = new System.Windows.Forms.Panel();
            this.chartVentes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewExpiring = new System.Windows.Forms.DataGridView();
            this.dataGridViewStockOut = new System.Windows.Forms.DataGridView();
            this.panelKPIs.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelCalendar.SuspendLayout();
            this.panelExpiring.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentes)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpiring)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockOut)).BeginInit();
            this.SuspendLayout();
            // 
            // panelKPIs
            // 
            this.panelKPIs.BackColor = System.Drawing.Color.White;
            this.panelKPIs.Controls.Add(this.lblValeurStock);
            this.panelKPIs.Controls.Add(this.lblValeurStockDesc);
            this.panelKPIs.Controls.Add(this.lblMedicamentsRupture);
            this.panelKPIs.Controls.Add(this.lblMedicamentsRuptureDesc);
            this.panelKPIs.Controls.Add(this.lblMedicamentsExpires);
            this.panelKPIs.Controls.Add(this.lblMedicamentsExpiresDesc);
            this.panelKPIs.Controls.Add(this.lblTotalMedicaments);
            this.panelKPIs.Controls.Add(this.lblTotalMedicamentsDesc);
            this.panelKPIs.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelKPIs.Location = new System.Drawing.Point(0, 0);
            this.panelKPIs.Name = "panelKPIs";
            this.panelKPIs.Size = new System.Drawing.Size(1174, 100);
            this.panelKPIs.TabIndex = 0;
            // 
            // lblValeurStock
            // 
            this.lblValeurStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValeurStock.ForeColor = System.Drawing.Color.Blue;
            this.lblValeurStock.Location = new System.Drawing.Point(950, 20);
            this.lblValeurStock.Name = "lblValeurStock";
            this.lblValeurStock.Size = new System.Drawing.Size(200, 30);
            this.lblValeurStock.TabIndex = 6;
            this.lblValeurStock.Text = "0";
            this.lblValeurStock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblValeurStockDesc
            // 
            this.lblValeurStockDesc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValeurStockDesc.Location = new System.Drawing.Point(950, 50);
            this.lblValeurStockDesc.Name = "lblValeurStockDesc";
            this.lblValeurStockDesc.Size = new System.Drawing.Size(200, 30);
            this.lblValeurStockDesc.TabIndex = 7;
            this.lblValeurStockDesc.Text = "Valeur du stock";
            this.lblValeurStockDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMedicamentsRupture
            // 
            this.lblMedicamentsRupture.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedicamentsRupture.ForeColor = System.Drawing.Color.Red;
            this.lblMedicamentsRupture.Location = new System.Drawing.Point(650, 20);
            this.lblMedicamentsRupture.Name = "lblMedicamentsRupture";
            this.lblMedicamentsRupture.Size = new System.Drawing.Size(200, 30);
            this.lblMedicamentsRupture.TabIndex = 4;
            this.lblMedicamentsRupture.Text = "0";
            this.lblMedicamentsRupture.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMedicamentsRuptureDesc
            // 
            this.lblMedicamentsRuptureDesc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedicamentsRuptureDesc.Location = new System.Drawing.Point(650, 50);
            this.lblMedicamentsRuptureDesc.Name = "lblMedicamentsRuptureDesc";
            this.lblMedicamentsRuptureDesc.Size = new System.Drawing.Size(200, 30);
            this.lblMedicamentsRuptureDesc.TabIndex = 5;
            this.lblMedicamentsRuptureDesc.Text = "En rupture de stock";
            this.lblMedicamentsRuptureDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMedicamentsExpires
            // 
            this.lblMedicamentsExpires.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedicamentsExpires.ForeColor = System.Drawing.Color.Orange;
            this.lblMedicamentsExpires.Location = new System.Drawing.Point(350, 20);
            this.lblMedicamentsExpires.Name = "lblMedicamentsExpires";
            this.lblMedicamentsExpires.Size = new System.Drawing.Size(200, 30);
            this.lblMedicamentsExpires.TabIndex = 2;
            this.lblMedicamentsExpires.Text = "0";
            this.lblMedicamentsExpires.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMedicamentsExpiresDesc
            // 
            this.lblMedicamentsExpiresDesc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedicamentsExpiresDesc.Location = new System.Drawing.Point(350, 50);
            this.lblMedicamentsExpiresDesc.Name = "lblMedicamentsExpiresDesc";
            this.lblMedicamentsExpiresDesc.Size = new System.Drawing.Size(200, 30);
            this.lblMedicamentsExpiresDesc.TabIndex = 3;
            this.lblMedicamentsExpiresDesc.Text = "À surveiller (péremption < 30j)";
            this.lblMedicamentsExpiresDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalMedicaments
            // 
            this.lblTotalMedicaments.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMedicaments.ForeColor = System.Drawing.Color.Green;
            this.lblTotalMedicaments.Location = new System.Drawing.Point(50, 20);
            this.lblTotalMedicaments.Name = "lblTotalMedicaments";
            this.lblTotalMedicaments.Size = new System.Drawing.Size(200, 30);
            this.lblTotalMedicaments.TabIndex = 0;
            this.lblTotalMedicaments.Text = "0";
            this.lblTotalMedicaments.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalMedicamentsDesc
            // 
            this.lblTotalMedicamentsDesc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMedicamentsDesc.Location = new System.Drawing.Point(50, 50);
            this.lblTotalMedicamentsDesc.Name = "lblTotalMedicamentsDesc";
            this.lblTotalMedicamentsDesc.Size = new System.Drawing.Size(200, 30);
            this.lblTotalMedicamentsDesc.TabIndex = 1;
            this.lblTotalMedicamentsDesc.Text = "Médicaments en stock";
            this.lblTotalMedicamentsDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panel2);
            this.panelMain.Controls.Add(this.panel1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 100);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1174, 761);
            this.panelMain.TabIndex = 1;
            // 
            // panelCalendar
            // 
            this.panelCalendar.Controls.Add(this.dataGridViewExpiring);
            this.panelCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCalendar.Location = new System.Drawing.Point(0, 0);
            this.panelCalendar.Name = "panelCalendar";
            this.panelCalendar.Padding = new System.Windows.Forms.Padding(20, 20, 0, 20);
            this.panelCalendar.Size = new System.Drawing.Size(552, 368);
            this.panelCalendar.TabIndex = 4;
            // 
            // panelExpiring
            // 
            this.panelExpiring.Controls.Add(this.dataGridViewStockOut);
            this.panelExpiring.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelExpiring.Location = new System.Drawing.Point(552, 0);
            this.panelExpiring.Name = "panelExpiring";
            this.panelExpiring.Padding = new System.Windows.Forms.Padding(20);
            this.panelExpiring.Size = new System.Drawing.Size(622, 368);
            this.panelExpiring.TabIndex = 1;
            // 
            // chartVentes
            // 
            chartArea2.Name = "ChartArea1";
            this.chartVentes.ChartAreas.Add(chartArea2);
            this.chartVentes.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartVentes.Legends.Add(legend2);
            this.chartVentes.Location = new System.Drawing.Point(20, 0);
            this.chartVentes.Margin = new System.Windows.Forms.Padding(20);
            this.chartVentes.Name = "chartVentes";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Ventes";
            this.chartVentes.Series.Add(series2);
            this.chartVentes.Size = new System.Drawing.Size(1134, 373);
            this.chartVentes.TabIndex = 2;
            this.chartVentes.Text = "chart1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelCalendar);
            this.panel1.Controls.Add(this.panelExpiring);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1174, 368);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chartVentes);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 368);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(20, 0, 20, 20);
            this.panel2.Size = new System.Drawing.Size(1174, 393);
            this.panel2.TabIndex = 6;
            // 
            // dataGridViewExpiring
            // 
            this.dataGridViewExpiring.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewExpiring.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExpiring.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewExpiring.Location = new System.Drawing.Point(20, 20);
            this.dataGridViewExpiring.Margin = new System.Windows.Forms.Padding(20);
            this.dataGridViewExpiring.Name = "dataGridViewExpiring";
            this.dataGridViewExpiring.Size = new System.Drawing.Size(532, 328);
            this.dataGridViewExpiring.TabIndex = 2;
            // 
            // dataGridViewStockOut
            // 
            this.dataGridViewStockOut.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewStockOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStockOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewStockOut.Location = new System.Drawing.Point(20, 20);
            this.dataGridViewStockOut.Margin = new System.Windows.Forms.Padding(20);
            this.dataGridViewStockOut.Name = "dataGridViewStockOut";
            this.dataGridViewStockOut.Size = new System.Drawing.Size(582, 328);
            this.dataGridViewStockOut.TabIndex = 5;
            // 
            // Accueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 861);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelKPIs);
            this.Name = "Accueil";
            this.Text = "Tableau de bord";
            this.panelKPIs.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelCalendar.ResumeLayout(false);
            this.panelExpiring.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartVentes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpiring)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockOut)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelKPIs;
        private System.Windows.Forms.Label lblTotalMedicaments;
        private System.Windows.Forms.Label lblTotalMedicamentsDesc;
        private System.Windows.Forms.Label lblMedicamentsExpires;
        private System.Windows.Forms.Label lblMedicamentsExpiresDesc;
        private System.Windows.Forms.Label lblMedicamentsRupture;
        private System.Windows.Forms.Label lblMedicamentsRuptureDesc;
        private System.Windows.Forms.Label lblValeurStock;
        private System.Windows.Forms.Label lblValeurStockDesc;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelExpiring;
        private System.Windows.Forms.Panel panelCalendar;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVentes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridViewExpiring;
        private System.Windows.Forms.DataGridView dataGridViewStockOut;
    }
}