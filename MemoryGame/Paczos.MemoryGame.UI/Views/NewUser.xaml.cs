using System;
using System.Windows;
using System.Windows.Controls;
using Paczos.MemoryGame.DAO.Entities;

namespace Paczos.MemoryGame.UI.Views
{
    /// <summary>
    /// Logika interakcji dla klasy NewUser.xaml
    /// </summary>
    public partial class NewUser : Page
    {
        public NewUser()
        {
            InitializeComponent();
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NickTextBox.Text) ||
                string.IsNullOrWhiteSpace(FirstNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(LastNameTextBox.Text))
            {
                MessageBox.Show("Wszystkie pola muszą być wypełnione.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var newUser = new User
            {
                Nick = NickTextBox.Text,
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                CreationDate = DateTime.Now
            };

            App.UserRepository.Create(newUser);
            NavigationService.Navigate(new Users());
        }

        private void BackToUsersButton_Click(object sender, RoutedEventArgs e)
        {
            // Logika powrotu do listy użytkowników
            NavigationService.GoBack();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            AddUserButton.IsEnabled = !string.IsNullOrWhiteSpace(NickTextBox.Text) &&
                                      !string.IsNullOrWhiteSpace(FirstNameTextBox.Text) &&
                                      !string.IsNullOrWhiteSpace(LastNameTextBox.Text);
        }
    }
}
