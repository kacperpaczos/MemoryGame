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
            this.addUserButton = new System.Windows.Forms.Button();
            this.setMainUser = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.EditUserButton = new System.Windows.Forms.Button();
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
            this.usersList.Size = new System.Drawing.Size(157, 348);
            this.usersList.TabIndex = 1;
            this.usersList.UseCompatibleStateImageBehavior = false;
            // 
            // addUserButton
            // 
            this.addUserButton.Location = new System.Drawing.Point(24, 404);
            this.addUserButton.Name = "addUserButton";
            this.addUserButton.Size = new System.Drawing.Size(133, 23);
            this.addUserButton.TabIndex = 2;
            this.addUserButton.Text = "Dodaj Użytkownika";
            this.addUserButton.UseVisualStyleBackColor = true;
            this.addUserButton.Click += new System.EventHandler(this.addUserButton_Click);
            // 
            // setMainUser
            // 
            this.setMainUser.Enabled = false;
            this.setMainUser.Location = new System.Drawing.Point(191, 12);
            this.setMainUser.Name = "setMainUser";
            this.setMainUser.Size = new System.Drawing.Size(141, 23);
            this.setMainUser.TabIndex = 3;
            this.setMainUser.Text = "Wybierz Gracza";
            this.setMainUser.UseVisualStyleBackColor = true;
            this.setMainUser.Click += new System.EventHandler(this.setMainUser_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Enabled = false;
            this.deleteButton.Location = new System.Drawing.Point(191, 41);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(141, 23);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Usuń Gracza";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // EditUserButton
            // 
            this.EditUserButton.Enabled = false;
            this.EditUserButton.Location = new System.Drawing.Point(191, 70);
            this.EditUserButton.Name = "EditUserButton";
            this.EditUserButton.Size = new System.Drawing.Size(141, 23);
            this.EditUserButton.TabIndex = 5;
            this.EditUserButton.Text = "edytuj";
            this.EditUserButton.UseVisualStyleBackColor = true;
            this.EditUserButton.UseWaitCursor = true;
            this.EditUserButton.Click += new System.EventHandler(this.EditUserButton_Click);
            // 
            // UsersPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 450);
            this.Controls.Add(this.EditUserButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.setMainUser);
            this.Controls.Add(this.addUserButton);
            this.Controls.Add(this.usersList);
            this.Controls.Add(this.backToMenu);
            this.Name = "UsersPanel";
            this.Text = "UsersPanel";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button backToMenu;
        private System.Windows.Forms.ListView usersList;
        private System.Windows.Forms.Button addUserButton;
        private System.Windows.Forms.Button setMainUser;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button EditUserButton;
    }
}