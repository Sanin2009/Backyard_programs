namespace Hood_for_RPG
{
    partial class ClassForm
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
            this.btWarrior = new System.Windows.Forms.Button();
            this.btSoldier = new System.Windows.Forms.Button();
            this.btArcher = new System.Windows.Forms.Button();
            this.btMercenary = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(144, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose your class";
            // 
            // btWarrior
            // 
            this.btWarrior.Location = new System.Drawing.Point(61, 87);
            this.btWarrior.Name = "btWarrior";
            this.btWarrior.Size = new System.Drawing.Size(101, 37);
            this.btWarrior.TabIndex = 1;
            this.btWarrior.Text = "Warrior";
            this.btWarrior.UseVisualStyleBackColor = true;
            this.btWarrior.Click += new System.EventHandler(this.btWarrior_Click);
            // 
            // btSoldier
            // 
            this.btSoldier.Location = new System.Drawing.Point(323, 87);
            this.btSoldier.Name = "btSoldier";
            this.btSoldier.Size = new System.Drawing.Size(101, 37);
            this.btSoldier.TabIndex = 2;
            this.btSoldier.Text = "Soldier";
            this.btSoldier.UseVisualStyleBackColor = true;
            this.btSoldier.Click += new System.EventHandler(this.btSoldier_Click);
            // 
            // btArcher
            // 
            this.btArcher.Location = new System.Drawing.Point(61, 184);
            this.btArcher.Name = "btArcher";
            this.btArcher.Size = new System.Drawing.Size(101, 37);
            this.btArcher.TabIndex = 3;
            this.btArcher.Text = "Archer";
            this.btArcher.UseVisualStyleBackColor = true;
            this.btArcher.Click += new System.EventHandler(this.btArcher_Click);
            // 
            // btMercenary
            // 
            this.btMercenary.Location = new System.Drawing.Point(323, 184);
            this.btMercenary.Name = "btMercenary";
            this.btMercenary.Size = new System.Drawing.Size(101, 37);
            this.btMercenary.TabIndex = 4;
            this.btMercenary.Text = "Mercenary";
            this.btMercenary.UseVisualStyleBackColor = true;
            this.btMercenary.Click += new System.EventHandler(this.btMercenary_Click);
            // 
            // ClassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 260);
            this.Controls.Add(this.btMercenary);
            this.Controls.Add(this.btArcher);
            this.Controls.Add(this.btSoldier);
            this.Controls.Add(this.btWarrior);
            this.Controls.Add(this.label1);
            this.Name = "ClassForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClassForm";
            this.Load += new System.EventHandler(this.ClassForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btWarrior;
        private System.Windows.Forms.Button btSoldier;
        private System.Windows.Forms.Button btArcher;
        private System.Windows.Forms.Button btMercenary;
    }
}