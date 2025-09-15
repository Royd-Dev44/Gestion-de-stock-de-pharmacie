using MySql.Data.MySqlClient;
using Pharmacie.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pharmacie
{
    public partial class AjouterMedicamentForm : Form
    {
        public Medicament NouveauMedicament { get; private set; }
        public bool SuppressionDemandee { get; private set; } = false;

        public AjouterMedicamentForm(Medicament medicamentExistante = null)
        {
            InitializeComponent();
            AppliquerStyle();

            if (medicamentExistante != null)
            {
                NouveauMedicament = medicamentExistante;
                txtNom.Text = medicamentExistante.Nom;
                txtDescription.Text = medicamentExistante.Description;
                txtPrix.Text = medicamentExistante.Prix.ToString();

                btnSupprimer.Enabled = true;
                btnSupprimer.Visible = true;
                this.Text = "Modifier/Supprimer un Médicament";
            }
            else
            {
                NouveauMedicament = new Medicament();
                btnSupprimer.Enabled = false;
                btnSupprimer.Visible = false;
                this.Text = "Ajouter un Médicament";
            }
        }

        private void AppliquerStyle()
        {
            // Style général du formulaire
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9.5f);
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
                if (ctrl is TextBox txt && txt != txtDescription)
                {
                    txt.Font = new Font("Segoe UI", 10);
                    txt.BorderStyle = BorderStyle.Fixed3D;
                    txt.Height = 35;
                    txt.Margin = new Padding(0, 0, 0, 15);
                }
            }

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
            btnAnnuler.Margin = new Padding(0, 10, 10, 0);

            btnSupprimer.BackColor = Color.FromArgb(220, 53, 69);
            btnSupprimer.ForeColor = Color.White;
            btnSupprimer.FlatStyle = FlatStyle.Flat;
            btnSupprimer.FlatAppearance.BorderSize = 0;
            btnSupprimer.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnSupprimer.Height = 36;
            btnSupprimer.Cursor = Cursors.Hand;
            btnSupprimer.Margin = new Padding(0, 10, 0, 0);
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (ValiderDonnees())
            {
                EnregistrerDonnees();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValiderDonnees()
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text))
            {
                MessageBox.Show("Le nom du médicament est obligatoire.", "Erreur",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNom.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPrix.Text, out decimal prix) || prix <= 0)
            {
                MessageBox.Show("Veuillez entrer un prix valide (nombre positif).", "Erreur",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrix.SelectAll();
                txtPrix.Focus();
                return false;
            }

            return true;
        }

        private void EnregistrerDonnees()
        {
            NouveauMedicament = new Medicament
            {
                Id = NouveauMedicament?.Id ?? 0,
                Nom = txtNom.Text.Trim(),
                Description = string.IsNullOrWhiteSpace(txtDescription.Text) ?
                            null : txtDescription.Text.Trim(),
                Prix = decimal.Parse(txtPrix.Text)
            };
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtPrix_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            if (e.KeyChar == ',' && (sender as TextBox).Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
        }

        private void AjouterMedicamentForm_Load(object sender, EventArgs e)
        {
            txtNom.Focus();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (NouveauMedicament?.Id > 0)
            {
                var confirmation = MessageBox.Show(
                    $"Êtes-vous sûr de vouloir supprimer définitivement le médicament '{NouveauMedicament.Nom}' ?",
                    "Confirmation de suppression",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmation == DialogResult.Yes)
                {
                    SuppressionDemandee = true;
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Aucun médicament existant à supprimer.", "Information",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}