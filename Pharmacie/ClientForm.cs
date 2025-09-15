using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pharmacie.Models;
using Pharmacie.Data;

namespace Pharmacie
{
    public partial class ClientForm : Form
    {
        private int hoveredRowIndex = -1;
        private int hoveredColumnIndex = -1;

        public ClientForm()
        {
            InitializeComponent();
            ConfigurerDataGridView();
            AppliquerStyle();
            ChargerClients();
            StylerBoutonAjouter();

            // Abonnement aux événements
            dgvClient.CellMouseEnter += dgvClient_CellMouseEnter;
            dgvClient.CellMouseLeave += dgvClient_CellMouseLeave;
            dgvClient.RowPostPaint += dgvClient_RowPostPaint;
            dgvClient.CellPainting += dgvClient_CellPainting;
            dgvClient.CellMouseMove += dgvClient_CellMouseMove;
            dgvClient.MouseLeave += dgvClient_MouseLeave;
            txtRecherche.TextChanged += txtRecherche_TextChanged;
            this.Resize += ClientForm_Resize;
        }

        private void dgvClient_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 &&
                dgvClient.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                hoveredRowIndex = e.RowIndex;
                hoveredColumnIndex = e.ColumnIndex;
                dgvClient.Invalidate();
            }
            else
            {
                hoveredRowIndex = -1;
                hoveredColumnIndex = -1;
                dgvClient.Invalidate();
            }
        }

        private void dgvClient_MouseLeave(object sender, EventArgs e)
        {
            hoveredRowIndex = -1;
            hoveredColumnIndex = -1;
            dgvClient.Invalidate();
        }

        private void ConfigurerDataGridView()
        {
            dgvClient.AutoGenerateColumns = false;
            dgvClient.AllowUserToAddRows = false;
            dgvClient.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClient.ReadOnly = true;
            dgvClient.Columns.Clear();
            dgvClient.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClient.AllowUserToResizeColumns = false;

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
            dgvClient.ColumnHeadersHeight = 50;

            dgvClient.RowTemplate.Height = 50;
            dgvClient.RowTemplate.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);
            dgvClient.DefaultCellStyle.BackColor = Color.White;
            dgvClient.DefaultCellStyle.ForeColor = Color.Black;
            dgvClient.DefaultCellStyle.SelectionBackColor = Color.FromArgb(231, 246, 253);
            dgvClient.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvClient.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);

            dgvClient.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvClient.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn col in dgvClient.Columns)
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

            dgvClient.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(231, 246, 253);
            dgvClient.RowsDefaultCellStyle.SelectionForeColor = Color.Black;

            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.SetProperty,
                null, dgvClient, new object[] { true });
        }

        private void dgvClient_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvClient.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            }
        }

        private void dgvClient_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvClient.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                    e.RowIndex % 2 == 0 ? Color.White : Color.FromArgb(248, 248, 248);
            }
        }

        private void dgvClient_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

            dgvClient.Columns.Add(col);
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

            dgvClient.Columns.Add(btnColumn);
        }

        private void dgvClient_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 &&
                e.ColumnIndex < dgvClient.Columns.Count &&
                dgvClient.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
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

                string buttonText = dgvClient.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString() ?? "";

                TextRenderer.DrawText(e.Graphics,
                    buttonText,
                    dgvClient.DefaultCellStyle.Font,
                    e.CellBounds,
                    foreColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                e.Handled = true;
            }
        }

        private void ChargerClients(string searchTerm = "")
        {
            try
            {
                dgvClient.DataSource = string.IsNullOrEmpty(searchTerm)
                    ? ClientRepository.GetAll()
                    : ClientRepository.Search(searchTerm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement: {ex.Message}", "Erreur",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClientForm_Resize(object sender, EventArgs e)
        {
            dgvClient.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvClient.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvClient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var grid = sender as DataGridView;

            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                int id = Convert.ToInt32(grid.Rows[e.RowIndex].Cells["colId"].Value);

                if (grid.Columns[e.ColumnIndex].Name == "colModifier")
                {
                    ModifierClient(id);
                }
                else if (grid.Columns[e.ColumnIndex].Name == "colSupprimer")
                {
                    SupprimerClient(id);
                }
            }
        }

        private void ModifierClient(int id)
        {
            try
            {
                var client = ClientRepository.GetById(id);
                if (client == null)
                {
                    MessageBox.Show("Client introuvable.", "Erreur",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var formModif = new ModifierClient(client))
                {
                    if (formModif.ShowDialog() == DialogResult.OK)
                    {
                        bool success = ClientRepository.Update(formModif.ClientModifie);
                        if (success)
                        {
                            MessageBox.Show("Client mis à jour avec succès!", "Succès",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ChargerClients();
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


        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                using (var formAjout = new AjouterClient())
                {
                    if (formAjout.ShowDialog() == DialogResult.OK)
                    {
                        bool success = ClientRepository.Add(formAjout.NouveauClient);
                        if (success)
                        {
                            MessageBox.Show("Client ajouté avec succès!", "Succès",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ChargerClients();
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
            ChargerClients(txtRecherche.Text.Trim());
        }

        private void SupprimerClient(int id)
        {
            var confirmation = MessageBox.Show($"Êtes-vous sûr de vouloir supprimer ce client (ID: {id})?",
                                             "Confirmation de suppression",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Warning);

            if (confirmation == DialogResult.Yes)
            {
                try
                {
                    if (ClientRepository.Delete(id))
                    {
                        MessageBox.Show("Client supprimé avec succès.",
                                      "Succès",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);
                        ChargerClients();
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
    }
}