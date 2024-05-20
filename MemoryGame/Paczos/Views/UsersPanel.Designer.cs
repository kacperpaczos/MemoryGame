namespace Paczos.Views
{
    partial class UsersPanel
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
            this.backToMenu = new System.Windows.Forms.Button();
            this.usersList = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // backToMenu
            // 
            this.backToMenu.Location = new System.Drawing.Point(12, 12);
            this.backToMenu.Name = "backToMenu";
            this.backToMenu.Size = new System.Drawing.Size(157, 23);
            this.backToMenu.TabIndex = 0;
            this.backToMenu.Text = "Menu główne";
            this.backToMenu.UseVisualStyleBackColor = true;
            this.backToMenu.Click += new System.EventHandler(this.backToMenu_Click);
            // 
            // usersList
            // 
            this.usersList.HideSelection = false;
            this.usersList.Location = new System.Drawing.Point(12, 41);
            this.usersList.Name = "usersList";
            this.usersList.Size = new System.Drawing.Size(157, 397);
            this.usersList.TabIndex = 1;
            this.usersList.UseCompatibleStateImageBehavior = false;
            // 
            // UsersPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.usersList);
            this.Controls.Add(this.backToMenu);
            this.Name = "UsersPanel";
            this.Text = "UsersPanel";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button backToMenu;
        private System.Windows.Forms.ListView usersList;
    }
}