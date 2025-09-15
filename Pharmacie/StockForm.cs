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
    public partial class StockForm : Form
    {
        private int hoveredRowIndex = -1;
        private int hoveredColumnIndex = -1;

        public StockForm()
        {
            InitializeComponent();
            ConfigurerDataGridView();
            AppliquerStyle();
            ChargerLots();
            StylerBoutonAjouter();

            // Abonnement aux événements
            dgvLots.CellMouseEnter += dgvLots_CellMouseEnter;
            dgvLots.CellMouseLeave += dgvLots_CellMouseLeave;
            dgvLots.RowPostPaint += dgvLots_RowPostPaint;
            dgvLots.CellPainting += dgvLots_CellPainting;
            dgvLots.CellMouseMove += dgvLots_CellMouseMove;
            dgvLots.MouseLeave += dgvLots_MouseLeave;
        }

        private void StylerBoutonAjouter()
        {

            Color buttonAddNormalColor = Color.FromArgb(108, 117, 125);
            Color buttonAddHoverColor = Color.FromArgb(84, 91, 98);
            Color buttonAddActiveColor = Color.FromArgb(73, 80, 87);
            Color textAddColor = Color.White;

            btnAjouter.FlatStyle = FlatStyle.Flat;
            btnAjouter.FlatAppearance.BorderSize = 0;
            btnAjouter.BackColor = buttonAddNormalColor;
            btnAjouter.ForeColor = textAddColor;
            btnAjouter.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnAjouter.Height = 40;
            btnAjouter.Cursor = Cursors.Hand;

            btnAjouter.Padding = new Padding(10, 0, 10, 0);
            btnAjouter.Margin = new Padding(0, 0, 10, 0);

            btnAjouter.FlatAppearance.MouseOverBackColor = buttonAddHoverColor;
            btnAjouter.FlatAppearance.MouseDownBackColor = buttonAddActiveColor;

            btnAjouter.MouseEnter += (s, e) =>
            {
                btnAjouter.BackColor = buttonAddHoverColor;
            };

            btnAjouter.MouseLeave += (s, e) =>
            {
                btnAjouter.BackColor = buttonAddNormalColor;
            };

            btnAjouter.MouseDown += (s, e) =>
            {
                btnAjouter.BackColor = buttonAddActiveColor;
            };

            btnAjouter.MouseUp += (s, e) =>
            {
                btnAjouter.BackColor = buttonAddHoverColor;
            };
        }


        private void dgvLots_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 &&
                dgvLots.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                hoveredRowIndex = e.RowIndex;
                hoveredColumnIndex = e.ColumnIndex;
                dgvLots.Invalidate();
            }
            else
            {
                hoveredRowIndex = -1;
                hoveredColumnIndex = -1;
                dgvLots.Invalidate();
            }
        }

        private void dgvLots_MouseLeave(object sender, EventArgs e)
        {
            hoveredRowIndex = -1;
            hoveredColumnIndex = -1;
            dgvLots.Invalidate();
        }

        private void ConfigurerDataGridView()
        {
            dgvLots.AutoGenerateColumns = false;
            dgvLots.AllowUserToAddRows = false;
            dgvLots.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLots.ReadOnly = true;
            dgvLots.Columns.Clear();
            dgvLots.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLots.AllowUserToResizeColumns = false;

            AddColumn("colIdLot", "ID Lot", "IdLot", 60);
            AddColumn("colIdAchat", "ID Achat", "IdAchat", 70);
            AddColumn("colMedicament", "Médicament", "NomMedicament", 150);
            AddColumn("colQteTotal", "Qté Total", "QuantiteTotal", 80);
            AddColumn("colQteRestante", "Qté Restante", "QuantiteRestante", 80);
            AddColumn("colDateAjout", "Date Ajout", "DateAjout", 100, format: "d");
            
            AddColumn("colTotal", "Total", "TotalAchat", 80, format: "N2");
            AddColumn("colExpiration", "Expiration", "DateExpiration", 100, format: "d");
            AddColumn("colUtilisateur", "ID Utilis.", "IdUtilisateur", 80);
            AddColumn("colStatut", "Statut", "Statut", 100);

            AddButtonColumn("colModifier", "Modifier", 80);
            AddButtonColumn("colSupprimer", "Supprimer", 80);

            // Formatage spécifique pour les colonnes numériques
            dgvLots.Columns["colQteTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvLots.Columns["colQteRestante"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvLots.Columns["colTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void AppliquerStyle()
        {
            dgvLots.BorderStyle = BorderStyle.None;
            dgvLots.EnableHeadersVisualStyles = false;
            dgvLots.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvLots.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvLots.GridColor = Color.FromArgb(240, 240, 240);

            dgvLots.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dgvLots.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLots.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvLots.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
            dgvLots.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvLots.ColumnHeadersHeight = 50;

            dgvLots.RowTemplate.Height = 50;
            dgvLots.RowTemplate.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);
            dgvLots.DefaultCellStyle.BackColor = Color.White;
            dgvLots.DefaultCellStyle.ForeColor = Color.Black;
            dgvLots.DefaultCellStyle.SelectionBackColor = Color.FromArgb(231, 246, 253);
            dgvLots.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvLots.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);

            dgvLots.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLots.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn col in dgvLots.Columns)
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

            dgvLots.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(231, 246, 253);
            dgvLots.RowsDefaultCellStyle.SelectionForeColor = Color.Black;

            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.SetProperty,
                null, dgvLots, new object[] { true });
        }

        private void dgvLots_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvLots.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            }
        }

        private void dgvLots_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvLots.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                    e.RowIndex % 2 == 0 ? Color.White : Color.FromArgb(248, 248, 248);
            }
        }

        private void dgvLots_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

            dgvLots.Columns.Add(col);
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

            dgvLots.Columns.Add(btnColumn);
        }
        public void ActualiserListeStock()
        {
            try
            {
                // Recharge les données depuis la base de données
                dgvLots.DataSource = StockRepository.GetAll();
                dgvLots.Refresh();

                // Optionnel: Réappliquer le style si nécessaire
                AppliquerStyle();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'actualisation du stock: {ex.Message}",
                              "Erreur",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }
        private void dgvLots_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 &&
                e.ColumnIndex < dgvLots.Columns.Count &&
                dgvLots.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
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

                string buttonText = dgvLots.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString() ?? "";

                TextRenderer.DrawText(e.Graphics,
                    buttonText,
                    dgvLots.DefaultCellStyle.Font,
                    e.CellBounds,
                    foreColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                e.Handled = true;
            }
        }

        private void ChargerLots()
        {
            try
            {
                dgvLots.DataSource = StockRepository.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement: {ex.Message}", "Erreur",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLots_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var grid = sender as DataGridView;

            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                int idLot = Convert.ToInt32(grid.Rows[e.RowIndex].Cells["colIdLot"].Value);

                if (grid.Columns[e.ColumnIndex].Name == "colModifier")
                {
                    ModifierLot(idLot);
                }
                else if (grid.Columns[e.ColumnIndex].Name == "colSupprimer")
                {
                    SupprimerLot(idLot);
                }
            }
        }

        private void ModifierLot(int idLot)
        {
            var formModifier = new ModifierLots(idLot);
            if (formModifier.ShowDialog() == DialogResult.OK)
            {
                ChargerLots();
            }
            formModifier.Dispose();
        }

        private void SupprimerLot(int idLot)
        {
            var confirmation = MessageBox.Show($"Êtes-vous sûr de vouloir supprimer ce lot (ID: {idLot})?",
                                             "Confirmation de suppression",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Warning);

            if (confirmation == DialogResult.Yes)
            {
                try
                {
                    if (StockRepository.Delete(idLot))
                    {
                        MessageBox.Show("Lot supprimé avec succès.",
                                      "Succès",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);
                        ChargerLots();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la suppression: {ex.Message}",
                                  "Erreur",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            }
        }

       

      

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (SessionUtilisateur.Id == 0)
            {
                MessageBox.Show("Veuillez vous connecter avant d'effectuer un achat.");
                return;
            }

            using (var formFournisseur = new SelectionFournisseur())
            {
                if (formFournisseur.ShowDialog() == DialogResult.OK)
                {
                    using (var formAchat = new EffectuerAchat(
                        formFournisseur.IdFournisseurSelectionne,
                        formFournisseur.NomFournisseur,
                        SessionUtilisateur.Id))
                    {
                        if (formAchat.ShowDialog() == DialogResult.OK)
                        {
                            ChargerLots();
                        }
                    }
                }
            }
        }
    }
}