using MySql.Data.MySqlClient;
using Pharmacie.Data;
using Pharmacie.Models;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Pharmacie
{
    public partial class DetailVenteForm : Form
    {
        private int idVente;

        public DetailVenteForm(int idVente)
        {
            InitializeComponent();
            this.idVente = idVente;
            ApplyModernStyle();
            LoadDetails();
        }

        private void ApplyModernStyle()
        {
            // Style général du formulaire
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 10);
            this.Text = "Détails de la Vente #" + idVente;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Padding = new Padding(0);  // Suppression du padding du formulaire

            // Style des labels de valeur
            lblDate.Font = new Font("Segoe UI", 10);
            lblClient.Font = new Font("Segoe UI", 10);
            lblTotal.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(40, 167, 69);

            // Style du DataGridView - Optimisé pour le remplissage total
            dgvDetails.BorderStyle = BorderStyle.None;
            dgvDetails.EnableHeadersVisualStyles = false;
            dgvDetails.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvDetails.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDetails.GridColor = Color.FromArgb(240, 240, 240);

            // Configuration des en-têtes
            dgvDetails.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dgvDetails.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDetails.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvDetails.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
            dgvDetails.ColumnHeadersHeight = 60;

            // Configuration des lignes
            dgvDetails.RowTemplate.Height = 35;
            dgvDetails.RowTemplate.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvDetails.DefaultCellStyle.BackColor = Color.White;
            dgvDetails.DefaultCellStyle.ForeColor = Color.Black;
            dgvDetails.DefaultCellStyle.SelectionBackColor = Color.FromArgb(231, 246, 253);
            dgvDetails.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvDetails.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);

            // Remplissage total et redimensionnement automatique
            dgvDetails.Dock = DockStyle.Fill;
            dgvDetails.Margin = new Padding(0);  // Suppression des marges
            dgvDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Double buffering pour éviter le scintillement
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.SetProperty,
                null, dgvDetails, new object[] { true });
        }

        private void LoadDetails()
        {
            try
            {
                // Charger les informations de base de la vente
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT v.id, v.date_vente, v.id_client, c.nom AS client_nom, 
                           v.id_utilisateur, u.nom AS utilisateur_nom, v.total
                           FROM vente v
                           LEFT JOIN client c ON v.id_client = c.id
                           JOIN utilisateur u ON v.id_utilisateur = u.id
                           WHERE v.id = @idVente";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idVente", idVente);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblDate.Text = Convert.ToDateTime(reader["date_vente"]).ToString("dd/MM/yyyy");
                                lblIdClient.Text = reader["id_client"]?.ToString() ?? "N/A";
                                lblClient.Text = reader["client_nom"]?.ToString() ?? "Aucun des clients enregistrés";
                                lblTotal.Text = $"{Convert.ToDecimal(reader["total"]):N2} Ar";
                            }
                        }
                    }
                }

                // Charger les détails des produits
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT dv.id_medicament, m.nom AS medicament_nom, 
                           dv.quantite, m.prix, (dv.quantite * m.prix) AS total
                           FROM detailvente dv
                           JOIN medicament m ON dv.id_medicament = m.id
                           WHERE dv.id_vente = @idVente";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idVente", idVente);

                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }

                        dgvDetails.DataSource = dt;

                        // Configuration des colonnes
                        dgvDetails.Columns["id_medicament"].HeaderText = "ID Médicament";
                        dgvDetails.Columns["medicament_nom"].HeaderText = "Médicament";
                        dgvDetails.Columns["quantite"].HeaderText = "Quantité";
                        dgvDetails.Columns["prix"].HeaderText = "Prix unitaire";
                        dgvDetails.Columns["total"].HeaderText = "Total (Ar)";

                        // Formatage et alignement des colonnes
                        dgvDetails.Columns["prix"].DefaultCellStyle.Format = "N2";
                        dgvDetails.Columns["total"].DefaultCellStyle.Format = "N2";
                        dgvDetails.Columns["prix"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgvDetails.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgvDetails.Columns["quantite"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        // Forcer le redimensionnement immédiat des colonnes
                        dgvDetails.AutoResizeColumns();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des détails: {ex.Message}", "Erreur",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

    }
}