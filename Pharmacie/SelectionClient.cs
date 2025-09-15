using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pharmacie.Data;
using Pharmacie.Models;

namespace Pharmacie
{
    public partial class SelectionClientForm : Form
    {
        private int hoveredRowIndex = -1;
        private int hoveredColumnIndex = -1;

        public int? SelectedClientId { get; private set; }

        public SelectionClientForm()
        {
            InitializeComponent();
            AppliquerStyle();
            ConfigurerDataGridView();
            LoadClients();
        }

        private void AppliquerStyle()
        {
            // Style général du formulaire
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.Text = "Sélectionner un Client";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Padding = new Padding(0);

            // Style des boutons
            btnConfirmer.BackColor = Color.FromArgb(0, 123, 255);
            btnConfirmer.ForeColor = Color.White;
            btnConfirmer.FlatStyle = FlatStyle.Flat;
            btnConfirmer.FlatAppearance.BorderSize = 0;
            btnConfirmer.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnConfirmer.Height = 36;
            btnConfirmer.Cursor = Cursors.Hand;

            btnAjouter.BackColor = Color.FromArgb(108, 117, 125);
            btnAjouter.ForeColor = Color.White;
            btnAjouter.FlatStyle = FlatStyle.Flat;
            btnAjouter.FlatAppearance.BorderSize = 0;
            btnAjouter.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnAjouter.Height = 36;
            btnAjouter.Cursor = Cursors.Hand;

            btnAnnuler.BackColor = Color.FromArgb(220, 53, 69);
            btnAnnuler.ForeColor = Color.White;
            btnAnnuler.FlatStyle = FlatStyle.Flat;
            btnAnnuler.FlatAppearance.BorderSize = 0;
            btnAnnuler.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnAnnuler.Height = 36;
            btnAnnuler.Cursor = Cursors.Hand;

            // Style de la checkbox
            cbSansClient.Font = new Font("Segoe UI", 10);
            cbSansClient.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void ConfigurerDataGridView()
        {
            dgvClient.AutoGenerateColumns = false;
            dgvClient.AllowUserToAddRows = false;
            dgvClient.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClient.ReadOnly = true;
            dgvClient.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClient.AllowUserToResizeColumns = false;

            // Style du DataGridView
            dgvClient.BorderStyle = BorderStyle.None;
            dgvClient.EnableHeadersVisualStyles = false;
            dgvClient.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvClient.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvClient.GridColor = Color.FromArgb(240, 240, 240);

            dgvClient.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dgvClient.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvClient.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvClient.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
            dgvClient.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvClient.ColumnHeadersHeight = 40;

            dgvClient.RowTemplate.Height = 35;
            dgvClient.RowTemplate.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvClient.DefaultCellStyle.BackColor = Color.White;
            dgvClient.DefaultCellStyle.ForeColor = Color.Black;
            dgvClient.DefaultCellStyle.SelectionBackColor = Color.FromArgb(231, 246, 253);
            dgvClient.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvClient.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);

            // Événements pour le survol
            dgvClient.CellMouseMove += dgvClient_CellMouseMove;
            dgvClient.MouseLeave += dgvClient_MouseLeave;
            dgvClient.CellPainting += dgvClient_CellPainting;

            // Double buffering pour un rendu plus fluide
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.SetProperty,
                null, dgvClient, new object[] { true });
        }

        private void dgvClient_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                hoveredRowIndex = e.RowIndex;
                dgvClient.Invalidate();
            }
            else
            {
                hoveredRowIndex = -1;
                dgvClient.Invalidate();
            }
        }

        private void dgvClient_MouseLeave(object sender, EventArgs e)
        {
            hoveredRowIndex = -1;
            dgvClient.Invalidate();
        }

        private void dgvClient_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && hoveredRowIndex == e.RowIndex)
            {
                e.CellStyle.BackColor = Color.FromArgb(245, 245, 245);
                e.Handled = true;
            }
        }

        private void LoadClients()
        {
            try
            {
                dgvClient.DataSource = ClientRepository.GetAll();

                // Configuration des colonnes si AutoGenerateColumns est false
                if (!dgvClient.AutoGenerateColumns)
                {
                    dgvClient.Columns.Clear();

                    AddColumn("Id", "ID", "Id", 60);
                    AddColumn("Nom", "Nom", "Nom", 150);
                    AddColumn("Telephone", "Téléphone", "Telephone", 100);
                    AddColumn("Email", "Email", "Email", 180);
                    AddColumn("Adresse", "Adresse", "Adresse", 200);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des clients: {ex.Message}", "Erreur",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddColumn(string name, string header, string property, int width)
        {
            DataGridViewColumn col = new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                DataPropertyName = property,
                Width = width
            };
            dgvClient.Columns.Add(col);
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            AjouterClient form = new AjouterClient();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadClients();
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnConfirmer_Click(object sender, EventArgs e)
        {
            if (dgvClient.SelectedRows.Count > 0 && !cbSansClient.Checked)
            {
                SelectedClientId = (int)dgvClient.SelectedRows[0].Cells["Id"].Value;
            }
            else if (cbSansClient.Checked)
            {
                SelectedClientId = null;
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un client ou cocher 'Sans client'",
                              "Information",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
                return;
            }

            AjouterProduitVente form = new AjouterProduitVente(SelectedClientId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}