using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Paczos.MemoryGame.DAO.DO;

namespace Paczos.MemoryGame.UI.Views
{
    public partial class Images : Page
    {
        public Images()
        {
            InitializeComponent();
            LoadImagesList();
        }

        private void LoadImagesList()
        {
            ImagesList.Items.Clear();
            int imageCount = 0;
            foreach (var id in App.ImageManager.GetAllImageIds())
            {
                var imageData = App.ImageManager.GetImageById(id);
                if (imageData != null)
                {
                    var image = new BitmapImage();
                    using (var mem = new MemoryStream(imageData))
                    {
                        mem.Position = 0;
                        image.BeginInit();
                        image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                        image.CacheOption = BitmapCacheOption.OnLoad;
                        image.UriSource = null;
                        image.StreamSource = mem;
                        image.EndInit();
                    }
                    image.Freeze();
                    ImagesList.Items.Add(new Image { Source = image, Width = 100, Height = 100, Margin = new Thickness(5) });
                    imageCount++;
                }
            }
            MessageBox.Show($"Liczba zdjęć w pamięci: {imageCount}", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void LoadImages_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "Image files (*.png)|*.png"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                foreach (var fileName in openFileDialog.FileNames)
                {
                    var imageData = File.ReadAllBytes(fileName);
                    var id = Path.GetFileNameWithoutExtension(fileName);
                    App.ImageManager.AddImage(id, imageData);
                }
                LoadImagesList();
            }
        }

        private void ReturnToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            // Assuming MainMenu is another Page in your application
            NavigationService.Navigate(new MainMenu());
        }
    }
}