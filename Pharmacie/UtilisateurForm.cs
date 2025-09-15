using Pharmacie.Data;
using Pharmacie.Models;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Pharmacie
{
    public partial class UtilisateurForm : Form
    {
        private int hoveredRowIndex = -1;
        private int hoveredColumnIndex = -1;

        public UtilisateurForm()
        {
            if (SessionUtilisateur.Role != "admin")
            {
                MessageBox.Show("Vous n'avez pas les permissions nécessaires pour accéder à cette fonctionnalité.",
                              "Accès refusé",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                this.Close();
                return;
            }

            InitializeComponent();
            ConfigurerDataGridView();
            AppliquerStyle();
            ChargerUtilisateurs();
            StylerBoutonAjouter();

            // Abonnement aux événements
            dgvUtilisateur.CellMouseEnter += dgvUtilisateur_CellMouseEnter;
            dgvUtilisateur.CellMouseLeave += dgvUtilisateur_CellMouseLeave;
            dgvUtilisateur.RowPostPaint += dgvUtilisateur_RowPostPaint;
            dgvUtilisateur.CellPainting += dgvUtilisateur_CellPainting;
            dgvUtilisateur.CellMouseMove += dgvUtilisateur_CellMouseMove;
            dgvUtilisateur.MouseLeave += dgvUtilisateur_MouseLeave;
            dgvUtilisateur.CellContentClick += dgvUtilisateur_CellContentClick; // pour Modifier et Supprimer

            // Abonnement recherche
            txtRecherche.TextChanged += txtRecherche_TextChanged;

            // Abonnement bouton ajouter
            btnAjouter.Click += btnAjouter_Click;
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


        private void dgvUtilisateur_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 &&
                dgvUtilisateur.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                hoveredRowIndex = e.RowIndex;
                hoveredColumnIndex = e.ColumnIndex;
                dgvUtilisateur.Invalidate();
            }
            else
            {
                hoveredRowIndex = -1;
                hoveredColumnIndex = -1;
                dgvUtilisateur.Invalidate();
            }
        }

        private void dgvUtilisateur_MouseLeave(object sender, EventArgs e)
        {
            hoveredRowIndex = -1;
            hoveredColumnIndex = -1;
            dgvUtilisateur.Invalidate();
        }

        private void ConfigurerDataGridView()
        {
            dgvUtilisateur.AutoGenerateColumns = false;
            dgvUtilisateur.AllowUserToAddRows = false;
            dgvUtilisateur.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUtilisateur.ReadOnly = true;
            dgvUtilisateur.Columns.Clear();
            dgvUtilisateur.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUtilisateur.AllowUserToResizeColumns = false;

            AddColumn("colId", "ID", "Id", 50, false);
            AddColumn("colNom", "Nom", "Nom", 150);
            AddColumn("colTelephone", "Téléphone", "Telephone", 120);
            AddColumn("colEmail", "Email", "Email", 180);
            AddColumn("colRole", "Rôle", "Role", 100);
            AddColumn("colDateCreation", "Date Création", "DateCreation", 120, format: "dd/MM/yyyy");

            AddButtonColumn("colModifier", "Modifier", 80);
            AddButtonColumn("colSupprimer", "Supprimer", 80);
        }

        private void AppliquerStyle()
        {
            dgvUtilisateur.BorderStyle = BorderStyle.None;
            dgvUtilisateur.EnableHeadersVisualStyles = false;
            dgvUtilisateur.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvUtilisateur.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUtilisateur.GridColor = Color.FromArgb(240, 240, 240);

            dgvUtilisateur.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dgvUtilisateur.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUtilisateur.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvUtilisateur.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
            dgvUtilisateur.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvUtilisateur.ColumnHeadersHeight = 70;

            dgvUtilisateur.RowTemplate.Height = 50;
            dgvUtilisateur.RowTemplate.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);
            dgvUtilisateur.DefaultCellStyle.BackColor = Color.White;
            dgvUtilisateur.DefaultCellStyle.ForeColor = Color.Black;
            dgvUtilisateur.DefaultCellStyle.SelectionBackColor = Color.FromArgb(231, 246, 253);
            dgvUtilisateur.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvUtilisateur.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);

            dgvUtilisateur.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUtilisateur.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn col in dgvUtilisateur.Columns)
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
                if (col.Name == "colEmail" || col.Name == "colNom")
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
            }

            dgvUtilisateur.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(231, 246, 253);
            dgvUtilisateur.RowsDefaultCellStyle.SelectionForeColor = Color.Black;

            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.SetProperty,
                null, dgvUtilisateur, new object[] { true });
        }

        private void dgvUtilisateur_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvUtilisateur.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            }
        }

        private void dgvUtilisateur_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvUtilisateur.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                    e.RowIndex % 2 == 0 ? Color.White : Color.FromArgb(248, 248, 248);
            }
        }

        private void dgvUtilisateur_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

            dgvUtilisateur.Columns.Add(col);
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

            dgvUtilisateur.Columns.Add(btnColumn);
        }

        private void dgvUtilisateur_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 &&
                e.ColumnIndex < dgvUtilisateur.Columns.Count &&
                dgvUtilisateur.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
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

                string buttonText = dgvUtilisateur.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString() ?? "";

                TextRenderer.DrawText(e.Graphics,
                    buttonText,
                    dgvUtilisateur.DefaultCellStyle.Font,
                    e.CellBounds,
                    foreColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                e.Handled = true;
            }
        }

        private void ChargerUtilisateurs(string searchTerm = "")
        {
            try
            {
                dgvUtilisateur.DataSource = string.IsNullOrEmpty(searchTerm)
                    ? UtilisateurRepository.GetAll()
                    : UtilisateurRepository.Search(searchTerm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement: {ex.Message}", "Erreur",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUtilisateur_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var grid = sender as DataGridView;

            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                int id = Convert.ToInt32(grid.Rows[e.RowIndex].Cells["colId"].Value);

                if (grid.Columns[e.ColumnIndex].Name == "colModifier")
                {
                    ModifierUtilisateur(id);
                }
                else if (grid.Columns[e.ColumnIndex].Name == "colSupprimer")
                {
                    SupprimerUtilisateur(id);
                }
            }
            dgvUtilisateur.CellContentClick += dgvUtilisateur_CellContentClick;

        }

        private void ModifierUtilisateur(int id)
        {
            try
            {
                var utilisateur = UtilisateurRepository.GetById(id);
                if (utilisateur == null)
                {
                    MessageBox.Show("Utilisateur introuvable.", "Erreur",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var formModif = new ModifierUtilisateur(utilisateur))
                {
                    if (formModif.ShowDialog() == DialogResult.OK)
                    {
                        bool success = UtilisateurRepository.Update(formModif.UtilisateurModifie);
                        if (success)
                        {
                            MessageBox.Show("Utilisateur mis à jour avec succès!", "Succès",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ChargerUtilisateurs();
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

        private void SupprimerUtilisateur(int id)
        {
            var confirmation = MessageBox.Show($"Êtes-vous sûr de vouloir supprimer cet utilisateur (ID: {id})?",
                                             "Confirmation de suppression",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Warning);

            if (confirmation == DialogResult.Yes)
            {
                try
                {
                    if (UtilisateurRepository.Delete(id))
                    {
                        MessageBox.Show("Utilisateur supprimé avec succès.",
                                      "Succès",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);
                        ChargerUtilisateurs();
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
            try
            {
                using (var formAjout = new AjouterUtilisateur())
                {
                    if (formAjout.ShowDialog() == DialogResult.OK)
                    {
                        bool success = UtilisateurRepository.Add(formAjout.NouvelUtilisateur);
                        if (success)
                        {
                            MessageBox.Show("Utilisateur ajouté avec succès!", "Succès",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ChargerUtilisateurs();
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

        private void txtRecherche_TextChanged(object sender, EventArgs e)
        {
            ChargerUtilisateurs(txtRecherche.Text.Trim());
        }

        

      
    }
}