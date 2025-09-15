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
    public partial class ModifierClient : Form
    {
        public Client ClientModifie { get; private set; }

        public ModifierClient(Client clientAModifier)
        {
            InitializeComponent();
            AppliquerStyle();
            ClientModifie = clientAModifier;

            // Initialiser les champs avec les valeurs actuelles
            txtNom.Text = ClientModifie.Nom;
            txtTelephone.Text = ClientModifie.Telephone;
            txtEmail.Text = ClientModifie.Email;
            txtAdresse.Text = ClientModifie.Adresse;
        }

        private void AppliquerStyle()
        {
            // Style général du formulaire
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9.5f);
            this.Text = "Modifier Client";
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



        private void btnEnregistrer_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text))
            {
                MessageBox.Show("Le nom du fournisseur est obligatoire", "Erreur",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNom.Focus();
                return;
            }

            ClientModifie.Nom = txtNom.Text;
            ClientModifie.Telephone = txtTelephone.Text;
            ClientModifie.Email = txtEmail.Text;
            ClientModifie.Adresse = txtAdresse.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAnnuler_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}