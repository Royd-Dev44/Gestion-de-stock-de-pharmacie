using Pharmacie.Data;
using Pharmacie.Models;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Pharmacie
{
    public partial class Accueil : Form
    {
        private readonly CultureInfo cultureMG = new CultureInfo("mg-MG");

        public Accueil()
        {
            InitializeComponent();
            LoadDashboard();
            ConfigurerDataGridViews();
        }

        private void ConfigurerDataGridViews()
        {
            // Configuration commune pour les deux DataGridView
            foreach (DataGridView dgv in new[] { dataGridViewExpiring, dataGridViewStockOut })
            {
                dgv.BorderStyle = BorderStyle.None;
                dgv.EnableHeadersVisualStyles = false;
                dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dgv.GridColor = Color.FromArgb(240, 240, 240);

                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
                dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                dgv.ColumnHeadersHeight = 40;

                dgv.RowTemplate.Height = 35;
                dgv.RowTemplate.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);
                dgv.DefaultCellStyle.BackColor = Color.White;
                dgv.DefaultCellStyle.ForeColor = Color.Black;
                dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(231, 246, 253);
                dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
                dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);

                dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv.AllowUserToAddRows = false;
                dgv.ReadOnly = true;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Double buffering pour améliorer les performances
                typeof(DataGridView).InvokeMember("DoubleBuffered",
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.SetProperty,
                    null, dgv, new object[] { true });
            }

            // Style spécifique pour la grille des médicaments expirés
            dataGridViewExpiring.CellFormatting += (sender, e) =>
            {
                if (e.ColumnIndex == dataGridViewExpiring.Columns["Jours"].Index && e.Value != null)
                {
                    int jours = Convert.ToInt32(e.Value);
                    if (jours <= 7)
                    {
                        e.CellStyle.BackColor = Color.FromArgb(255, 205, 210);
                        e.CellStyle.ForeColor = Color.Black;
                        e.CellStyle.Font = new Font(dataGridViewExpiring.Font, FontStyle.Bold);
                    }
                    else if (jours <= 30)
                    {
                        e.CellStyle.BackColor = Color.FromArgb(255, 243, 224);
                        e.CellStyle.ForeColor = Color.Black;
                    }
                }
            };

            // Style pour la grille des ruptures de stock
            dataGridViewStockOut.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(108, 117, 125);
        }

        private void LoadDashboard()
        {
            LoadKPIs();
            LoadSalesChart();
            LoadExpiringMedications();
            LoadStockOutMedications();
        }

        private void LoadKPIs()
        {
            // Nombre total de médicaments en stock
            var medicamentsEnStock = MedicamentRepository.GetAllInStock();
            lblTotalMedicaments.Text = medicamentsEnStock.Count.ToString("N0", cultureMG);

            // Valeur totale du stock en Ariary
            decimal valeurStock = medicamentsEnStock.Sum(m => m.Prix * m.QuantiteRestante);
            lblValeurStock.Text = valeurStock.ToString("N0", cultureMG) + " Ar";

            // Médicaments bientôt périmés
            var medicamentsExpires = MedicamentRepository.GetPresqueExpires(30);
            lblMedicamentsExpires.Text = medicamentsExpires.Count.ToString("N0", cultureMG);

            // Médicaments en rupture
            var medicamentsRupture = MedicamentRepository.GetEnRupture();
            lblMedicamentsRupture.Text = medicamentsRupture.Count.ToString("N0", cultureMG);
        }

        private void LoadSalesChart()
        {
            chartVentes.Series.Clear();
            chartVentes.Titles.Clear();
            chartVentes.Titles.Add("Ventes des 15 derniers jours (en Ar)");

            // Configurer les axes
            chartVentes.ChartAreas[0].AxisX.Title = "Date";
            chartVentes.ChartAreas[0].AxisY.Title = "Montant (Ar)";
            chartVentes.ChartAreas[0].AxisX.Interval = 1;
            chartVentes.ChartAreas[0].AxisX.LabelStyle.Angle = -45;

            var series = new Series("Ventes")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                Color = Color.SteelBlue,
                XValueType = ChartValueType.Date,
                YValueType = ChartValueType.Double,
                LabelFormat = "N0"
            };

            // Récupérer les ventes des 15 derniers jours
            var dateDebut = DateTime.Today.AddDays(-14);
            var ventes = VenteRepository.GetAll()
                           .Where(v => v.DateVente >= dateDebut)
                           .GroupBy(v => v.DateVente.Date)
                           .OrderBy(g => g.Key)
                           .Select(g => new
                           {
                               Date = g.Key,
                               Total = g.Sum(v => v.Total)
                           })
                           .ToList();

            // Remplir les jours manquants avec 0
            for (var date = dateDebut; date <= DateTime.Today; date = date.AddDays(1))
            {
                var venteDuJour = ventes.FirstOrDefault(v => v.Date == date);
                series.Points.AddXY(date, venteDuJour?.Total ?? 0);
            }

            chartVentes.Series.Add(series);

            // Formater en Ariary sans décimales
            chartVentes.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM";
            chartVentes.ChartAreas[0].AxisY.LabelStyle.Format = "N0";
            chartVentes.ChartAreas[0].RecalculateAxesScale();
        }

        private void LoadExpiringMedications()
        {
            var medicamentsExpires = MedicamentRepository.GetPresqueExpires(30);
            dataGridViewExpiring.DataSource = medicamentsExpires.Select(m => new
            {
                Médicament = m.Nom,
                Quantité = m.QuantiteRestante.ToString("N0", cultureMG),
                Expiration = m.DateExpiration?.ToString("dd/MM/yyyy"),
                Jours = m.JoursRestants
            }).ToList();
        }

        private void LoadStockOutMedications()
        {
            var medicamentsRupture = MedicamentRepository.GetEnRupture();
            dataGridViewStockOut.DataSource = medicamentsRupture.Select(m => new
            {
                Médicament = m.Nom,
                Prix = (m.Prix * m.QuantiteRestante).ToString("N0", cultureMG) + " Ar"
            }).ToList();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void chartVentes_Click(object sender, EventArgs e)
        {
            var hitTest = chartVentes.HitTest(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);

            if (hitTest.PointIndex >= 0 && hitTest.Series != null)
            {
                string date = hitTest.Series.Points[hitTest.PointIndex].AxisLabel;
                double montant = hitTest.Series.Points[hitTest.PointIndex].YValues[0];

                MessageBox.Show($"Ventes pour le {date}: {montant.ToString("N0", cultureMG)} Ar\n\nCliquez sur 'Actualiser' pour voir les détails.",
                               "Détail des ventes",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
            }
        }
    }
}