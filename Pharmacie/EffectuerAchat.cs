using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Pharmacie.Data;
using Pharmacie.Models;

namespace Pharmacie
{
    public partial class EffectuerAchat : Form
    {
        private Achat _achat;
        private int _idUtilisateur;
        private const string PrixUnitaireColumnName = "colPrix";
        private const string DateExpirationColumnName = "colExpiration";
        private int hoveredRowIndex = -1;
        private int hoveredColumnIndex = -1;

        public bool AchatEffectue { get; private set; } = false;
        public EffectuerAchat(int idFournisseur, string nomFournisseur, int idUtilisateur)
        {
            InitializeComponent();
            _achat = new Achat
            {
                IdFournisseur = idFournisseur,
                IdUtilisateur = idUtilisateur,
                Lots = new List<LotAchat>()
            };
            _idUtilisateur = idUtilisateur;
            ApplyModernStyle();
            txtFournisseur.Text = nomFournisseur;
            ConfigurerDataGridView();
            ChargerMedicaments();
            dtpExpiration.MinDate = DateTime.Today;

            DgvLots.CellMouseMove += DgvLots_CellMouseMove;
            DgvLots.MouseLeave += DgvLots_MouseLeave;
            DgvLots.CellPainting += DgvLots_CellPainting;
        }

        private void ApplyModernStyle()
        {
            // Style général du formulaire
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.Text = "Effectuer un Achat";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Padding = new Padding(0);

         

            // Style des contrôles de saisie
            cbMedicament.Font = new Font("Segoe UI", 9);
            cbMedicament.Height = 32;
            numQuantite.Font = new Font("Segoe UI", 9);
            numQuantite.Height = 32;
            txtPrix.Font = new Font("Segoe UI", 9);
            txtPrix.Height = 32;
            dtpExpiration.Font = new Font("Segoe UI", 9);
            dtpExpiration.Height = 32;
            txtTotal.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            txtTotal.ForeColor = Color.FromArgb(40, 167, 69);

            // Style des boutons
            btnAjouter.BackColor = Color.FromArgb(0, 123, 255);
            btnAjouter.ForeColor = Color.White;
            btnAjouter.FlatStyle = FlatStyle.Flat;
            btnAjouter.FlatAppearance.BorderSize = 0;
            btnAjouter.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnAjouter.Height = 36;
            btnAjouter.Cursor = Cursors.Hand;

            btnTerminer.BackColor = Color.FromArgb(40, 167, 69);
            btnTerminer.ForeColor = Color.White;
            btnTerminer.FlatStyle = FlatStyle.Flat;
            btnTerminer.FlatAppearance.BorderSize = 0;
            btnTerminer.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnTerminer.Height = 36;
            btnTerminer.Cursor = Cursors.Hand;

            btnAnnuler.BackColor = Color.FromArgb(108, 117, 125);
            btnAnnuler.ForeColor = Color.White;
            btnAnnuler.FlatStyle = FlatStyle.Flat;
            btnAnnuler.FlatAppearance.BorderSize = 0;
            btnAnnuler.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnAnnuler.Height = 36;
            btnAnnuler.Cursor = Cursors.Hand;
        }

        private void ConfigurerDataGridView()
        {
            DgvLots.AutoGenerateColumns = false;
            DgvLots.AllowUserToAddRows = false;
            DgvLots.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvLots.Columns.Clear();

            // Style du DataGridView
            DgvLots.BorderStyle = BorderStyle.None;
            DgvLots.EnableHeadersVisualStyles = false;
            DgvLots.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DgvLots.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DgvLots.GridColor = Color.FromArgb(240, 240, 240);

            DgvLots.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            DgvLots.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DgvLots.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            DgvLots.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
            DgvLots.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            DgvLots.ColumnHeadersHeight = 60;

            DgvLots.RowTemplate.Height = 35;
            DgvLots.RowTemplate.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            DgvLots.DefaultCellStyle.BackColor = Color.White;
            DgvLots.DefaultCellStyle.ForeColor = Color.Black;
            DgvLots.DefaultCellStyle.SelectionBackColor = Color.FromArgb(231, 246, 253);
            DgvLots.DefaultCellStyle.SelectionForeColor = Color.Black;
            DgvLots.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);

            DgvLots.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
           

