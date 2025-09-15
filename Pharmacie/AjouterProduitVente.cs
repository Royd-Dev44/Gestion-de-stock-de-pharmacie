using Pharmacie.Data;
using Pharmacie.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Pharmacie
{
    public partial class AjouterProduitVente : Form
    {
        private int? clientId;
        private List<DetailVentePanier> panier = new List<DetailVentePanier>();
        private int hoveredRowIndex = -1;
        private int hoveredColumnIndex = -1;

        public AjouterProduitVente(int? clientId)
        {
            InitializeComponent();
            this.clientId = clientId;
            ApplyModernStyle();
            LoadMedicaments();

            // Abonnement aux événements pour l'effet de survol
            dgvProduit.CellMouseMove += dgvProduit_CellMouseMove;
            dgvProduit.MouseLeave += dgvProduit_MouseLeave;
            dgvProduit.CellPainting += dgvProduit_CellPainting;
        }

        private void ApplyModernStyle()
        {
            // Style général du formulaire
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.Text = "Ajouter des Produits à la Vente";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Style des contrôles
            cbMedicament.Font = new Font("Segoe UI", 10);
            cbMedicament.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMedicament.Height = 35;

            numQuantite.Font = new Font("Segoe UI", 10);
            numQuantite.Height = 35;


            // Style des boutons
            btnAjouter.BackColor = Color.FromArgb(0, 123, 255);
            btnAjouter.ForeColor = Color.White;
            btnAjouter.FlatStyle = FlatStyle.Flat;
            btnAjouter.FlatAppearance.BorderSize = 0;
            btnAjouter.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnAjouter.Height = 40;
            btnAjouter.Cursor = Cursors.Hand;

            btnTerminer.BackColor = Color.FromArgb(40, 167, 69);
            btnTerminer.ForeColor = Color.White;
            btnTerminer.FlatStyle = FlatStyle.Flat;
            btnTerminer.FlatAppearance.BorderSize = 0;
            btnTerminer.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnTerminer.Height = 40;
            btnTerminer.Cursor = Cursors.Hand;

            btnAnnuler.BackColor = Color.FromArgb(108, 117, 125);
            btnAnnuler.ForeColor = Color.White;
            btnAnnuler.FlatStyle = FlatStyle.Flat;
            btnAnnuler.FlatAppearance.BorderSize = 0;
            btnAnnuler.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnAnnuler.Height = 40;
            btnAnnuler.Cursor = Cursors.Hand;

            // Style du DataGridView (panier)
            ConfigureDataGridViewStyle();
        }

        private void ConfigureDataGridViewStyle()
        {
            dgvProduit.BorderStyle = BorderStyle.None;
            dgvProduit.EnableHeadersVisualStyles = false;
            dgvProduit.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvProduit.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProduit.GridColor = Color.FromArgb(240, 240, 240);

            dgvProduit.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dgvProduit.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProduit.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvProduit.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
            dgvProduit.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvProduit.ColumnHeadersHeight = 60;

            dgvProduit.RowTemplate.Height = 35;
            dgvProduit.RowTemplate.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);
            dgvProduit.DefaultCellStyle.BackColor = Color.White;
            dgvProduit.DefaultCellStyle.ForeColor = Color.Black;
            dgvProduit.DefaultCellStyle.SelectionBackColor = Color.FromArgb(231, 246, 253);
            dgvProduit.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvProduit.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);

            // Style du label Total
            lblTotal.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(44, 62, 80);

            // Double buffering pour éviter le scintillement
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.SetProperty,
                null, dgvProduit, new object[] { true });
        }

        private void LoadMedicaments()
        {
            cbMedicament.DataSource = MedicamentRepository.GetAll();
            cbMedicament.DisplayMember = "Nom";
            cbMedicament.ValueMember = "Id";
            cbMedicament.SelectedIndex = -1;
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (cbMedicament.SelectedItem == null || numQuantite.Value <= 0)
            {
                MessageBox.Show("Veuillez sélectionner un médicament et une quantité valide", "Erreur",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var medicament = (Medicament)cbMedicament.SelectedItem;
            int quantite = (int)numQuantite.Value;

            int stockDisponible = StockRepository.GetQuantiteDisponible(medicament.Id);
            if (quantite > stockDisponible)
            {
                MessageBox.Show($"Stock insuffisant. Quantité disponible: {stockDisponible}", "Erreur",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var item = new DetailVentePanier
            {
                IdMedicament = medicament.Id,
                NomMedicament = medicament.Nom,
                Quantite = quantite,
                PrixUnitaire = medicament.Prix,
                Total = medicament.Prix * quantite
            };

            panier.Add(item);
            RefreshPanier();
        }

        private void RefreshPanier()
        {
            dgvProduit.DataSource = null;
            dgvProduit.DataSource = panier;

            // Configuration des colonnes
            if (dgvProduit.Columns.Count > 0)
            {
                dgvProduit.Columns["IdMedicament"].HeaderText = "ID";
                dgvProduit.Columns["NomMedicament"].HeaderText = "Nom";
                dgvProduit.Columns["Quantite"].HeaderText = "Quantité";
                dgvProduit.Columns["PrixUnitaire"].HeaderText = "Prix Unitaire";
                dgvProduit.Columns["Total"].HeaderText = "Total (Ar)";

                // Formatage des colonnes numériques
                dgvProduit.Columns["PrixUnitaire"].DefaultCellStyle.Format = "N2";
                dgvProduit.Columns["Total"].DefaultCellStyle.Format = "N2";
                dgvProduit.Columns["PrixUnitaire"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvProduit.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvProduit.Columns["Quantite"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Ajout du bouton Supprimer s'il n'existe pas
            if (!dgvProduit.Columns.Contains("btnSupprimer"))
            {
                DataGridViewButtonColumn btnSupprimer = new DataGridViewButtonColumn
                {
                    Name = "btnSupprimer",
                    HeaderText = "Action",
                    Text = "Supprimer",
                    UseColumnTextForButtonValue = true,
                    FlatStyle = FlatStyle.Flat,
                    Width = 80
                };

                // Style identique à votre tableau de médicaments
                btnSupprimer.DefaultCellStyle.BackColor = Color.White;
                btnSupprimer.DefaultCellStyle.ForeColor = Color.Black;
                btnSupprimer.DefaultCellStyle.SelectionBackColor = Color.White;
                btnSupprimer.DefaultCellStyle.SelectionForeColor = Color.Black;
                btnSupprimer.DefaultCellStyle.Font = new Font("Segoe UI", 8.5f, FontStyle.Bold);
                btnSupprimer.DefaultCellStyle.Padding = new Padding(0);

                dgvProduit.Columns.Add(btnSupprimer);
            }

            decimal totalVente = panier.Sum(item => item.Total);
            lblTotal.Text = $"Total: {totalVente.ToString("N2")} Ar";
            dgvProduit.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnTerminer_Click(object sender, EventArgs e)
        {
            if (panier.Count == 0)
            {
                MessageBox.Show("Veuillez ajouter au moins un produit au panier", "Erreur",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var vente = new Vente
            {
                IdClient = clientId,
                IdUtilisateur = SessionUtilisateur.Id,
                Total = panier.Sum(item => item.Total),
                DateVente = DateTime.Now
            };

            var details = panier.ConvertAll(item => new DetailVente
            {
                IdMedicament = item.IdMedicament,
                Quantite = item.Quantite,
                PrixUnitaire = item.PrixUnitaire
            });

            try
            {
                VenteRepository.Add(vente, details);
                MessageBox.Show("Vente enregistrée avec succès", "Succès",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'enregistrement de la vente: {ex.Message}", "Erreur",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dgvProduit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvProduit.Columns["btnSupprimer"]?.Index && e.RowIndex >= 0)
            {
                if (MessageBox.Show("Voulez-vous vraiment supprimer ce produit ?",
                                  "Confirmation",
                                  MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    panier.RemoveAt(e.RowIndex);
                    RefreshPanier();
                }
            }
        }

        // Gestion de l'effet de survol pour les boutons
        private void dgvProduit_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 &&
                dgvProduit.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                hoveredRowIndex = e.RowIndex;
                hoveredColumnIndex = e.ColumnIndex;
                dgvProduit.Invalidate();
            }
            else
            {
                hoveredRowIndex = -1;
                hoveredColumnIndex = -1;
                dgvProduit.Invalidate();
            }
        }

        private void dgvProduit_MouseLeave(object sender, EventArgs e)
        {
            hoveredRowIndex = -1;
            hoveredColumnIndex = -1;
            dgvProduit.Invalidate();
        }

        private void dgvProduit_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 &&
                e.ColumnIndex < dgvProduit.Columns.Count &&
                dgvProduit.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                e.PaintBackground(e.CellBounds, true);

                // Style identique à votre tableau de médicaments
                Color backColor = Color.White;
                Color foreColor = Color.Black;

                // Effet de survol
                if (e.RowIndex == hoveredRowIndex && e.ColumnIndex == hoveredColumnIndex)
                {
                    backColor = Color.FromArgb(231, 246, 253);
                }

                using (SolidBrush brush = new SolidBrush(backColor))
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                }

                string buttonText = dgvProduit.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString() ?? "";

                TextRenderer.DrawText(e.Graphics,
                    buttonText,
                    dgvProduit.DefaultCellStyle.Font,
                    e.CellBounds,
                    foreColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                e.Handled = true;
            }
        }
    }

    public class DetailVentePanier
    {
        public int IdMedicament { get; set; }
        public string NomMedicament { get; set; }
        public int Quantite { get; set; }
        public decimal PrixUnitaire { get; set; }
        public decimal Total { get; set; }
    }
}