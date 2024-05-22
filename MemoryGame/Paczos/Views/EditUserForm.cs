using Paczos.Interfaces;
using Paczos.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Paczos.Views
{
    public partial class EditUserForm : Form
    {
        private IMemoryGameUser _user;

        public EditUserForm()
        {
            _user = MemoryGameUsersManager.Instance.GetMainUser();
            InitializeComponent();
            SetupForm();
            LoadUserData();
        }

        private void SetupForm()
        {
            TextBox nicknameTextBox = new TextBox { Name = "nicknameTextBox", Location = new Point(10, 10), Size = new Size(200, 20) };
            TextBox firstNameTextBox = new TextBox { Name = "firstNameTextBox", Location = new Point(10, 40), Size = new Size(200, 20) };
            TextBox lastNameTextBox = new TextBox { Name = "lastNameTextBox", Location = new Point(10, 70), Size = new Size(200, 20) };
            TextBox keyDataTextBox = new TextBox { Name = "keyDataTextBox", Location = new Point(10, 100), Size = new Size(200, 20) };

            Button saveButton = new Button { Text = "Zapisz", Location = new Point(10, 130) };
            saveButton.Click += SaveButton_Click;

            Controls.Add(nicknameTextBox);
            Controls.Add(firstNameTextBox);
            Controls.Add(lastNameTextBox);
            Controls.Add(keyDataTextBox);
            Controls.Add(saveButton);
        }

        private void LoadUserData()
        {
            if (_user != null)
            {
                ((TextBox)Controls["nicknameTextBox"]).Text = _user.GetNickname();
                ((TextBox)Controls["firstNameTextBox"]).Text = _user.GetFirstName();
                ((TextBox)Controls["lastNameTextBox"]).Text = _user.GetLastName();
                ((TextBox)Controls["keyDataTextBox"]).Text = _user.GetKeyData();
            }
            else
            {
                MessageBox.Show("Nie ustawiono głównego użytkownika.");
                Close(); // Zamknij formularz, jeśli nie ma głównego użytkownika
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (_user != null)
            {
                _user.SetNickname(((TextBox)Controls["nicknameTextBox"]).Text);
                _user.SetFirstName(((TextBox)Controls["firstNameTextBox"]).Text);
                _user.SetLastName(((TextBox)Controls["lastNameTextBox"]).Text);
                _user.SetKeyData(((TextBox)Controls["keyDataTextBox"]).Text);

                MemoryGameUsersManager.Instance.UpdateUser((MemoryGameUser)_user);
                MessageBox.Show("Zaktualizowano użytkownika: " + _user.GetNickname());
                Program.userPanel.ReloadUsersList();
                Close();
            }
        }
    }
}