using Paczos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paczos.Views
{
    public partial class UsersPanel : Form
    {
        public UsersPanel()
        {
            InitializeComponent();
            usersList.SelectedIndexChanged += UsersList_SelectedIndexChanged;
            FillUsersList();
        }

        private void backToMenu_Click(object sender, EventArgs e)
        {
            Program.ShowMainMenu();
        }
        private void FillUsersList()
        {
            // Pobranie użytkowników z MemoryGameUsersManager
            List<MemoryGameUser> users = MemoryGameUsersManager.Instance.GetUsers();

            // Czyszczenie istniejących elementów
            usersList.Items.Clear();

            // Dodawanie użytkowników do ListView
            foreach (var user in users)
            {
                usersList.Items.Add(user.GetNickname()); // Używanie metody GetNickname()
            }
        }

        public void ReloadUsersList(){
            FillUsersList();
        }

        private void UsersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Sprawdzenie, czy jakiś element jest zaznaczony
            bool isItemSelected = usersList.SelectedItems.Count > 0;

            // Włączenie lub wyłączenie przycisków w zależności od tego, czy element jest zaznaczony
            deleteButton.Enabled = isItemSelected;
            setMainUser.Enabled = isItemSelected;

            // Jeśli żaden element nie jest zaznaczony, wyświetl komunikat
            if (!isItemSelected)
            {
                MessageBox.Show("Odznaczono wszystkie elementy.");
            }
            else
            {
                // Wyświetlenie informacji o zaznaczonym użytkowniku
                string selectedUserNickname = usersList.SelectedItems[0].Text;
                MemoryGameUser user = MemoryGameUsersManager.Instance.GetUsers().FirstOrDefault(u => u.GetNickname() == selectedUserNickname);

                if (user != null)
                {
                    MessageBox.Show($"Wybrano użytkownika: {user.GetNickname()}, Szczegóły: {user.GetFirstName()}");
                }
            }
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            AddUserForm addUserForm = new AddUserForm();
            addUserForm.ShowDialog();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (usersList.SelectedItems.Count > 0)
            {
                string selectedUserNickname = usersList.SelectedItems[0].Text;
                MemoryGameUser userToDelete = MemoryGameUsersManager.Instance.GetUsers().FirstOrDefault(u => u.GetNickname() == selectedUserNickname);
                if (userToDelete != null)
                {
                    MemoryGameUsersManager.Instance.GetUsers().Remove(userToDelete);
                    MemoryGameUsersManager.Instance.SaveUsers();
                    ReloadUsersList();
                    MessageBox.Show("Usunięto użytkownika: " + userToDelete.GetNickname());
                }
            }
        }

        private void setMainUser_Click(object sender, EventArgs e)
        {
            if (usersList.SelectedItems.Count > 0)
            {
                string selectedUserNickname = usersList.SelectedItems[0].Text;
                MemoryGameUser mainUser = MemoryGameUsersManager.Instance.GetUsers().FirstOrDefault(u => u.GetNickname() == selectedUserNickname);
                if (mainUser != null)
                {
                    MemoryGameUsersManager.Instance.SetMainUser(mainUser);
                    MessageBox.Show("Ustawiono głównego gracza: " + mainUser.GetNickname());
                }
            }
        }
    }
}
