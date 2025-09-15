using Pharmacie.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pharmacie
{
    public partial class MainForm : Form
    {
        private System.Windows.Forms.Timer animationTimer;
        private int targetWidth;
        private const int baseAnimationStep = 30;
        private int currentStep;
        private DateTime lastTickTime;
        private const int expandedWidth = 250;
        private const int collapsedWidth = 70;
        private const int buttonPadding = 10;

        private readonly Color menuBackColor = Color.WhiteSmoke;
        private readonly Color buttonNormalColor = Color.White;
        private readonly Color buttonHoverColor = Color.FromArgb(240, 240, 240);
        private readonly Color buttonActiveColor = Color.FromArgb(230, 230, 230);
        private readonly Color textColor = Color.FromArgb(70, 70, 70);
        private readonly Color accentColor = Color.FromArgb(0, 120, 215);
        private readonly Color borderColor = Color.FromArgb(225, 225, 225);

        private Font buttonFont = new Font("Segoe UI", 10, FontStyle.Bold);
        private Button currentActiveButton;

        public MainForm()
        {
            InitializeComponent();
            InitializeModernMenu();
        }

        private void InitializeModernMenu()
        {
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            sideMenu.BackColor = menuBackColor;
            sideMenu.Padding = new Padding(5);
            sideMenu.Width = expandedWidth;

            sideMenu.BorderStyle = BorderStyle.None;
            sideMenu.Paint += (sender, e) =>
            {
                using (var pen = new Pen(borderColor, 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, sideMenu.Width - 1, sideMenu.Height - 1);
                }
            };

            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 5;
            animationTimer.Tick += animationTimer_Tick;

            ConfigureButtons();
            SetupMenuToggleButton();

            SetActiveButton(btnAccueil);
        }

        private void SetupMenuToggleButton()
        {
            btnToggleMenu.FlatStyle = FlatStyle.Flat;
            btnToggleMenu.FlatAppearance.BorderSize = 0;
            btnToggleMenu.BackColor = menuBackColor;
            btnToggleMenu.ForeColor = textColor;
           
            btnToggleMenu.Text = "";
            btnToggleMenu.Padding = new Padding(10);
            btnToggleMenu.Cursor = Cursors.Hand;
            btnToggleMenu.Click += btnToggleMenu_Click;
        }

        private void ConfigureButtons()
        {
            var buttons = new[] { btnAccueil, btnMedicaments, btnFournisseur,
                                  btnStock, btnClient, btnUtilisateur, btnVente, btnLogout };

            foreach (Button btn in buttons)
            {
                

                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = buttonNormalColor;
                btn.ForeColor = textColor;
                btn.Font = buttonFont;
            

                btn.Height = 55;
                btn.Cursor = Cursors.Hand;

       

                btn.MouseEnter += (s, e) =>
                {
                    if (btn != currentActiveButton)
                    {
                        btn.BackColor = buttonHoverColor;
                        btn.ForeColor = accentColor;
                    }
                };

                btn.MouseLeave += (s, e) =>
                {
                    if (btn != currentActiveButton)
                    {
                        btn.BackColor = buttonNormalColor;
                        btn.ForeColor = textColor;
                    }
                };

                btn.MouseDown += (s, e) => btn.BackColor = buttonActiveColor;
                btn.MouseUp += (s, e) =>
                {
                    if (btn != currentActiveButton)
                        btn.BackColor = buttonHoverColor;
                };
            }
        }

        private void SetActiveButton(Button activeButton)
        {
            if (currentActiveButton != null)
            {
                currentActiveButton.BackColor = buttonNormalColor;
                currentActiveButton.ForeColor = textColor;
            }

            currentActiveButton = activeButton;
            currentActiveButton.BackColor = accentColor;
            currentActiveButton.ForeColor = Color.White;
        }

        private void LoadFormInPanel(Form form)
        {
            panelAccueil.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelAccueil.Controls.Add(form);
            form.Show();
        }

        private void btnToggleMenu_Click(object sender, EventArgs e) => ToggleMenu();

        private void ToggleMenu()
        {
            if (sideMenu.Width > collapsedWidth + 30)
            {
                targetWidth = collapsedWidth;
                currentStep = -baseAnimationStep;
            }
            else
            {
                targetWidth = expandedWidth;
                currentStep = baseAnimationStep;
            }

            lastTickTime = DateTime.Now;
            animationTimer.Start();
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            double elapsedMs = (DateTime.Now - lastTickTime).TotalMilliseconds;
            lastTickTime = DateTime.Now;
            double adjustedStep = currentStep * (elapsedMs / animationTimer.Interval);

            if (currentStep > 0)
                sideMenu.Width = Math.Min(targetWidth, sideMenu.Width + (int)adjustedStep);
            else
                sideMenu.Width = Math.Max(targetWidth, sideMenu.Width + (int)adjustedStep);

            AnimateButtons();

            if ((currentStep > 0 && sideMenu.Width >= targetWidth) ||
                (currentStep < 0 && sideMenu.Width <= targetWidth))
            {
                sideMenu.Width = targetWidth;
                animationTimer.Stop();
                AnimateButtons(true);
            }

            if (Math.Abs(sideMenu.Width - targetWidth) < 50)
                currentStep = (int)(currentStep * 0.7);
        }

        private void AnimateButtons(bool finalState = false)
        {
            foreach (Control control in sideMenu.Controls)
            {
                if (control is Button btn && btn != btnToggleMenu)
                {
                    btn.Width = sideMenu.Width - (2 * buttonPadding);

                    if (sideMenu.Width < collapsedWidth + 30)
                    {
                        btn.Text = "";
                        btn.ImageAlign = ContentAlignment.MiddleCenter;
                        btn.Padding = new Padding(0);
                    }
                    else if (sideMenu.Width > expandedWidth - 30 || finalState)
                    {
                        btn.Text = btn.Tag?.ToString();
                        btn.ImageAlign = ContentAlignment.MiddleLeft;
                        btn.TextImageRelation = TextImageRelation.ImageBeforeText;
                        btn.Padding = new Padding(30, 0, 0, 0); // garde l'espace entre icône et texte
                    }
                }
            }
        }

       

        private void btnAccueil_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnAccueil);
            LoadFormInPanel(new Accueil());
        }

        private void btnVente_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnVente);
            LoadFormInPanel(new VenteForm());
        }

        private void btnFournisseur_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnFournisseur);
            LoadFormInPanel(new FournisseurForm());
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnStock);
            LoadFormInPanel(new StockForm());
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnClient);
            LoadFormInPanel(new ClientForm());
        }

        private void btnUtilisateur_Click(object sender, EventArgs e)
        {
            if (SessionUtilisateur.Role == "admin")
            {
                SetActiveButton(btnUtilisateur);
                LoadFormInPanel(new UtilisateurForm());
            }
            else
            {
                MessageBox.Show("Accès refusé : Seuls les administrateurs peuvent gérer les utilisateurs.",
                                "Accès non autorisé",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        private void btnMedicaments_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnMedicaments);
            LoadFormInPanel(new MedicamentForm());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnLogout);
            DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir vous déconnecter ?",
                                                "Déconnexion",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                Authentification auth = new Authentification();
                auth.Show();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            btnUtilisateur.Visible = (SessionUtilisateur.Role == "admin");
            lblUtilisateurConnecte.Text = $"{SessionUtilisateur.Nom} ({SessionUtilisateur.Role})";
            lblUtilisateurConnecte.ForeColor = textColor;
            lblUtilisateurConnecte.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblUtilisateurConnecte.TextAlign = ContentAlignment.MiddleLeft;
            lblUtilisateurConnecte.Padding = new Padding(10, 5, 0, 5);
        }
    }
}