            // Colonnes
            DgvLots.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdMedicament",
                DataPropertyName = "IdMedicament",
                Visible = false
            });

            DgvLots.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNom",
                HeaderText = "Médicament",
                DataPropertyName = "NomMedicament",
                Width = 180,
                ReadOnly = true
            });

            DgvLots.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colQuantite",
                HeaderText = "Quantité",
                DataPropertyName = "Quantite",
                Width = 90,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            DgvLots.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPrix",
                HeaderText = "Prix Unitaire",
                DataPropertyName = "PrixUnitaire",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N", Alignment = DataGridViewContentAlignment.MiddleRight },
                Width = 110,
                ReadOnly = true
            });

            DgvLots.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTotal",
                HeaderText = "Total (Ar)",
                ValueType = typeof(decimal),
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N", Alignment = DataGridViewContentAlignment.MiddleRight },
                Width = 110,
                ReadOnly = true
            });

            DgvLots.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = DateExpirationColumnName,
                HeaderText = "Expiration",
                DataPropertyName = "DateExpiration",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "d", Alignment = DataGridViewContentAlignment.MiddleCenter },
                Width = 120,
                ReadOnly = true
            });

            // Colonne bouton Supprimer
            var btnSupprimer = new DataGridViewButtonColumn
            {
                Name = "colSupprimer",
                HeaderText = "",
                Text = "Supprimer",
                UseColumnTextForButtonValue = true,
                Width = 90,
                FlatStyle = FlatStyle.Flat,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.White,
                    ForeColor = Color.Black,
                    SelectionBackColor = Color.White,
                    SelectionForeColor = Color.Black,
                    Font = new Font("Segoe UI", 8.5f, FontStyle.Bold),
                    Padding = new Padding(0)
                }
            };

            DgvLots.Columns.Add(btnSupprimer);


            // Événement CellClick
            DgvLots.CellClick += DgvLots_CellClick;

            // Double buffering
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.SetProperty,
                null, DgvLots, new object[] { true });
        }

        private void DgvLots_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 &&
                DgvLots.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                hoveredRowIndex = e.RowIndex;
                hoveredColumnIndex = e.ColumnIndex;
                DgvLots.Invalidate();
            }
            else
            {
                hoveredRowIndex = -1;
                hoveredColumnIndex = -1;
                DgvLots.Invalidate();
            }
        }

        private void DgvLots_MouseLeave(object sender, EventArgs e)
        {
            hoveredRowIndex = -1;
            hoveredColumnIndex = -1;
            DgvLots.Invalidate();
        }

        private void DgvLots_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 &&
                e.ColumnIndex < DgvLots.Columns.Count &&
                DgvLots.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
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

                string buttonText = DgvLots.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString() ?? "";

                TextRenderer.DrawText(e.Graphics,
                    buttonText,
                    DgvLots.DefaultCellStyle.Font,
                    e.CellBounds,
                    foreColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                e.Handled = true;
            }
        }
        private void DgvLots_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == DgvLots.Columns["colSupprimer"].Index)
            {
                var lot = DgvLots.Rows[e.RowIndex].DataBoundItem as LotAchat;
                if (lot != null)
                {
                    SupprimerLot(lot);
                }
            }
        }

        private void SupprimerLot(LotAchat lot)
        {
            if (MessageBox.Show("Supprimer ce lot ?", "Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _achat.Total -= lot.Quantite * lot.PrixUnitaire;
                _achat.Lots.Remove(lot);
                ActualiserListeLots();
                ActualiserTotal();
            }
        }

        private void ChargerMedicaments()
        {
            try
            {
                cbMedicament.DataSource = MedicamentRepository.GetAll();
                cbMedicament.DisplayMember = "Nom";
                cbMedicament.ValueMember = "Id";
                cbMedicament.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des médicaments: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (cbMedicament.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez sélectionner un médicament", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(numQuantite.Text, out int quantite) || quantite <= 0)
            {
                MessageBox.Show("Quantité invalide", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                numQuantite.Focus();
                return;
            }

            if (!decimal.TryParse(txtPrix.Text, out decimal prix) || prix <= 0)
            {
                MessageBox.Show("Prix unitaire invalide", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrix.Focus();
                return;
            }

            var medicament = (Medicament)cbMedicament.SelectedItem;
            var lot = new LotAchat
            {
                IdMedicament = medicament.Id,
                NomMedicament = medicament.Nom,
                Quantite = quantite,
                DateExpiration = dtpExpiration.Value,
                PrixUnitaire = prix
            };

            _achat.Lots.Add(lot);
            _achat.Total += lot.Total;

            ActualiserListeLots();
            ActualiserTotal();
            ReinitialiserChampsLot();
        }

        private void btnTerminer_Click(object sender, EventArgs e)
        {
            if (_achat.Lots.Count == 0)
            {
                MessageBox.Show("Aucun lot à enregistrer", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                if (!_achat.IdAchat.HasValue)
                {
                    _achat.IdAchat = AchatRepository.CreateAchat(_achat);
                    foreach (var lot in _achat.Lots)
                    {
                        AchatRepository.AddLot(_achat.IdAchat.Value, lot);
                    }
                }

                if (AchatRepository.UpdateStatut(_achat.IdAchat.Value, StatutAchat.EnAttente))
                {
                    AchatEffectue = true; // Définir à true lorsque l'achat est réussi
                    MessageBox.Show("Achat enregistré avec succès", "Succès",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'enregistrement: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Annuler cet achat ?", "Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_achat.IdAchat.HasValue)
                {
                    try
                    {
                        AchatRepository.UpdateStatut(_achat.IdAchat.Value, StatutAchat.Annule);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur lors de l'annulation: {ex.Message}",
                            "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void ActualiserListeLots()
        {
            var bindingSource = new BindingSource
            {
                DataSource = _achat.Lots
            };
            DgvLots.DataSource = bindingSource;
        }

        private void ActualiserTotal()
        {
            txtTotal.Text = _achat.Total.ToString("N2");
        }

        private void ReinitialiserChampsLot()
        {
            numQuantite.Value = 1;
            txtPrix.Text = "";
            dtpExpiration.Value = DateTime.Today.AddYears(1);
            cbMedicament.Focus();
        }
    }
}