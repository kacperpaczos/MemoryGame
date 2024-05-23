using System.Windows;
using System.Windows.Controls;
using Paczos.MemoryGame.DAO.DO;
using Paczos.MemoryGame.DAO.Entities;

namespace Paczos.MemoryGame.UI.Views
{
    public partial class Profile : Page
    {
        private User _currentUser;

        public Profile(int userId)
        {
            InitializeComponent();
            LoadUserProfile(userId);
        }

        private void LoadUserProfile(int userId)
        {
            _currentUser = (User)App.UserRepository.Read(userId);
            if (_currentUser != null)
            {
                NickTextBox.Text = _currentUser.Nick;
                FirstNameTextBox.Text = _currentUser.FirstName;
                LastNameTextBox.Text = _currentUser.LastName;
            }
            else
            {
                MessageBox.Show("Nie znaleziono użytkownika.");
            }
        }

        private void SaveUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentUser != null)
            {
                _currentUser.Nick = NickTextBox.Text;
                _currentUser.FirstName = FirstNameTextBox.Text;
                _currentUser.LastName = LastNameTextBox.Text;

                App.UserRepository.Update(_currentUser);
                NavigationService.Navigate(new Users());
                //MessageBox.Show("Zapisano zmiany.");
            }
            else
            {
                MessageBox.Show("Błąd podczas zapisywania zmian.");
            }
        }
    }
}