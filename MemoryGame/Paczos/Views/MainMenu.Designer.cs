namespace Paczos.Views
{
    partial class MainMenu
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
            this.title = new System.Windows.Forms.Label();
            this.gameButton = new System.Windows.Forms.Button();
            this.userButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.title.Location = new System.Drawing.Point(323, 47);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(219, 37);
            this.title.TabIndex = 0;
            this.title.Text = "Menu Główne";
            // 
            // gameButton
            // 
            this.gameButton.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.gameButton.Enabled = false;
            this.gameButton.Location = new System.Drawing.Point(323, 95);
            this.gameButton.Name = "gameButton";
            this.gameButton.Size = new System.Drawing.Size(75, 23);
            this.gameButton.TabIndex = 1;
            this.gameButton.Text = "Graj";
            this.gameButton.UseVisualStyleBackColor = true;
            this.gameButton.Click += new System.EventHandler(this.gameButton_Click);
            // 
            // userButton
            // 
            this.userButton.Location = new System.Drawing.Point(323, 142);
            this.userButton.Name = "userButton";
            this.userButton.Size = new System.Drawing.Size(75, 23);
            this.userButton.TabIndex = 2;
            this.userButton.Text = "Użytkownicy";
            this.userButton.UseVisualStyleBackColor = true;
            this.userButton.Click += new System.EventHandler(this.userButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(338, 332);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Koniec";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.userButton);
            this.Controls.Add(this.gameButton);
            this.Controls.Add(this.title);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button gameButton;
        private System.Windows.Forms.Button userButton;
        private System.Windows.Forms.Button exitButton;
    }
}