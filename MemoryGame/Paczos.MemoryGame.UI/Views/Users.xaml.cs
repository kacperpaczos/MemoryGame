using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Paczos.MemoryGame.DAO.DO;
using Paczos.MemoryGame.DAO.Entities;

namespace Paczos.MemoryGame.UI.Views
{
    public partial class Users : Page
    {
        public Users()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            UsersListView.ItemsSource = App.UserRepository.ReadAll();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Logika powrotu do menu głównego
            NavigationService.Navigate(new MainMenu());
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsersListView.SelectedItem is User selectedUser)
            {
                App.UserRepository.Delete(selectedUser.Id);
                App.FirstUser = null;
                LoadUsers(); // Odśwież listę użytkowników
            }
            else
            {
                MessageBox.Show("Proszę wybrać użytkownika do usunięcia.");
            }
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsersListView.SelectedItem is User selectedUser)
            {
                NavigationService.Navigate(new Profile(selectedUser.Id));
            }
            else
            {
                MessageBox.Show("Proszę wybrać użytkownika, aby zobaczyć profil.");
            }
        }

        private void UsersListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool isItemSelected = UsersListView.SelectedItem != null;
            DeleteUserButton.IsEnabled = isItemSelected;
            ProfileButton.IsEnabled = isItemSelected;
            SetFirstUserButton.IsEnabled = isItemSelected;
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewUser());
        }

        private void SetFirstUserButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = UsersListView.SelectedItem as User; // Zakładając, że typem elementów jest User
            if (selectedUser != null)
            {
                App.FirstUser = selectedUser;
                MessageBox.Show($"Użytkownik {selectedUser.Nick} został ustawiony jako pierwszy użytkownik.");
            }
        }
    }
}