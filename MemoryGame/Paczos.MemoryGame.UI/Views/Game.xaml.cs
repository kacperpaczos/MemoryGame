using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.IO;
using Paczos.MemoryGame.DAO.DO;

namespace Paczos.MemoryGame.UI.Views
{
    public partial class Game : Page
    {
        private Button firstClicked, secondClicked;
        private int matchesFound = 0;
        private List<BitmapImage> images;
        private Dictionary<Button, BitmapImage> buttonImageMap;

        public Game()
        {
            InitializeComponent();
            InitializeGameBoard();
        }

        private void InitializeGameBoard()
        {
            images = new List<BitmapImage>();

            foreach (var id in App.ImageManager.GetAllImageIds())
            {
                var imageBytes = App.ImageManager.GetImageById(id);
                if (imageBytes != null)
                {
                    using (var stream = new MemoryStream(imageBytes))
                    {
                        var bitmapImage = new BitmapImage();
                        bitmapImage.BeginInit();
                        bitmapImage.StreamSource = stream;
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.EndInit();
                        images.Add(bitmapImage);
                    }
                }
            }

            buttonImageMap = new Dictionary<Button, BitmapImage>();

            var buttons = new List<Button>
            {
                Card1, Card2, Card3, Card4, Card5, Card6, Card7, Card8,
                Card9, Card10, Card11, Card12, Card13, Card14, Card15, Card16
            };

            var random = new Random();
            foreach (var image in images)
            {
                for (int i = 0; i < 2; i++) // Assuming each image should appear twice
                {
                    if (buttons.Count == 0) break;
                    var index = random.Next(buttons.Count);
                    var button = buttons[index];
                    buttons.RemoveAt(index);
                    buttonImageMap[button] = image;
                }
            }
        }

        private void Card_Click(object sender, RoutedEventArgs e)
        {
            if (firstClicked != null && secondClicked != null)
                return;

            Button clickedButton = sender as Button;

            if (clickedButton == null || !buttonImageMap.ContainsKey(clickedButton))
                return;

            clickedButton.Content = new Image { Source = buttonImageMap[clickedButton] };

            if (firstClicked == null)
            {
                firstClicked = clickedButton;
                return;
            }

            secondClicked = clickedButton;

            // Check for a match
            if (buttonImageMap[firstClicked] == buttonImageMap[secondClicked])
            {
                matchesFound++;
                firstClicked = null;
                secondClicked = null;

                if (matchesFound == 8) // Assuming 8 pairs
                {
                    MessageBox.Show("You found all matches!");
                }
            }
            else
            {
                // Hide images again after a short delay
                var timer = new System.Windows.Threading.DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
                timer.Tick += (s, args) =>
                {
                    firstClicked.Content = null;
                    secondClicked.Content = null;
                    firstClicked = null;
                    secondClicked = null;
                    timer.Stop();
                };
                timer.Start();
            }
        }
    }
}