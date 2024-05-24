using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Paczos.MemoryGame.UI.Views
{
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
            CheckIfUserSelected();
        }

        private void CheckIfUserSelected()
        {
            // Sprawdź, czy użytkownik jest wybrany
            bool isUserSelected = IsUserSelected();

            // Włącz lub wyłącz przycisk "Graj" w zależności od tego, czy użytkownik jest wybrany
            PlayGameButton.IsEnabled = isUserSelected;
        }

        private void MainMenu_Loaded(object sender, RoutedEventArgs e)
        {
            CheckIfUserSelected();
        }

        private bool IsUserSelected()
        {
            // Sprawdź, czy FirstUser z App.xaml.cs nie jest null
            return App.FirstUser != null;
        }

        private void PlayGame_Click(object sender, RoutedEventArgs e)
        {
            // Przejdź do strony gry
            NavigationService.Navigate(new Game());
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            // Przejdź do strony użytkowników
            NavigationService.Navigate(new Users());
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            // Zamknij aplikację
            Application.Current.Shutdown();
        }

        private void ImageManager_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Images());
        }
    }
}