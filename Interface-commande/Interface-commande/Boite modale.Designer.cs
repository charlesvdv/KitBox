﻿namespace Interface_commande
{
    partial class Boite_modale
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
            this.label1 = new System.Windows.Forms.Label();
            this.Reference = new System.Windows.Forms.TextBox();
            this.OK = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Quantite = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Référence:";
            // 
            // Reference
            // 
            this.Reference.Location = new System.Drawing.Point(81, 62);
            this.Reference.Name = "Reference";
            this.Reference.Size = new System.Drawing.Size(75, 20);
            this.Reference.TabIndex = 1;
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(356, 61);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(36, 20);
            this.OK.TabIndex = 4;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(312, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Spécifier la référence de l\'élément ainsi que la quantité souhaitée";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Quantité:";
            // 
            // Quantite
            // 
            this.Quantite.Location = new System.Drawing.Point(233, 62);
            this.Quantite.Name = "Quantite";
            this.Quantite.Size = new System.Drawing.Size(100, 20);
            this.Quantite.TabIndex = 7;
            // 
            // Boite_modale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 108);
            this.Controls.Add(this.Quantite);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.Reference);
            this.Controls.Add(this.label1);
            this.Name = "Boite_modale";
            this.Text = "Ajout d\'un élément";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Reference;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Quantite;
    }
}