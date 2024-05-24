using System.Collections.Generic;
using System.Linq;
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
            var users = App.UserRepository.GetAllUsers()
                .Select(user => App.UserRepository.GetUserWithGames(user.Id))
                .ToList();
            UsersListView.ItemsSource = users;
        }

        private void UsersListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedUser = (User)UsersListView.SelectedItem;
            DeleteUserButton.IsEnabled = selectedUser != null;
            ProfileButton.IsEnabled = selectedUser != null;
            SetFirstUserButton.IsEnabled = selectedUser != null;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenu());
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewUser());
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = (User)UsersListView.SelectedItem;
            if (selectedUser != null)
            {
                App.UserRepository.Delete(selectedUser.Id);
                LoadUsers();
            }
            else
            {
                MessageBox.Show("Proszę wybrać użytkownika do usunięcia.");
            }
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = (User)UsersListView.SelectedItem;
            if (selectedUser != null)
            {
                NavigationService.Navigate(new Profile(selectedUser.Id));
            }
            else
            {
                MessageBox.Show("Proszę wybrać użytkownika, aby zobaczyć profil.");
            }
        }

        private void SetFirstUserButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = (User)UsersListView.SelectedItem;
            if (selectedUser != null)
            {
                App.FirstUser = selectedUser;
                MessageBox.Show($"Użytkownik {selectedUser.Nick} został ustawiony jako pierwszy użytkownik.");
            }
        }
    }
}