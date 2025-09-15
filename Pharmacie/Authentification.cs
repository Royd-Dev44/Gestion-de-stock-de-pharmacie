using MySql.Data.MySqlClient;
using Pharmacie.Data;
using System;
using System.Drawing;
using System.Windows.Forms;
using Pharmacie.Models;

namespace Pharmacie
{
    public partial class Authentification : Form
    {
        public Authentification()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(Authentification_Paint);
        }

        private void Authentification_Paint(object sender, PaintEventArgs e)
        {
            // Dessiner un fond dégradé
            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(44, 62, 80),
                Color.FromArgb(76, 161, 175),
                45f))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Veuillez saisir un nom d'utilisateur et un mot de passe.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (VerifierIdentifiants(username, password))
            {
                this.Hide();
                MainForm main = new MainForm();
                main.Show();
            }
            else
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtUsername.Focus();
            }
        }

        private bool VerifierIdentifiants(string username, string password)
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id, nom, role FROM utilisateur WHERE nom = @username AND mdp = @password";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            SessionUtilisateur.Id = reader.GetInt32("id");
                            SessionUtilisateur.Nom = reader.GetString("nom");
                            SessionUtilisateur.Role = reader.IsDBNull(reader.GetOrdinal("role")) ? null : reader.GetString("role");
                            return true;
                        }
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur de connexion : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
    }
}