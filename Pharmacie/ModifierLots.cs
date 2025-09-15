using Pharmacie.Data;
using Pharmacie.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pharmacie
{
    public partial class ModifierLots : Form
    {
        private int _idLot;
        private Stock _lot;

        public ModifierLots(int idLot)
        {
            InitializeComponent();
            AppliquerStyle();

            // Rendre les champs non modifiables
            txtPrixTotal.ReadOnly = true;

            // Initialisation des événements pour le calcul dynamique
            numQuantite.ValueChanged += RecalculerPrixTotal;
            txtPrix.TextChanged += RecalculerPrixTotal;
            _idLot = idLot;

            // Configuration du ComboBox Statut
            cbStatut.Items.AddRange(new string[] { "confirmé", "en attente", "annulé" });
            cbStatut.SelectedIndex = 0;

            ChargerDonneesLot();
        }

        private void AppliquerStyle()
        {
            // Style général du formulaire
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9.5f);
            this.Text = "Modifier Lot";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Padding = new Padding(10);

            // Style des labels
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label lbl)
                {
                    lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    lbl.ForeColor = Color.FromArgb(64, 64, 64);
                    lbl.Margin = new Padding(0, 0, 0, 5);
                }
            }

            // Style des TextBox
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox txt)
                {
                    txt.Font = new Font("Segoe UI", 10);
                    txt.BorderStyle = BorderStyle.Fixed3D;
                    txt.Height = 35;
                    txt.Margin = new Padding(0, 0, 0, 15);
                }
            }

            // Style des ComboBox
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is ComboBox cb)
                {
                    cb.Font = new Font("Segoe UI", 10);
                    cb.FlatStyle = FlatStyle.Flat;
                    cb.Height = 35;
                    cb.Margin = new Padding(0, 0, 0, 15);
                }
            }

            // Style du NumericUpDown
            numQuantite.Font = new Font("Segoe UI", 10);
            numQuantite.BorderStyle = BorderStyle.Fixed3D;
            numQuantite.Height = 35;
            numQuantite.Margin = new Padding(0, 0, 0, 15);

            // Style du DateTimePicker
            dtpExpiration.Font = new Font("Segoe UI", 10);
            dtpExpiration.Format = DateTimePickerFormat.Short;
            dtpExpiration.Height = 35;
            dtpExpiration.Margin = new Padding(0, 0, 0, 15);

            // Style des boutons
            btnEnregistrer.BackColor = Color.FromArgb(0, 123, 255);
            btnEnregistrer.ForeColor = Color.White;
            btnEnregistrer.FlatStyle = FlatStyle.Flat;
            btnEnregistrer.FlatAppearance.BorderSize = 0;
            btnEnregistrer.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnEnregistrer.Height = 36;
            btnEnregistrer.Cursor = Cursors.Hand;
            btnEnregistrer.Margin = new Padding(0, 10, 10, 0);

            btnAnnuler.BackColor = Color.FromArgb(108, 117, 125);
            btnAnnuler.ForeColor = Color.White;
            btnAnnuler.FlatStyle = FlatStyle.Flat;
            btnAnnuler.FlatAppearance.BorderSize = 0;
            btnAnnuler.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnAnnuler.Height = 36;
            btnAnnuler.Cursor = Cursors.Hand;
            btnAnnuler.Margin = new Padding(0, 10, 0, 0);
        }

        private void ChargerDonneesLot()
        {
            try
            {
                _lot = StockRepository.GetById(_idLot);

                if (_lot != null)
                {
                    ChargerMedicaments();

                    txtLot.Text = $"Lot N°: {_lot.IdLot}";
                    txtAjout.Text = _lot.DateAjout.ToString();
                    numQuantite.Value = _lot.QuantiteTotal;
                    txtPrix.Text = (_lot.TotalAchat / _lot.QuantiteTotal).ToString("N2");
                    dtpExpiration.Value = _lot.DateExpiration;
                    cbStatut.SelectedItem = _lot.Statut;

                    CalculerPrixTotal();
                }
                else
                {
                    MessageBox.Show("Lot non trouvé.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void ChargerMedicaments()
        {
            try
            {
                cbMedicament.DataSource = MedicamentRepository.GetAll();
                cbMedicament.DisplayMember = "Nom";
                cbMedicament.ValueMember = "Id";

                if (_lot != null && _lot.IdMedicament > 0)
                {
                    cbMedicament.SelectedValue = _lot.IdMedicament;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des médicaments: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RecalculerPrixTotal(object sender, EventArgs e)
        {
            CalculerPrixTotal();
        }

        private void CalculerPrixTotal()
        {
            if (decimal.TryParse(txtPrix.Text, out decimal prixUnitaire))
            {
                decimal total = prixUnitaire * numQuantite.Value;
                txtPrixTotal.Text = total.ToString("N2");
            }
            else
            {
                txtPrixTotal.Text = "0.00";
            }
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (!ValiderDonnees())
                return;

            try
            {
                bool success = StockRepository.UpdateLot(
                    _idLot,
                    (int)numQuantite.Value,
                    dtpExpiration.Value,
                    cbStatut.SelectedItem.ToString()
                );

                if (success)
                {
                    MessageBox.Show("Lot modifié avec succès.", "Succès",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Échec de la modification du lot.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la modification: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValiderDonnees()
        {
            if (numQuantite.Value <= 0)
            {
                MessageBox.Show("La quantité doit être supérieure à zéro.", "Erreur de validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!decimal.TryParse(txtPrix.Text, out decimal prix) || prix <= 0)
            {
                MessageBox.Show("Veuillez entrer un prix unitaire valide.", "Erreur de validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (dtpExpiration.Value < DateTime.Today)
            {
                MessageBox.Show("La date d'expiration ne peut pas être dans le passé.", "Erreur de validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cbStatut.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un statut.", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnAnnuler_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}