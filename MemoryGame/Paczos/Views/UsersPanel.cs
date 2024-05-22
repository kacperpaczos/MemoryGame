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
            List<Paczos.Interfaces.IMemoryGameUser> users = MemoryGameUsersManager.Instance.GetUsers();

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
                var user = MemoryGameUsersManager.Instance.GetUsers().FirstOrDefault(u => u.GetNickname() == selectedUserNickname);

                if (user != null)
                {
                    // Jawne rzutowanie z IMemoryGameUser na MemoryGameUser
                    MemoryGameUser castedUser = user as MemoryGameUser;
                    if (castedUser != null)
                    {
                        MessageBox.Show($"Wybrano użytkownika: {castedUser.GetNickname()}, Szczegóły: {castedUser.GetFirstName()}");
                    }
                    else
                    {
                        MessageBox.Show("Nie można przekonwertować wybranego użytkownika.");
                    }
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
                var userToDelete = MemoryGameUsersManager.Instance.GetUsers().FirstOrDefault(u => u.GetNickname() == selectedUserNickname);
                if (userToDelete != null)
                {
                    MemoryGameUser castedUserToDelete = userToDelete as MemoryGameUser;
                    if (castedUserToDelete != null)
                    {
                        MemoryGameUsersManager.Instance.GetUsers().Remove(castedUserToDelete);
                        MemoryGameUsersManager.Instance.SaveUsers();
                        ReloadUsersList();
                        MessageBox.Show("Usunięto użytkownika: " + castedUserToDelete.GetNickname());
                    }
                    else
                    {
                        MessageBox.Show("Nie można przekonwertować wybranego użytkownika do usunięcia.");
                    }
                }
            }
        }

        private void setMainUser_Click(object sender, EventArgs e)
        {
            if (usersList.SelectedItems.Count > 0)
            {
                string selectedUserNickname = usersList.SelectedItems[0].Text;
                var user = MemoryGameUsersManager.Instance.GetUsers().FirstOrDefault(u => u.GetNickname() == selectedUserNickname);
                if (user != null)
                {
                    MemoryGameUser castedUser = user as MemoryGameUser;
                    if (castedUser != null)
                    {
                        MemoryGameUsersManager.Instance.SetMainUser(castedUser);
                        MessageBox.Show("Ustawiono głównego gracza: " + castedUser.GetNickname());
                    }
                    else
                    {
                        MessageBox.Show("Nie można przekonwertować wybranego użytkownika na głównego gracza.");
                    }
                }
                else
                {
                    MessageBox.Show("Nie znaleziono użytkownika.");
                }
            }
            else
            {
                MessageBox.Show("Nie zaznaczono żadnego użytkownika.");
            }
        }
    }
}
