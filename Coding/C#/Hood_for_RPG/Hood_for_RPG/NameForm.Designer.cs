namespace Hood_for_RPG
{
    partial class NameForm
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
            this.btDone = new System.Windows.Forms.Button();
            this.tbCharacterName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose your character\'s name. (it WILL affect their stats)";
            // 
            // btDone
            // 
            this.btDone.Location = new System.Drawing.Point(136, 151);
            this.btDone.Name = "btDone";
            this.btDone.Size = new System.Drawing.Size(75, 23);
            this.btDone.TabIndex = 1;
            this.btDone.Text = "Done";
            this.btDone.UseVisualStyleBackColor = true;
            this.btDone.Click += new System.EventHandler(this.btDone_Click);
            // 
            // tbCharacterName
            // 
            this.tbCharacterName.Location = new System.Drawing.Point(124, 94);
            this.tbCharacterName.Name = "tbCharacterName";
            this.tbCharacterName.Size = new System.Drawing.Size(100, 23);
            this.tbCharacterName.TabIndex = 2;
            // 
            // NameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 203);
            this.Controls.Add(this.tbCharacterName);
            this.Controls.Add(this.btDone);
            this.Controls.Add(this.label1);
            this.Name = "NameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NameForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btDone;
        private System.Windows.Forms.TextBox tbCharacterName;
    }
}