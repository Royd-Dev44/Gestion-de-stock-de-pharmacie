using MySql.Data.MySqlClient;
using Pharmacie.Data;
using Pharmacie.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacie
{
    public partial class VenteForm : Form
    {
        private int hoveredRowIndex = -1;
        private int hoveredColumnIndex = -1;

        public VenteForm()
        {
            InitializeComponent();
            ConfigurerDataGridView();
            AppliquerStyle();
            LoadVentes();
            StylerBoutonAjouter();

            // Abonnement aux événements
            dgvVente.CellMouseEnter += dgvVente_CellMouseEnter;
            dgvVente.CellMouseLeave += dgvVente_CellMouseLeave;
            dgvVente.RowPostPaint += dgvVente_RowPostPaint;
            dgvVente.CellPainting += dgvVente_CellPainting;
            dgvVente.CellMouseMove += dgvVente_CellMouseMove;
            dgvVente.MouseLeave += dgvVente_MouseLeave;
        }

        private void StylerBoutonAjouter()
        {

            Color buttonAddNormalColor = Color.FromArgb(108, 117, 125);
            Color buttonAddHoverColor = Color.FromArgb(84, 91, 98);
            Color buttonAddActiveColor = Color.FromArgb(73, 80, 87);
            Color textAddColor = Color.White;

            btnVente.FlatStyle = FlatStyle.Flat;
            btnVente.FlatAppearance.BorderSize = 0;
            btnVente.BackColor = buttonAddNormalColor;
            btnVente.ForeColor = textAddColor;
            btnVente.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnVente.Height = 40;
            btnVente.Cursor = Cursors.Hand;
              
            btnVente.Padding = new Padding(10, 0, 10, 0);
            btnVente.Margin = new Padding(0, 0, 10, 0);
               
            btnVente.FlatAppearance.MouseOverBackColor = buttonAddHoverColor;
            btnVente.FlatAppearance.MouseDownBackColor = buttonAddActiveColor;
              
            btnVente.MouseEnter += (s, e) =>
            {
                btnVente.BackColor = buttonAddHoverColor;
            };

            btnVente.MouseLeave += (s, e) =>
            {
                btnVente.BackColor = buttonAddNormalColor;
            };

            btnVente.MouseDown += (s, e) =>
            {
                btnVente.BackColor = buttonAddActiveColor;
            };

            btnVente.MouseUp += (s, e) =>
            {
                btnVente.BackColor = buttonAddHoverColor;
            };
        }
   
        private void dgvVente_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 &&
                dgvVente.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                hoveredRowIndex = e.RowIndex;
                hoveredColumnIndex = e.ColumnIndex;
                dgvVente.Invalidate();
            }
            else
            {
                hoveredRowIndex = -1;
                hoveredColumnIndex = -1;
                dgvVente.Invalidate();
            }
        }

        private void dgvVente_MouseLeave(object sender, EventArgs e)
        {
            hoveredRowIndex = -1;
            hoveredColumnIndex = -1;
            dgvVente.Invalidate();
        }

        private void ConfigurerDataGridView()
        {
            dgvVente.AutoGenerateColumns = false;
            dgvVente.AllowUserToAddRows = false;
            dgvVente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVente.ReadOnly = true;
            dgvVente.Columns.Clear();
            dgvVente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVente.AllowUserToResizeColumns = false;

            AddColumn("colId", "ID", "id", 60);
            AddColumn("colIdClient", "ID Client", "id_client", 80);
            AddColumn("colClientNom", "Client", "client_nom", 150);
            AddColumn("colTotal", "Total", "total", 80, format: "N2");
            AddColumn("colDateVente", "Date", "date_vente", 100, format: "d");
            AddColumn("colIdUtilisateur", "ID Utilis.", "id_utilisateur", 80);
            AddColumn("colUtilisateurNom", "Utilisateur", "utilisateur_nom", 120);

            AddButtonColumn("btnDetails", "Détails", 80);
        }

        private void AppliquerStyle()
        {
            dgvVente.BorderStyle = BorderStyle.None;
            dgvVente.EnableHeadersVisualStyles = false;
            dgvVente.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvVente.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvVente.GridColor = Color.FromArgb(240, 240, 240);

            dgvVente.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dgvVente.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvVente.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvVente.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
            dgvVente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvVente.ColumnHeadersHeight = 50;

            dgvVente.RowTemplate.Height = 50;
            dgvVente.RowTemplate.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);
            dgvVente.DefaultCellStyle.BackColor = Color.White;
            dgvVente.DefaultCellStyle.ForeColor = Color.Black;
            dgvVente.DefaultCellStyle.SelectionBackColor = Color.FromArgb(231, 246, 253);
            dgvVente.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvVente.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);

            dgvVente.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvVente.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn col in dgvVente.Columns)
            {
                if (col is DataGridViewButtonColumn btnCol)
                {
                    btnCol.DefaultCellStyle.BackColor = Color.White;
                    btnCol.DefaultCellStyle.ForeColor = Color.Black;
                    btnCol.DefaultCellStyle.SelectionBackColor = Color.White;
                    btnCol.DefaultCellStyle.SelectionForeColor = Color.Black;
                    btnCol.DefaultCellStyle.Font = new Font("Segoe UI", 8.5f, FontStyle.Bold);
                    btnCol.FlatStyle = FlatStyle.Flat;
                    btnCol.DefaultCellStyle.Padding = new Padding(0);
                }
            }

            dgvVente.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(231, 246, 253);
            dgvVente.RowsDefaultCellStyle.SelectionForeColor = Color.Black;

            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.SetProperty,
                null, dgvVente, new object[] { true });
        }

        private void dgvVente_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvVente.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            }
        }

        private void dgvVente_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvVente.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                    e.RowIndex % 2 == 0 ? Color.White : Color.FromArgb(248, 248, 248);
            }
        }

        private void dgvVente_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.FromArgb(240, 240, 240), 1))
            {
                e.Graphics.DrawLine(pen,
                    e.RowBounds.Left,
                    e.RowBounds.Bottom - 1,
                    e.RowBounds.Right,
                    e.RowBounds.Bottom - 1);
            }
        }

        private void AddColumn(string name, string header, string property, int width, bool visible = true, string format = null)
        {
            DataGridViewColumn col = new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                DataPropertyName = property,
                Width = width,
                Visible = visible
            };

            if (!string.IsNullOrEmpty(format))
            {
                col.DefaultCellStyle.Format = format;
            }

            dgvVente.Columns.Add(col);
        }

        private void AddButtonColumn(string name, string text, int width)
        {
            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn
            {
                Name = name,
                HeaderText = "",
                Text = text,
                UseColumnTextForButtonValue = true,
                Width = width,
                FlatStyle = FlatStyle.Flat
            };

            btnColumn.DefaultCellStyle.BackColor = Color.White;
            btnColumn.DefaultCellStyle.ForeColor = Color.Black;
            btnColumn.DefaultCellStyle.SelectionBackColor = Color.White;
            btnColumn.DefaultCellStyle.SelectionForeColor = Color.Black;
            btnColumn.DefaultCellStyle.Font = new Font("Segoe UI", 8.5f, FontStyle.Bold);
            btnColumn.DefaultCellStyle.Padding = new Padding(0);

            dgvVente.Columns.Add(btnColumn);
        }

        private void dgvVente_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 &&
                e.ColumnIndex < dgvVente.Columns.Count &&
                dgvVente.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                e.PaintBackground(e.CellBounds, true);

                Color backColor = Color.White;
                Color foreColor = Color.Black;

                if (e.RowIndex == hoveredRowIndex && e.ColumnIndex == hoveredColumnIndex)
                {
                    backColor = Color.FromArgb(231, 246, 253);
                }

                using (SolidBrush brush = new SolidBrush(backColor))
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                }

                string buttonText = dgvVente.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString() ?? "";

                TextRenderer.DrawText(e.Graphics,
                    buttonText,
                    dgvVente.DefaultCellStyle.Font,
                    e.CellBounds,
                    foreColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                e.Handled = true;
            }
        }

        private void LoadVentes()
        {
            try
            {
                dgvVente.DataSource = VenteRepository.GetAllWithDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement: {ex.Message}", "Erreur",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvVente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var grid = sender as DataGridView;

            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                grid.Columns[e.ColumnIndex].Name == "btnDetails")
            {
                int idVente = Convert.ToInt32(grid.Rows[e.RowIndex].Cells["colId"].Value);
                DetailVenteForm detailForm = new DetailVenteForm(idVente);
                detailForm.ShowDialog();
            }
        }

        private void btnVente_Click(object sender, EventArgs e)
        {
            SelectionClientForm selectionClientForm = new SelectionClientForm();
            if (selectionClientForm.ShowDialog() == DialogResult.OK)
            {
                LoadVentes();
            }
        }
    }
}