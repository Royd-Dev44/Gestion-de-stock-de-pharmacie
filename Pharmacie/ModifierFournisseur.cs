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

namespace Pharmacie
{
    public partial class ModifierFournisseur : Form
    {
        public Fournisseur FournisseurModifie { get; private set; }

        public ModifierFournisseur(Fournisseur fournisseur)
        {
            InitializeComponent();
            AppliquerStyle();
            FournisseurModifie = fournisseur;
            AfficherDonneesFournisseur();
        }

        private void AppliquerStyle()
        {
            // Style général du formulaire
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9.5f);
            this.Text = "Modifier Fournisseur";
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
            btnAnnuler.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnAnnuler.Height = 36;
            btnAnnuler.Cursor = Cursors.Hand;
            btnAnnuler.Margin = new Padding(0, 10, 0, 0);
        }

        private void AfficherDonneesFournisseur()
        {
            txtNom.Text = FournisseurModifie.Nom;
            txtTelephone.Text = FournisseurModifie.Telephone;
            txtEmail.Text = FournisseurModifie.Email;
            txtAdresse.Text = FournisseurModifie.Adresse;
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

            FournisseurModifie.Nom = txtNom.Text;
            FournisseurModifie.Telephone = txtTelephone.Text;
            FournisseurModifie.Email = txtEmail.Text;
            FournisseurModifie.Adresse = txtAdresse.Text;

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