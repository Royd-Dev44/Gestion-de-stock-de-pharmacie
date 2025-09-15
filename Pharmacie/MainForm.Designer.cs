namespace Pharmacie
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUtilisateurConnecte = new System.Windows.Forms.Label();
            this.btnToggleMenu = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnAccueil = new System.Windows.Forms.Button();
            this.btnVente = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.btnMedicaments = new System.Windows.Forms.Button();
            this.btnFournisseur = new System.Windows.Forms.Button();
            this.btnClient = new System.Windows.Forms.Button();
            this.btnUtilisateur = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sideMenu = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelAccueil = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.sideMenu.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CacheAge = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.EnableCaching = false;
            this.mySqlCommand1.Transaction = null;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "home-alt-2-solid-24.png");
            this.imageList1.Images.SetKeyName(1, "pill-bottle-alt.png");
            this.imageList1.Images.SetKeyName(2, "arrow-out-left-square-half.png");
            this.imageList1.Images.SetKeyName(3, "cart.png");
            this.imageList1.Images.SetKeyName(4, "chart-spline.png");
            this.imageList1.Images.SetKeyName(5, "close.png");
            this.imageList1.Images.SetKeyName(6, "globe-alt.png");
            this.imageList1.Images.SetKeyName(7, "home-alt-2-solid-24.png");
            this.imageList1.Images.SetKeyName(8, "pharmacy.png");
            this.imageList1.Images.SetKeyName(9, "pill-bottle-alt.png");
            this.imageList1.Images.SetKeyName(10, "play-regular-24.png");
            this.imageList1.Images.SetKeyName(11, "user.png");
            this.imageList1.Images.SetKeyName(12, "arrow-out-left-square-half.png");
            this.imageList1.Images.SetKeyName(13, "user.png");
            this.imageList1.Images.SetKeyName(14, "user (1).png");
            this.imageList1.Images.SetKeyName(15, "play-regular-24.png");
            this.imageList1.Images.SetKeyName(16, "pill-bottle-alt.png");
            this.imageList1.Images.SetKeyName(17, "pill-bottle-alt (2).png");
            this.imageList1.Images.SetKeyName(18, "pill-bottle-alt (1).png");
            this.imageList1.Images.SetKeyName(19, "pharmacy.png");
            this.imageList1.Images.SetKeyName(20, "pharmacy (1).png");
            this.imageList1.Images.SetKeyName(21, "instagram-alt-logo-24.png");
            this.imageList1.Images.SetKeyName(22, "home-alt-2-solid-24.png");
            this.imageList1.Images.SetKeyName(23, "globe-alt.png");
            this.imageList1.Images.SetKeyName(24, "close.png");
            this.imageList1.Images.SetKeyName(25, "chart-spline.png");
            this.imageList1.Images.SetKeyName(26, "cart.png");
            this.imageList1.Images.SetKeyName(27, "arrow-out-left-square-half.png");
            this.imageList1.Images.SetKeyName(28, "cart (1).png");
            this.imageList1.Images.SetKeyName(29, "box.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblUtilisateurConnecte);
            this.panel1.Controls.Add(this.btnToggleMenu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(333, 150);
            this.panel1.TabIndex = 3;
            // 
            // lblUtilisateurConnecte
            // 
            this.lblUtilisateurConnecte.AutoSize = true;
            this.lblUtilisateurConnecte.BackColor = System.Drawing.Color.Transparent;
            this.lblUtilisateurConnecte.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUtilisateurConnecte.ForeColor = System.Drawing.Color.Black;
            this.lblUtilisateurConnecte.Location = new System.Drawing.Point(91, 30);
            this.lblUtilisateurConnecte.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUtilisateurConnecte.Name = "lblUtilisateurConnecte";
            this.lblUtilisateurConnecte.Size = new System.Drawing.Size(54, 28);
            this.lblUtilisateurConnecte.TabIndex = 3;
            this.lblUtilisateurConnecte.Text = "User";
            // 
            // btnToggleMenu
            // 
            this.btnToggleMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggleMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnToggleMenu.Image")));
            this.btnToggleMenu.Location = new System.Drawing.Point(7, 18);
            this.btnToggleMenu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnToggleMenu.Name = "btnToggleMenu";
            this.btnToggleMenu.Size = new System.Drawing.Size(55, 53);
            this.btnToggleMenu.TabIndex = 3;
            this.btnToggleMenu.UseVisualStyleBackColor = true;
            this.btnToggleMenu.Click += new System.EventHandler(this.btnToggleMenu_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(4, 46);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.btnLogout.Size = new System.Drawing.Size(329, 74);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Se déconnecter";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnAccueil
            // 
            this.btnAccueil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccueil.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAccueil.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccueil.Image = ((System.Drawing.Image)(resources.GetObject("btnAccueil.Image")));
            this.btnAccueil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccueil.Location = new System.Drawing.Point(0, 0);
            this.btnAccueil.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAccueil.Name = "btnAccueil";
            this.btnAccueil.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnAccueil.Size = new System.Drawing.Size(329, 74);
            this.btnAccueil.TabIndex = 4;
            this.btnAccueil.Text = "Accueil";
            this.btnAccueil.UseVisualStyleBackColor = true;
            this.btnAccueil.Click += new System.EventHandler(this.btnAccueil_Click);
            // 
            // btnVente
            // 
            this.btnVente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVente.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVente.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVente.Image = ((System.Drawing.Image)(resources.GetObject("btnVente.Image")));
            this.btnVente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVente.Location = new System.Drawing.Point(0, 74);
            this.btnVente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnVente.Name = "btnVente";
            this.btnVente.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnVente.Size = new System.Drawing.Size(329, 74);
            this.btnVente.TabIndex = 5;
            this.btnVente.Text = "Ventes";
            this.btnVente.UseVisualStyleBackColor = true;
            this.btnVente.Click += new System.EventHandler(this.btnVente_Click);
            // 
            // btnStock
            // 
            this.btnStock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStock.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStock.Image = ((System.Drawing.Image)(resources.GetObject("btnStock.Image")));
            this.btnStock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStock.Location = new System.Drawing.Point(0, 148);
            this.btnStock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStock.Name = "btnStock";
            this.btnStock.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.btnStock.Size = new System.Drawing.Size(329, 74);
            this.btnStock.TabIndex = 7;
            this.btnStock.Text = "Stocks";
            this.btnStock.UseVisualStyleBackColor = true;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // btnMedicaments
            // 
            this.btnMedicaments.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMedicaments.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMedicaments.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMedicaments.Image = ((System.Drawing.Image)(resources.GetObject("btnMedicaments.Image")));
            this.btnMedicaments.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMedicaments.Location = new System.Drawing.Point(0, 222);
            this.btnMedicaments.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMedicaments.Name = "btnMedicaments";
            this.btnMedicaments.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.btnMedicaments.Size = new System.Drawing.Size(329, 74);
            this.btnMedicaments.TabIndex = 0;
            this.btnMedicaments.Text = "Médicaments";
            this.btnMedicaments.UseVisualStyleBackColor = true;
            this.btnMedicaments.Click += new System.EventHandler(this.btnMedicaments_Click);
            // 
            // btnFournisseur
            // 
            this.btnFournisseur.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFournisseur.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFournisseur.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFournisseur.Image = ((System.Drawing.Image)(resources.GetObject("btnFournisseur.Image")));
            this.btnFournisseur.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFournisseur.Location = new System.Drawing.Point(0, 296);
            this.btnFournisseur.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFournisseur.Name = "btnFournisseur";
            this.btnFournisseur.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.btnFournisseur.Size = new System.Drawing.Size(329, 74);
            this.btnFournisseur.TabIndex = 8;
            this.btnFournisseur.Text = "Fournisseurs";
            this.btnFournisseur.UseVisualStyleBackColor = true;
            this.btnFournisseur.Click += new System.EventHandler(this.btnFournisseur_Click);
            // 
            // btnClient
            // 
            this.btnClient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClient.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClient.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClient.Image = ((System.Drawing.Image)(resources.GetObject("btnClient.Image")));
            this.btnClient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClient.Location = new System.Drawing.Point(0, 370);
            this.btnClient.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClient.Name = "btnClient";
            this.btnClient.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.btnClient.Size = new System.Drawing.Size(329, 74);
            this.btnClient.TabIndex = 9;
            this.btnClient.Text = "Clients";
            this.btnClient.UseVisualStyleBackColor = true;
            this.btnClient.Click += new System.EventHandler(this.btnClient_Click);
            // 
            // btnUtilisateur
            // 
            this.btnUtilisateur.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUtilisateur.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUtilisateur.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUtilisateur.Image = ((System.Drawing.Image)(resources.GetObject("btnUtilisateur.Image")));
            this.btnUtilisateur.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUtilisateur.Location = new System.Drawing.Point(0, 444);
            this.btnUtilisateur.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUtilisateur.Name = "btnUtilisateur";
            this.btnUtilisateur.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.btnUtilisateur.Size = new System.Drawing.Size(329, 74);
            this.btnUtilisateur.TabIndex = 10;
            this.btnUtilisateur.Text = "Utilisateurs";
            this.btnUtilisateur.UseVisualStyleBackColor = true;
            this.btnUtilisateur.Click += new System.EventHandler(this.btnUtilisateur_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.btnUtilisateur);
            this.panel2.Controls.Add(this.btnClient);
            this.panel2.Controls.Add(this.btnFournisseur);
            this.panel2.Controls.Add(this.btnMedicaments);
            this.panel2.Controls.Add(this.btnStock);
            this.panel2.Controls.Add(this.btnVente);
            this.panel2.Controls.Add(this.btnAccueil);
            this.panel2.Location = new System.Drawing.Point(0, 167);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(329, 788);
            this.panel2.TabIndex = 4;
            // 
            // sideMenu
            // 
            this.sideMenu.BackColor = System.Drawing.Color.White;
            this.sideMenu.Controls.Add(this.panel3);
            this.sideMenu.Controls.Add(this.panel1);
            this.sideMenu.Controls.Add(this.panel2);
            this.sideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideMenu.Location = new System.Drawing.Point(0, 0);
            this.sideMenu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sideMenu.Name = "sideMenu";
            this.sideMenu.Size = new System.Drawing.Size(333, 1055);
            this.sideMenu.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnLogout);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 932);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(333, 123);
            this.panel3.TabIndex = 0;
            // 
            // panelAccueil
            // 
            this.panelAccueil.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAccueil.Location = new System.Drawing.Point(333, 0);
            this.panelAccueil.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelAccueil.Name = "panelAccueil";
            this.panelAccueil.Size = new System.Drawing.Size(1587, 1055);
            this.panelAccueil.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1055);
            this.Controls.Add(this.panelAccueil);
            this.Controls.Add(this.sideMenu);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Pharmacie";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.sideMenu.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnToggleMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUtilisateurConnecte;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnUtilisateur;
        private System.Windows.Forms.Button btnClient;
        private System.Windows.Forms.Button btnFournisseur;
        private System.Windows.Forms.Button btnMedicaments;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btnVente;
        private System.Windows.Forms.Button btnAccueil;
        private System.Windows.Forms.Panel sideMenu;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelAccueil;
    }
}

