namespace Pharmacie
{
    partial class ModifierMedicament
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
            this.txtNom = new System.Windows.Forms.TextBox();
            this.btnModifier = new System.Windows.Forms.Button();
            this.labNom = new System.Windows.Forms.Label();
            this.labDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrix = new System.Windows.Forms.TextBox();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNom
            // 
            this.txtNom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNom.Location = new System.Drawing.Point(36, 143);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(203, 30);
            this.txtNom.TabIndex = 0;
           
            // 
            // btnModifier
            // 
            this.btnModifier.Location = new System.Drawing.Point(36, 410);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(75, 23);
            this.btnModifier.TabIndex = 3;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // labNom
            // 
            this.labNom.AutoSize = true;
            this.labNom.Location = new System.Drawing.Point(33, 118);
            this.labNom.Name = "labNom";
            this.labNom.Size = new System.Drawing.Size(38, 30);
            this.labNom.TabIndex = 4;
            this.labNom.Text = "Nom : ";
            // 
            // labDescription
            // 
            this.labDescription.AutoSize = true;
            this.labDescription.Location = new System.Drawing.Point(33, 194);
            this.labDescription.Name = "labDescription";
            this.labDescription.Size = new System.Drawing.Size(69, 13);
            this.labDescription.TabIndex = 5;
            this.labDescription.Text = "Description : ";
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescription.Location = new System.Drawing.Point(36, 223);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(203, 13);
            this.txtDescription.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 290);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Prix (Ar) : ";
            // 
            // txtPrix
            // 
            this.txtPrix.Location = new System.Drawing.Point(36, 315);
            this.txtPrix.Name = "txtPrix";
            this.txtPrix.Size = new System.Drawing.Size(203, 20);
            this.txtPrix.TabIndex = 8;
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(164, 410);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(75, 23);
            this.btnAnnuler.TabIndex = 17;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(52, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(175, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "FORMULAIRE DE MODIFICATION";
            // 
            // ModifierMedicament
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 459);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.txtPrix);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.labDescription);
            this.Controls.Add(this.labNom);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.txtNom);
            this.Name = "ModifierMedicament";
            this.Text = "ModifierMedicament";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Label labNom;
        private System.Windows.Forms.Label labDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrix;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Label label7;
    }
}