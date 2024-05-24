using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Paczos.MemoryGame.DAO.DO;
using System.Windows.Media;
using Paczos.MemoryGame.DAO.Entities;
namespace Paczos.MemoryGame.UI.Views
{
    public partial class Images : Page
    {
        private List<ImageItem> _images;
        private ImageItem _selectedImage;

        public Images()
        {
            InitializeComponent();
            _images = new List<ImageItem>();
            LoadImages();
        }

        private void LoadImages()
        {
            var imageInfos = App.ImageManager.GetAllImagesWithNames();
            _images.Clear();
            int loadedImagesCount = 0;

            foreach (var imageInfo in imageInfos)
            {
                var imageData = App.ImageManager.GetImageById(imageInfo.Id);
                if (imageData != null)
                {
                    var bitmapImage = new BitmapImage();
                    using (var stream = new MemoryStream(imageData))
                    {
                        bitmapImage.BeginInit();
                        bitmapImage.StreamSource = stream;
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.EndInit();
                    }
                    _images.Add(new ImageItem { Name = imageInfo.Name, Image = bitmapImage });
                    loadedImagesCount++;
                }
            }

            RefreshImagesList();
            MessageBox.Show($"Załadowano {loadedImagesCount} obrazów.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void RefreshImagesList()
        {
            ImagesList.ItemsSource = null;
            ImagesList.ItemsSource = _images;
        }

        private void LoadImages_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Pliki graficzne (*.png;*.jpg;*.jpeg;*.bmp;*.gif)|*.png;*.jpg;*.jpeg;*.bmp;*.gif",
                Multiselect = true
            };

            if (openFileDialog.ShowDialog() == true)
            {
                foreach (var fileName in openFileDialog.FileNames)
                {
                    byte[] imageData = File.ReadAllBytes(fileName);
                    string id = Path.GetFileNameWithoutExtension(fileName);
                    string name = Path.GetFileName(fileName);
                    App.ImageManager.AddImage(id, name, imageData);
                }
                LoadImages();
            }
        }

        private void ReturnToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenu());
        }

        private void SendToDatabase_Click(object sender, RoutedEventArgs e)
        {
            var imagesToSend = new List<Paczos.MemoryGame.INTERFACES.Entities.IImage>();
            foreach (var imageItem in _images)
            {
                var imageData = ConvertBitmapImageToByteArray(imageItem.Image);
                imagesToSend.Add(new Paczos.MemoryGame.DAO.Entities.Image 
                { 
                    Id = imageItem.Name, 
                    Name = imageItem.Name, 
                    ImageData = imageData 
                });
            }
            App.ImageManager.SendImagesToDatabase(imagesToSend);
        }

        private byte[] ConvertBitmapImageToByteArray(BitmapImage bitmapImage)
        {
            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }

        private void FetchFromDatabase_Click(object sender, RoutedEventArgs e)
        {
            var imagesFromDb = App.ImageManager.FetchImagesFromDatabase();
            _images.Clear();

            foreach (var image in imagesFromDb)
            {
                var bitmapImage = new BitmapImage();
                using (var stream = new MemoryStream(image.ImageData))
                {
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = stream;
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();
                }
                _images.Add(new ImageItem { Name = image.Name, Image = bitmapImage });
            }

            LoadImages();
        }

        private void ClearData_Click(object sender, RoutedEventArgs e)
        {
            _images.Clear();
            RefreshImagesList();
        }

        private void RemoveImage_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedImage != null)
            {
                var imageInfo = App.ImageManager.GetAllImagesWithNames().Find(info => info.Name == _selectedImage.Name);
                if (imageInfo != null)
                {
                    App.ImageManager.RemoveImage(imageInfo.Id);
                    LoadImages();
                }
            }
        }

        private void ImagesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedImage = ImagesList.SelectedItem as ImageItem;
            RemoveImageButton.IsEnabled = _selectedImage != null;
        }
    }

    public class ImageItem
    {
        public string Name { get; set; }
        public BitmapImage Image { get; set; }
    }
}