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
    public partial class ModifierUtilisateur : Form
    {
        public Utilisateur UtilisateurModifie { get; private set; }
        public ModifierUtilisateur(Utilisateur utilisateurAModifier)
        {
            InitializeComponent();
            UtilisateurModifie = utilisateurAModifier;
            ChargerRoles();

            // Initialiser les champs avec les valeurs actuelles
            txtNom.Text = UtilisateurModifie.Nom;
            txtTelephone.Text = UtilisateurModifie.Telephone;
            txtEmail.Text = UtilisateurModifie.Email;
            txtAdresse.Text = UtilisateurModifie.Adresse;
            cbRole.SelectedItem = UtilisateurModifie.Role;
        }
        private void ChargerRoles()
        {
            cbRole.Items.AddRange(new string[] { "admin", "vendeur", "gestionnaire" });
        }
        

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text))
            {
                MessageBox.Show("Le nom est obligatoire", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UtilisateurModifie.Nom = txtNom.Text;
            UtilisateurModifie.Telephone = txtTelephone.Text;
            UtilisateurModifie.Email = txtEmail.Text;
            UtilisateurModifie.Adresse = txtAdresse.Text;
            UtilisateurModifie.Role = cbRole.SelectedItem.ToString();

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
