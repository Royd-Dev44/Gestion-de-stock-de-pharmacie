using Pharmacie.Data;
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
    public partial class SelectionFournisseur : Form
    {
        public int IdFournisseurSelectionne { get; private set; }
        public string NomFournisseur { get; private set; }

        public SelectionFournisseur()
        {
            InitializeComponent();
            AppliquerStyle();
            ChargerFournisseurs();
        }

        private void AppliquerStyle()
        {
            // Style général du formulaire
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.Text = "Sélectionner un Fournisseur";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Padding = new Padding(0);
      

            // Style du label
            label1.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Margin = new Padding(0, 0, 0, 10);

            // Style de la ComboBox
            cbFournisseur.Font = new Font("Segoe UI", 9);
            cbFournisseur.Height = 32;
            cbFournisseur.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFournisseur.FlatStyle = FlatStyle.Flat;

            // Style des boutons
            btnValider.BackColor = Color.FromArgb(0, 123, 255);
            btnValider.ForeColor = Color.White;
            btnValider.FlatStyle = FlatStyle.Flat;
            btnValider.FlatAppearance.BorderSize = 0;
            btnValider.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnValider.Height = 36;
            btnValider.Cursor = Cursors.Hand;
            btnValider.Margin = new Padding(0, 15, 10, 0);

            btnAnnuler.BackColor = Color.FromArgb(108, 117, 125);
            btnAnnuler.ForeColor = Color.White;
            btnAnnuler.FlatStyle = FlatStyle.Flat;
            btnAnnuler.FlatAppearance.BorderSize = 0;
            btnAnnuler.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnAnnuler.Height = 36;
            btnAnnuler.Cursor = Cursors.Hand;
            btnAnnuler.Margin = new Padding(0, 15, 0, 0);

   
        }

        private void ChargerFournisseurs()
        {
            try
            {
                cbFournisseur.DataSource = FournisseurRepository.GetAll();
                cbFournisseur.DisplayMember = "Nom";
                cbFournisseur.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (cbFournisseur.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez sélectionner un fournisseur", "Information",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            IdFournisseurSelectionne = (int)cbFournisseur.SelectedValue;
            NomFournisseur = cbFournisseur.Text;
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