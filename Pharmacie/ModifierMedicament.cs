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
    public partial class ModifierMedicament : Form
    {
        public Medicament MedicamentModifie { get; private set; }

        public ModifierMedicament(Medicament medicament)
        {
            InitializeComponent();
            AppliquerStyle();
            MedicamentModifie = medicament;
            InitialiserControles();
        }

        private void AppliquerStyle()
        {
            // Style général du formulaire
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9.5f);
            this.Text = "Modifier Médicament";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Padding = new Padding(0);

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
                    txt.Height = 50;
                    txt.Margin = new Padding(0, 0, 0, 15);
                }
            }

            // Style des boutons
            btnModifier.BackColor = Color.FromArgb(0, 123, 255);
            btnModifier.ForeColor = Color.White;
            btnModifier.FlatStyle = FlatStyle.Flat;
            btnModifier.FlatAppearance.BorderSize = 0;
            btnModifier.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnModifier.Height = 36;
            btnModifier.Cursor = Cursors.Hand;
            btnModifier.Margin = new Padding(0, 10, 10, 0);

            btnAnnuler.BackColor = Color.FromArgb(108, 117, 125);
            btnAnnuler.ForeColor = Color.White;
            btnAnnuler.FlatStyle = FlatStyle.Flat;
            btnAnnuler.FlatAppearance.BorderSize = 0;
            btnAnnuler.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnAnnuler.Height = 36;
            btnAnnuler.Cursor = Cursors.Hand;
            btnAnnuler.Margin = new Padding(0, 10, 0, 0);
        }

        private void InitialiserControles()
        {
            // Remplir les champs avec les données du médicament
            txtNom.Text = MedicamentModifie.Nom;
            txtDescription.Text = MedicamentModifie.Description;
            txtPrix.Text = MedicamentModifie.Prix.ToString("N0");
        }

        private bool ValiderDonnees()
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text))
            {
                MessageBox.Show("Le nom du médicament est obligatoire.", "Erreur",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNom.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPrix.Text, out decimal prix) || prix <= 0)
            {
                MessageBox.Show("Veuillez entrer un prix valide (nombre positif).", "Erreur",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrix.Focus();
                return false;
            }
            return true;
        }

        // Validation des entrées numériques
        private void txtPrix_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // Permettre seulement un seul séparateur décimal
            if ((e.KeyChar == '.' || e.KeyChar == ',') && ((sender as TextBox).Text.Contains('.') || (sender as TextBox).Text.Contains(',')))
            {
                e.Handled = true;
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (!ValiderDonnees())
                return;

            // Mettre à jour l'objet médicament
            MedicamentModifie.Nom = txtNom.Text.Trim();
            MedicamentModifie.Description = string.IsNullOrWhiteSpace(txtDescription.Text) ?
                                         null : txtDescription.Text.Trim();

            // Normaliser le séparateur décimal avant la conversion
            string prixText = txtPrix.Text.Replace(',', '.');
            MedicamentModifie.Prix = decimal.Parse(prixText, System.Globalization.NumberStyles.Any);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}