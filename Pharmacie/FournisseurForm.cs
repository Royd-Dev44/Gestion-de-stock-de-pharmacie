using Pharmacie.Data;
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
    public partial class FournisseurForm : Form
    {
        private int hoveredRowIndex = -1;
        private int hoveredColumnIndex = -1;

        public FournisseurForm()
        {
            InitializeComponent();
            ConfigurerDataGridView();
            AppliquerStyle();
            ChargerFournisseurs();
            StylerBoutonAjouter();

            // Abonnement aux événements
            dgvFournisseur.CellMouseEnter += dgvFournisseur_CellMouseEnter;
            dgvFournisseur.CellMouseLeave += dgvFournisseur_CellMouseLeave;
            dgvFournisseur.RowPostPaint += dgvFournisseur_RowPostPaint;
            dgvFournisseur.CellPainting += dgvFournisseur_CellPainting;
            dgvFournisseur.CellMouseMove += dgvFournisseur_CellMouseMove;
            dgvFournisseur.MouseLeave += dgvFournisseur_MouseLeave;
            txtRecherche.TextChanged += txtRecherche_TextChanged;
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

        private void dgvFournisseur_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 &&
                dgvFournisseur.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                hoveredRowIndex = e.RowIndex;
                hoveredColumnIndex = e.ColumnIndex;
                dgvFournisseur.Invalidate();
            }
            else
            {
                hoveredRowIndex = -1;
                hoveredColumnIndex = -1;
                dgvFournisseur.Invalidate();
            }
        }

        private void dgvFournisseur_MouseLeave(object sender, EventArgs e)
        {
            hoveredRowIndex = -1;
            hoveredColumnIndex = -1;
            dgvFournisseur.Invalidate();
        }

        private void ConfigurerDataGridView()
        {
            dgvFournisseur.AutoGenerateColumns = false;
            dgvFournisseur.AllowUserToAddRows = false;
            dgvFournisseur.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFournisseur.ReadOnly = true;
            dgvFournisseur.Columns.Clear();
            dgvFournisseur.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFournisseur.AllowUserToResizeColumns = false;

            AddColumn("colId", "ID", "Id", 50, false);
            AddColumn("colNom", "Nom", "Nom", 150);
            AddColumn("colTelephone", "Téléphone", "Telephone", 120);
            AddColumn("colEmail", "Email", "Email", 180);
            AddColumn("colAdresse", "Adresse", "Adresse", 200);

            AddButtonColumn("colModifier", "Modifier", 80);
            AddButtonColumn("colSupprimer", "Supprimer", 80);
        }

        private void AppliquerStyle()
        {
            dgvFournisseur.BorderStyle = BorderStyle.None;
            dgvFournisseur.EnableHeadersVisualStyles = false;
            dgvFournisseur.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvFournisseur.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvFournisseur.GridColor = Color.FromArgb(240, 240, 240);

            dgvFournisseur.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dgvFournisseur.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvFournisseur.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvFournisseur.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
            dgvFournisseur.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvFournisseur.ColumnHeadersHeight = 50;

            dgvFournisseur.RowTemplate.Height = 50;
            dgvFournisseur.RowTemplate.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);
            dgvFournisseur.DefaultCellStyle.BackColor = Color.White;
            dgvFournisseur.DefaultCellStyle.ForeColor = Color.Black;
            dgvFournisseur.DefaultCellStyle.SelectionBackColor = Color.FromArgb(231, 246, 253);
            dgvFournisseur.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvFournisseur.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);

            dgvFournisseur.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFournisseur.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn col in dgvFournisseur.Columns)
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

                // Alignement spécifique pour certaines colonnes
                if (col.Name == "colAdresse" || col.Name == "colEmail")
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
            }

            dgvFournisseur.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(231, 246, 253);
            dgvFournisseur.RowsDefaultCellStyle.SelectionForeColor = Color.Black;

            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.SetProperty,
                null, dgvFournisseur, new object[] { true });
        }

        private void dgvFournisseur_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvFournisseur.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            }
        }

        private void dgvFournisseur_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvFournisseur.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                    e.RowIndex % 2 == 0 ? Color.White : Color.FromArgb(248, 248, 248);
            }
        }

        private void dgvFournisseur_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

            dgvFournisseur.Columns.Add(col);
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

            dgvFournisseur.Columns.Add(btnColumn);
        }

        private void dgvFournisseur_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 &&
                e.ColumnIndex < dgvFournisseur.Columns.Count &&
                dgvFournisseur.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
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

                string buttonText = dgvFournisseur.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString() ?? "";

                TextRenderer.DrawText(e.Graphics,
                    buttonText,
                    dgvFournisseur.DefaultCellStyle.Font,
                    e.CellBounds,
                    foreColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                e.Handled = true;
            }
        }

        private void ChargerFournisseurs(string searchTerm = "")
        {
            try
            {
                dgvFournisseur.DataSource = string.IsNullOrEmpty(searchTerm)
                    ? FournisseurRepository.GetAll()
                    : FournisseurRepository.Search(searchTerm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement: {ex.Message}", "Erreur",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvFournisseur_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var grid = sender as DataGridView;

            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                int id = Convert.ToInt32(grid.Rows[e.RowIndex].Cells["colId"].Value);

                if (grid.Columns[e.ColumnIndex].Name == "colModifier")
                {
                    ModifierFournisseur(id);
                }
                else if (grid.Columns[e.ColumnIndex].Name == "colSupprimer")
                {
                    SupprimerFournisseur(id);
                }
            }
        }

        private void ModifierFournisseur(int id)
        {
            try
            {
                var fournisseur = FournisseurRepository.GetById(id);
                if (fournisseur == null)
                {
                    MessageBox.Show("Fournisseur introuvable.", "Erreur",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var formModif = new ModifierFournisseur(fournisseur))
                {
                    if (formModif.ShowDialog() == DialogResult.OK)
                    {
                        bool success = FournisseurRepository.Update(formModif.FournisseurModifie);
                        if (success)
                        {
                            MessageBox.Show("Fournisseur mis à jour avec succès!", "Succès",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ChargerFournisseurs();
                        }
                        else
                        {
                            MessageBox.Show("Échec de la mise à jour.", "Erreur",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la modification: {ex.Message}", "Erreur",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SupprimerFournisseur(int id)
        {
            var confirmation = MessageBox.Show($"Êtes-vous sûr de vouloir supprimer ce fournisseur (ID: {id})?",
                                             "Confirmation de suppression",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Warning);

            if (confirmation == DialogResult.Yes)
            {
                try
                {
                    if (FournisseurRepository.Delete(id))
                    {
                        MessageBox.Show("Fournisseur supprimé avec succès.",
                                      "Succès",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);
                        ChargerFournisseurs();
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

        private void txtRecherche_TextChanged(object sender, EventArgs e)
        {
            ChargerFournisseurs(txtRecherche.Text.Trim());
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                using (var formAjout = new AjouterFournisseur())
                {
                    if (formAjout.ShowDialog() == DialogResult.OK)
                    {
                        bool success = FournisseurRepository.Add(formAjout.NouveauFournisseur);
                        if (success)
                        {
                            MessageBox.Show("Fournisseur ajouté avec succès!", "Succès",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ChargerFournisseurs();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout: {ex.Message}", "Erreur",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}