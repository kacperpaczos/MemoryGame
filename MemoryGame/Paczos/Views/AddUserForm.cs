using Paczos.Interfaces;
using Paczos.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Paczos.Views
{
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            TextBox nicknameTextBox = new TextBox { Name = "nicknameTextBox", Text = "Nickname", Location = new Point(10, 10), Size = new Size(200, 20) };
            nicknameTextBox.Enter += (sender, e) => { if (nicknameTextBox.Text == "Nickname") nicknameTextBox.Text = ""; };
            nicknameTextBox.Leave += (sender, e) => { if (string.IsNullOrWhiteSpace(nicknameTextBox.Text)) nicknameTextBox.Text = "Nickname"; };

            TextBox firstNameTextBox = new TextBox { Name = "firstNameTextBox", Text = "First Name", Location = new Point(10, 40), Size = new Size(200, 20) };
            firstNameTextBox.Enter += (sender, e) => { if (firstNameTextBox.Text == "First Name") firstNameTextBox.Text = ""; };
            firstNameTextBox.Leave += (sender, e) => { if (string.IsNullOrWhiteSpace(firstNameTextBox.Text)) firstNameTextBox.Text = "First Name"; };

            Button saveButton = new Button { Text = "Zapisz", Location = new Point(10, 70) };
            saveButton.Click += SaveButton_Click;

            Controls.Add(nicknameTextBox);
            Controls.Add(firstNameTextBox);
            Controls.Add(saveButton);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            IMemoryGameUser newUser = new MemoryGameUser(); // Zakładając, że MemoryGameUser implementuje IMemoryGameUser

            newUser.SetNickname(((TextBox)Controls["nicknameTextBox"]).Text);
            newUser.SetFirstName(((TextBox)Controls["firstNameTextBox"]).Text);
            // Ustaw inne właściwości zgodnie z potrzebami

            MemoryGameUsersManager.Instance.AddUser((MemoryGameUser)newUser);
            MessageBox.Show("Utworzono nowego użytkownika: " + newUser.GetNickname());
            Program.userPanel.ReloadUsersList();
            Close();
        }
    }
}