using System;
using System.Drawing;
using System.Windows.Forms;
using Pharmacie.Models;

namespace Pharmacie
{
    public partial class AjouterFournisseur : Form
    {
        public Fournisseur NouveauFournisseur { get; private set; }

        public AjouterFournisseur()
        {
            InitializeComponent();
            NouveauFournisseur = new Fournisseur();
            ApplyModernStyle();
        }

        private void ApplyModernStyle()
        {
            // Style général du formulaire
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.Text = "Ajouter un nouveau fournisseur";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Centrer le titre 
            if (this.Controls.ContainsKey("label4"))
            {
                var titleLabel = this.Controls["label4"] as Label;
                if (titleLabel != null)
                {
                    titleLabel.TextAlign = ContentAlignment.MiddleCenter;
                    titleLabel.AutoSize = false;
                    titleLabel.Dock = DockStyle.Top;
                    titleLabel.Height = 100;
                    titleLabel.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                    titleLabel.ForeColor = Color.FromArgb(44, 62, 80);
                    titleLabel.Padding = new Padding(0, 20, 0, 0);
                }
            }

            // Style des textbox avec hauteur augmentée
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                    textBox.BackColor = Color.White;
                    textBox.ForeColor = Color.FromArgb(64, 64, 64);
                    textBox.Font = new Font("Segoe UI", 10);
                    textBox.Height = 40; // Hauteur augmentée

                    // Optionnel: largeur proportionnelle
                    textBox.Width = (int)(this.ClientSize.Width * 0.8);
                    textBox.Left = (this.ClientSize.Width - textBox.Width) / 2;
                }
            }

            // Style des boutons
            btnEnregistrer.BackColor = Color.FromArgb(0, 123, 255);
            btnEnregistrer.ForeColor = Color.White;
            btnEnregistrer.FlatStyle = FlatStyle.Flat;
            btnEnregistrer.FlatAppearance.BorderSize = 0;
            btnEnregistrer.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnEnregistrer.Size = new Size(120, 40);
            btnEnregistrer.Cursor = Cursors.Hand;

            btnAnnuler.BackColor = Color.FromArgb(108, 117, 125);
            btnAnnuler.ForeColor = Color.White;
            btnAnnuler.FlatStyle = FlatStyle.Flat;
            btnAnnuler.FlatAppearance.BorderSize = 0;
            btnAnnuler.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnAnnuler.Size = new Size(120, 40);
            btnAnnuler.Cursor = Cursors.Hand;

            // Centrer les boutons
            int buttonY = Math.Max(
                txtAdresse.Bottom + 20,
                this.ClientSize.Height - 60);

            btnEnregistrer.Top = buttonY;
            btnAnnuler.Top = buttonY;

            btnEnregistrer.Left = (this.ClientSize.Width -
                                 (btnEnregistrer.Width + btnAnnuler.Width + 20)) / 2;
            btnAnnuler.Left = btnEnregistrer.Right + 20;
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text))
            {
                MessageBox.Show("Le nom du fournisseur est obligatoire", "Erreur",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNom.Focus();
                return;
            }

            NouveauFournisseur.Nom = txtNom.Text;
            NouveauFournisseur.Telephone = txtTelephone.Text;
            NouveauFournisseur.Email = txtEmail.Text;
            NouveauFournisseur.Adresse = txtAdresse.Text;

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