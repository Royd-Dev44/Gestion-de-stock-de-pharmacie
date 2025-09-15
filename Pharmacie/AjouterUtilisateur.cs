using Pharmacie.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pharmacie
{
    public partial class AjouterUtilisateur : Form
    {
        public Utilisateur NouvelUtilisateur { get; private set; }

        public AjouterUtilisateur()
        {
            InitializeComponent();
            NouvelUtilisateur = new Utilisateur();
            ChargerRoles();
            ApplyModernStyle();
        }

        private void ApplyModernStyle()
        {
            // Style général du formulaire
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.Text = "Ajouter un nouvel utilisateur";
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
                    textBox.Height = 50;
           
             
                }
            }

            // Style du ComboBox (Role)
            if (this.Controls.ContainsKey("cbRole"))
            {
                cbRole.Font = new Font("Segoe UI", 10);
                cbRole.Height = 50;
            
               
                cbRole.DropDownStyle = ComboBoxStyle.DropDownList;
                cbRole.FlatStyle = FlatStyle.Flat;
            }

            // Style du TextBox mot de passe
            if (this.Controls.ContainsKey("txtMdp"))
            {
                txtMdp.PasswordChar = '•'; // Masquer le mot de passe
                txtMdp.Font = new Font("Segoe UI", 10);
                txtMdp.Height = 50;
            
                
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
                (cbRole.Visible ? cbRole.Bottom : txtMdp.Bottom) + 20,
                this.ClientSize.Height - 60);

            btnEnregistrer.Top = buttonY;
            btnAnnuler.Top = buttonY;

            btnEnregistrer.Left = (this.ClientSize.Width - (btnEnregistrer.Width + btnAnnuler.Width + 20)) / 2;
            btnAnnuler.Left = btnEnregistrer.Right + 20;
        }

        private void ChargerRoles()
        {
            cbRole.Items.AddRange(new string[] { "admin", "vendeur", "gestionnaire" });
            cbRole.SelectedIndex = 0;
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text))
            {
                MessageBox.Show("Le nom est obligatoire", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNom.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMdp.Text))
            {
                MessageBox.Show("Le mot de passe est obligatoire", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMdp.Focus();
                return;
            }

            NouvelUtilisateur.Nom = txtNom.Text;
            NouvelUtilisateur.Telephone = txtTelephone.Text;
            NouvelUtilisateur.Email = txtEmail.Text;
            NouvelUtilisateur.Adresse = txtAdresse.Text;
            NouvelUtilisateur.Mdp = txtMdp.Text;
            NouvelUtilisateur.Role = cbRole.SelectedItem.ToString();

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