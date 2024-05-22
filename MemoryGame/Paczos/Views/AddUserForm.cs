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

            TextBox lastNameTextBox = new TextBox { Name = "lastNameTextBox", Text = "Last Name", Location = new Point(10, 70), Size = new Size(200, 20) };
            lastNameTextBox.Enter += (sender, e) => { if (lastNameTextBox.Text == "Last Name") lastNameTextBox.Text = ""; };
            lastNameTextBox.Leave += (sender, e) => { if (string.IsNullOrWhiteSpace(lastNameTextBox.Text)) lastNameTextBox.Text = "Last Name"; };

            TextBox keyDataTextBox = new TextBox { Name = "keyDataTextBox", Text = "Key Data", Location = new Point(10, 100), Size = new Size(200, 20) };
            keyDataTextBox.Enter += (sender, e) => { if (keyDataTextBox.Text == "Key Data") keyDataTextBox.Text = ""; };
            keyDataTextBox.Leave += (sender, e) => { if (string.IsNullOrWhiteSpace(keyDataTextBox.Text)) keyDataTextBox.Text = "Key Data"; };

            Button saveButton = new Button { Text = "Zapisz", Location = new Point(10, 130) };
            saveButton.Click += SaveButton_Click;

            Controls.Add(nicknameTextBox);
            Controls.Add(firstNameTextBox);
            Controls.Add(lastNameTextBox);
            Controls.Add(keyDataTextBox);
            Controls.Add(saveButton);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            IMemoryGameUser newUser = new MemoryGameUser(); // Zakładając, że MemoryGameUser implementuje IMemoryGameUser

            newUser.SetNickname(((TextBox)Controls["nicknameTextBox"]).Text);
            newUser.SetFirstName(((TextBox)Controls["firstNameTextBox"]).Text);
            newUser.SetLastName(((TextBox)Controls["lastNameTextBox"]).Text);
            newUser.SetKeyData(((TextBox)Controls["keyDataTextBox"]).Text);
            // Ustaw inne właściwości zgodnie z potrzebami

            MemoryGameUsersManager.Instance.AddUser((MemoryGameUser)newUser);
            MessageBox.Show("Utworzono nowego użytkownika: " + newUser.GetNickname());
            Program.userPanel.ReloadUsersList();
            Close();
        }

    }
}