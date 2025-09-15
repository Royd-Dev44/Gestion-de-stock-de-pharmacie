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
    public partial class MedicamentForm : Form
    {
        private int hoveredRowIndex = -1;
        private int hoveredColumnIndex = -1;
        private string _filtreActuel = "EnStock";

        private readonly Color buttonNormalColor = Color.FromArgb(233, 236, 239);
        private readonly Color buttonHoverColor = Color.FromArgb(206, 212, 218);
        private readonly Color buttonActiveColor = Color.FromArgb(0, 123, 255);
        private readonly Color textNormalColor = Color.FromArgb(73, 80, 87);
        private readonly Color textActiveColor = Color.White;
        private Button currentActiveFilterButton;

        public MedicamentForm()
        {

            InitializeComponent();
            ConfigurerDataGridView();
            AppliquerStyle();
            StylerBoutonsFiltres();
            StylerBarreRecherche();
            StylerBoutonAjouter();

            // Abonnement aux nouveaux événements
            dgvMedicaments.CellMouseEnter += dgvMedicaments_CellMouseEnter;
            dgvMedicaments.CellMouseLeave += dgvMedicaments_CellMouseLeave;
            dgvMedicaments.RowPostPaint += dgvMedicaments_RowPostPaint;

            dgvMedicaments.CellPainting += dgvMedicaments_CellPainting;
            dgvMedicaments.CellMouseMove += dgvMedicaments_CellMouseMove;
            dgvMedicaments.MouseLeave += dgvMedicaments_MouseLeave;


        }
        private void StylerBoutonsFiltres()
        {
            // Liste de tous les boutons de filtre
            var filterButtons = new[] { btnTout, btnEnstock, btnRupture, btnExpire };

            foreach (Button btn in filterButtons)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = buttonNormalColor;
                btn.ForeColor = textNormalColor;
                btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                btn.Height = 36;
                btn.Cursor = Cursors.Hand;
                btn.Padding = new Padding(10, 0, 10, 0);
                btn.Margin = new Padding(5);

                // Gestion des états
                btn.FlatAppearance.MouseOverBackColor = buttonHoverColor;
                btn.FlatAppearance.MouseDownBackColor = buttonActiveColor;

                btn.MouseEnter += (s, e) =>
                {
                    if (btn != currentActiveFilterButton)
                    {
                        btn.BackColor = buttonHoverColor;
                        btn.ForeColor = textNormalColor;
                    }
                };

                btn.MouseLeave += (s, e) =>
                {
                    if (btn != currentActiveFilterButton)
                    {
                        btn.BackColor = buttonNormalColor;
                        btn.ForeColor = textNormalColor;
                    }
                };

                btn.MouseDown += (s, e) =>
                {
                    if (btn != currentActiveFilterButton)
                        btn.BackColor = buttonActiveColor;
                };

                btn.MouseUp += (s, e) =>
                {
                    if (btn != currentActiveFilterButton)
                        btn.BackColor = buttonHoverColor;
                };
            }

            // Définir le bouton actif par défaut
            SetActiveFilterButton(btnEnstock);
        }
        private void SetActiveFilterButton(Button activeButton)
        {
            if (currentActiveFilterButton != null)
            {
                currentActiveFilterButton.BackColor = buttonNormalColor;
                currentActiveFilterButton.ForeColor = textNormalColor;
            }

            currentActiveFilterButton = activeButton;
            currentActiveFilterButton.BackColor = buttonActiveColor;
            currentActiveFilterButton.ForeColor = textActiveColor;
        }

        private void StylerBarreRecherche()
        {
            // Style du TextBox de recherche
            txtRecherche.Font = new Font("Segoe UI", 10);
            txtRecherche.BorderStyle = BorderStyle.FixedSingle;
            txtRecherche.Height = 36;
            txtRecherche.BackColor = Color.White;
            txtRecherche.ForeColor = Color.FromArgb(64, 64, 64);
            txtRecherche.Padding = new Padding(10, 0, 0, 0);

      
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


        private void dgvMedicaments_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 &&
                dgvMedicaments.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                hoveredRowIndex = e.RowIndex;
                hoveredColumnIndex = e.ColumnIndex;
                dgvMedicaments.Invalidate(); // Redessine
            }
            else
            {
                hoveredRowIndex = -1;
                hoveredColumnIndex = -1;
                dgvMedicaments.Invalidate();
            }
        }

        private void dgvMedicaments_MouseLeave(object sender, EventArgs e)
        {
            hoveredRowIndex = -1;
            hoveredColumnIndex = -1;
            dgvMedicaments.Invalidate();
        }


        private void ConfigurerDataGridView()
        {
            dgvMedicaments.AutoGenerateColumns = false;
            dgvMedicaments.AllowUserToAddRows = false;
            dgvMedicaments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMedicaments.ReadOnly = true;
            dgvMedicaments.Columns.Clear();
            dgvMedicaments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMedicaments.AllowUserToResizeColumns = false;

            AddColumn("colId", "ID", "Id", 50, false);
            AddColumn("colNom", "Nom", "Nom", 150);
            AddColumn("colDescription", "Description", "Description", 200);
            AddColumn("colPrix", "Prix", "Prix", 80);
            AddColumn("colQuantite", "Qté Restante", "QuantiteRestante", 60);
            AddColumn("colLot", "N° Lot", "IdLot", 80);
            AddColumn("colExpiration", "Expiration", "DateExpiration", 100, format: "d");
            AddColumn("colJours", "Jours Restants", "JoursRestants", 80);
            AddColumn("colFournisseur", "Fournisseur", "Fournisseur", 150);
            AddColumn("colDateAchat", "Date Achat", "DateAchat", 100, format: "d");

            AddButtonColumn("colModifier", "Modifier", 80);
            AddButtonColumn("colSupprimer", "Supprimer", 80);
            AppliquerStyle();

            dgvMedicaments.CellFormatting += (sender, e) =>
            {
                if (e.ColumnIndex == dgvMedicaments.Columns["colJours"].Index && e.Value != null)
                {
                    int jours = Convert.ToInt32(e.Value);
                    if (jours <= 7)
                    {
                        e.CellStyle.BackColor = Color.FromArgb(255, 205, 210);
                        e.CellStyle.ForeColor = Color.Black;
                        e.CellStyle.Font = new Font(dgvMedicaments.Font, FontStyle.Bold);
                    }
                    else if (jours <= 30)
                    {
                        e.CellStyle.BackColor = Color.FromArgb(255, 243, 224);
                        e.CellStyle.ForeColor = Color.Black;
                    }
                }

                if (e.ColumnIndex == dgvMedicaments.Columns["colDateAchat"].Index && e.Value is DateTime date && date == DateTime.MinValue)
                {
                    e.Value = "N/A";
                    e.CellStyle.ForeColor = Color.Gray;
                    e.CellStyle.Font = new Font(dgvMedicaments.Font, FontStyle.Italic);
                }

                if (e.ColumnIndex == dgvMedicaments.Columns["colPrix"].Index ||
                    e.ColumnIndex == dgvMedicaments.Columns["colQuantite"].Index ||
                    e.ColumnIndex == dgvMedicaments.Columns["colJours"].Index)
                {
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    e.CellStyle.Padding = new Padding(0, 0, 10, 0);
                }
            };
        }

        private void AppliquerStyle()
        {
            dgvMedicaments.BorderStyle = BorderStyle.None;
            dgvMedicaments.EnableHeadersVisualStyles = false;
            dgvMedicaments.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvMedicaments.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMedicaments.GridColor = Color.FromArgb(240, 240, 240);

            dgvMedicaments.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dgvMedicaments.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMedicaments.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvMedicaments.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
            dgvMedicaments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvMedicaments.ColumnHeadersHeight = 70;

            dgvMedicaments.RowTemplate.Height = 50;
            dgvMedicaments.RowTemplate.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);
            dgvMedicaments.DefaultCellStyle.BackColor = Color.White;
            dgvMedicaments.DefaultCellStyle.ForeColor = Color.Black;
            dgvMedicaments.DefaultCellStyle.SelectionBackColor = Color.FromArgb(231, 246, 253);
            dgvMedicaments.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvMedicaments.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);

            dgvMedicaments.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMedicaments.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

           

            foreach (DataGridViewColumn col in dgvMedicaments.Columns)
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

            dgvMedicaments.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(231, 246, 253);
            dgvMedicaments.RowsDefaultCellStyle.SelectionForeColor = Color.Black;

            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.SetProperty,
                null, dgvMedicaments, new object[] { true });

        }

        
        private void dgvMedicaments_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvMedicaments.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            }
        }

        private void dgvMedicaments_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvMedicaments.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                    e.RowIndex % 2 == 0 ? Color.White : Color.FromArgb(248, 248, 248);
            }
        }

        private void dgvMedicaments_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

            dgvMedicaments.Columns.Add(col);
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
       

            dgvMedicaments.Columns.Add(btnColumn);
        }

        private void MedicamentForm_Load(object sender, EventArgs e)
        {
            ChargerMedicaments();
            dgvMedicaments.CellPainting += dgvMedicaments_CellPainting;


        }
        private void dgvMedicaments_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 &&
        e.ColumnIndex < dgvMedicaments.Columns.Count &&
        dgvMedicaments.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                e.PaintBackground(e.CellBounds, true);

                // Définir couleurs par défaut
                Color backColor = Color.White;
                Color foreColor = Color.Black;

                // Appliquer hover si survolé
                if (e.RowIndex == hoveredRowIndex && e.ColumnIndex == hoveredColumnIndex)
                {
                    backColor = Color.FromArgb(231, 246, 253); // Couleur de survol
                }

                using (SolidBrush brush = new SolidBrush(backColor))
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                }

                string buttonText = dgvMedicaments.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString() ?? "";

                TextRenderer.DrawText(e.Graphics,
                    buttonText,
                    dgvMedicaments.DefaultCellStyle.Font, // Même police que les autres cellules
                    e.CellBounds,
                    foreColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                e.Handled = true;
            }
        }


        private void ChargerMedicaments()
        {
            try
            {
                dgvMedicaments.DataSource = MedicamentRepository.GetEnStock();

                // Formatage spécifique pour la colonne Prix
                dgvMedicaments.Columns["colPrix"].DefaultCellStyle.Format = "N0"; // Format sans décimales
                dgvMedicaments.Columns["colPrix"].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("mg-MG");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement: {ex.Message}", "Erreur",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
        private void ModifierMedicament(int id)
        {
            try
            {
                var medicament = MedicamentRepository.GetById(id);
                if (medicament == null)
                {
                    MessageBox.Show("Médicament introuvable.", "Erreur",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var formModif = new AjouterMedicamentForm(medicament))
                {
                    var result = formModif.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        // Sauvegarder les modifications
                        bool success = MedicamentRepository.Update(formModif.NouveauMedicament);
                        if (success)
                        {
                            MessageBox.Show("Médicament mis à jour avec succès!", "Succès",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ChargerMedicaments(); // Rafraîchir les données
                        }
                        else
                        {
                            MessageBox.Show("Échec de la mise à jour.", "Erreur",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (result == DialogResult.Abort && formModif.SuppressionDemandee)
                    {
                        // Supprimer le médicament
                        bool success = MedicamentRepository.Delete(formModif.NouveauMedicament.Id);
                        if (success)
                        {
                            MessageBox.Show("Médicament supprimé avec succès !", "Succès",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ChargerMedicaments();
                        }
                        else
                        {
                            MessageBox.Show("Échec de la suppression.", "Erreur",
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

        private void AjouterMedicament()
        {
            try
            {
                using (var formAjout = new AjouterMedicamentForm())
                {
                    if (formAjout.ShowDialog() == DialogResult.OK)
                    {
                        bool success = MedicamentRepository.Add(formAjout.NouveauMedicament);
                        if (success)
                        {
                            MessageBox.Show("Médicament ajouté avec succès!", "Succès",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ChargerMedicaments();
                        }
                        else
                        {
                            MessageBox.Show("Échec de l'ajout du médicament.", "Erreur",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private void SupprimerMedicament(int id)
        {
            var confirmation = MessageBox.Show($"Êtes-vous sûr de vouloir supprimer ce médicament (ID: {id})?",
                                             "Confirmation de suppression",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Warning);

            if (confirmation == DialogResult.Yes)
            {
                try
                {
                    if (MedicamentRepository.Delete(id))
                    {
                        MessageBox.Show("Médicament supprimé avec succès.",
                                      "Succès",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);
                        ChargerMedicaments();
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
            // Style du bouton Ajouter
            btnAjouter.BackColor = Color.FromArgb(40, 167, 69); 
            btnAjouter.ForeColor = Color.White;
            btnAjouter.FlatStyle = FlatStyle.Flat;
            btnAjouter.FlatAppearance.BorderSize = 0;
           
        
            btnAjouter.Cursor = Cursors.Hand;
           

            try
            {
                using (var formAjout = new AjouterMedicamentForm())
                {
                    if (formAjout.ShowDialog() == DialogResult.OK)
                    {
                        bool success = MedicamentRepository.Add(formAjout.NouveauMedicament);
                        if (success)
                        {
                            MessageBox.Show("Médicament ajouté avec succès!", "Succès",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ChargerMedicaments();
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



        private void ChargerMedicaments(string searchTerm = "")
        {
            try
            {
                switch (_filtreActuel)
                {
                    case "Tout":
                        dgvMedicaments.DataSource = MedicamentRepository.Search(searchTerm);
                        break;
                    case "EnStock":
                        dgvMedicaments.DataSource = MedicamentRepository.GetEnStock(searchTerm);
                        break;
                    case "Rupture":
                        dgvMedicaments.DataSource = MedicamentRepository.GetEnRupture(searchTerm);
                        break;
                    case "Expire":
                        dgvMedicaments.DataSource = MedicamentRepository.GetExpires(searchTerm);
                        break;
                    default:
                        dgvMedicaments.DataSource = MedicamentRepository.GetEnStock(searchTerm);
                        break;
                }

                // Formatage spécifique pour la colonne Prix
                dgvMedicaments.Columns["colPrix"].DefaultCellStyle.Format = "N0";
                dgvMedicaments.Columns["colPrix"].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("mg-MG");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement: {ex.Message}", "Erreur",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }








        private void btnTout_Click(object sender, EventArgs e)
        {
            _filtreActuel = "Tout";
            SetActiveFilterButton((Button)sender);
            ChargerMedicaments(txtRecherche.Text.Trim());
        }

        private void btnEnstock_Click(object sender, EventArgs e)
        {
            _filtreActuel = "EnStock";
            SetActiveFilterButton((Button)sender);
            ChargerMedicaments(txtRecherche.Text.Trim());
        }

        private void btnRupture_Click(object sender, EventArgs e)
        {
            _filtreActuel = "Rupture";
            SetActiveFilterButton((Button)sender);
            ChargerMedicaments(txtRecherche.Text.Trim());
        }

        private void btnExpire_Click(object sender, EventArgs e)
        {
            _filtreActuel = "Expire";
            SetActiveFilterButton((Button)sender);
            ChargerMedicaments(txtRecherche.Text.Trim());
        }


        private void MettreAJourStyleBoutons(Button boutonActif)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is Button btn)
                {
                    // Réinitialiser tous les boutons au style inactif
                    btn.BackColor = Color.FromArgb(233, 236, 239); // Gris clair
                    btn.ForeColor = Color.FromArgb(73, 80, 87);    // Gris foncé
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(206, 212, 218); // Gris plus foncé au survol
                }
            }

            // Appliquer le style actif seulement au bouton cliqué
            boutonActif.BackColor = Color.FromArgb(0, 123, 255); // Bleu
            boutonActif.ForeColor = Color.White;
            boutonActif.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 105, 217); // Bleu plus foncé au survol
        }
        private void txtRecherche_TextChanged(object sender, EventArgs e)
        {
            ChargerMedicaments(txtRecherche.Text.Trim());
        }

        private void dgvMedicaments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var grid = sender as DataGridView;
            int id = Convert.ToInt32(grid.Rows[e.RowIndex].Cells["colId"].Value);
            decimal idLot = Convert.ToDecimal(grid.Rows[e.RowIndex].Cells["colLot"].Value);

            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                if (grid.Columns[e.ColumnIndex].Name == "colModifier")
                {
                    ModifierMedicament(id);
                }
                else if (grid.Columns[e.ColumnIndex].Name == "colSupprimer")
                {
                    SupprimerLot(idLot, id);
                }
            }
        }
        private void SupprimerLot(decimal idLot, int idMedicament)
        {
            var confirmation = MessageBox.Show($"Êtes-vous sûr de vouloir supprimer ce lot (ID: {idLot}) ?\nCette action ne supprimera que ce lot spécifique, pas tout le médicament.",
                                             "Confirmation de suppression",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Warning);

            if (confirmation == DialogResult.Yes)
            {
                try
                {
                    if (MedicamentRepository.DeleteLot((int)idLot))
                    {
                        MessageBox.Show("Lot supprimé avec succès !", "Succès",
                                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ChargerMedicaments(txtRecherche.Text.Trim());
                    }
                    else
                    {
                        MessageBox.Show("Échec de la suppression du lot.", "Erreur",
                                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la suppression du lot: {ex.Message}", "Erreur",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
    }
}
