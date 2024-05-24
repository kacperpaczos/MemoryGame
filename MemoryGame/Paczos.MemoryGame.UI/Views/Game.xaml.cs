using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.IO;
using Paczos.MemoryGame.DAO.DO;
using Paczos.MemoryGame.INTERFACES.Entities;
using System.Windows.Navigation;
using System.Windows.Media;
using System.Windows.Threading;

namespace Paczos.MemoryGame.UI.Views
{
    public partial class Game : Page
    {
        private Button firstClicked, secondClicked;
        private int matchesFound = 0;
        private List<BitmapImage> images;
        private Dictionary<Button, BitmapImage> buttonImageMap;
        private bool canClickCards = true;
        private DispatcherTimer gameTimer;
        private int secondsElapsed;
        private IGame currentGame;

        public Game()
        {
            InitializeComponent();
            InitializeGameBoard();
            SetPlayerData();
            StartGameTimer();
            InitializeGame();
        }

        private void InitializeGame()
        {
            if (App.FirstUser == null)
            {
                MessageBox.Show("Nie wybrano użytkownika.");
                return;
            }

            var userId = App.FirstUser.Id;
            var uniqueGameId = GenerateUniqueGameId();
            var startTime = DateTime.Now;

            currentGame = new Paczos.MemoryGame.DAO.Entities.Game
            {
                Id = uniqueGameId,
                UserId = userId,
                StartTime = startTime,
                EndTime = startTime
            };

            SetPlayerData();
            InitializeGameBoard();
            StartGameTimer();
        }

        private int GenerateUniqueGameId()
        {
            return new Random().Next(1, int.MaxValue);
        }

        private void SetPlayerData()
        {
            var player = App.FirstUser;
            PlayerDataLabel.Content = $"Gracz: {player.Nick} ({player.FirstName} {player.LastName})";
        }

        private void InitializeGameBoard()
        {
            if (!CheckImageAvailability())
            {
                canClickCards = false;
                return;
            }

            LoadImages();
            MapImagesToButtons();
        }

        private bool CheckImageAvailability()
        {
            var imageIds = App.ImageManager.GetAllImageIds();
            return imageIds != null && imageIds.Count >= 8;
        }

        private void HandleMatchFound()
        {
            matchesFound++;
            firstClicked.IsEnabled = false;
            secondClicked.IsEnabled = false;

            AddCardImageToMovesList(buttonImageMap[firstClicked]);

            firstClicked = null;
            secondClicked = null;

            if (matchesFound == 8)
            {
                MessageBox.Show("Gratulacje! Znaleziono wszystkie pary!");
                StopGameTimer();
                EndCurrentGame();
            }
        }

        private void EndCurrentGame()
        {
            if (currentGame != null)
            {
                currentGame.EndTime = DateTime.Now;
                var user = App.FirstUser;

                var gameEntity = new Paczos.MemoryGame.DAO.Entities.Game
                {
                    Id = currentGame.Id,
                    UserId = user.Id,
                    StartTime = currentGame.StartTime,
                    EndTime = currentGame.EndTime,
                };

                App.UserRepository.AddGameToUserStats(user.Id, gameEntity);

                currentGame = null;
            }
        }

        private void LoadImages()
        {
            images = new List<BitmapImage>();
            var random = new Random();
            var selectedIds = SelectRandomImageIds(random);

            foreach (var id in selectedIds)
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
        }

        private HashSet<string> SelectRandomImageIds(Random random)
        {
            var imageIds = App.ImageManager.GetAllImageIds();
            var selectedIds = new HashSet<string>();

            while (selectedIds.Count < 8)
            {
                var randomId = imageIds[random.Next(imageIds.Count)];
                selectedIds.Add(randomId);
            }

            return selectedIds;
        }

        private void MapImagesToButtons()
        {
            buttonImageMap = new Dictionary<Button, BitmapImage>();
            var buttons = GetButtonsList();
            var random = new Random();

            foreach (var image in images)
            {
                AssignImageToButtons(image, buttons, random);
            }
        }

        private List<Button> GetButtonsList()
        {
            return new List<Button>
            {
                Card1, Card2, Card3, Card4, Card5, Card6, Card7, Card8,
                Card9, Card10, Card11, Card12, Card13, Card14, Card15, Card16
            };
        }

        private void AssignImageToButtons(BitmapImage image, List<Button> buttons, Random random)
        {
            for (int i = 0; i < 2; i++)
            {
                if (buttons.Count == 0) break;
                var index = random.Next(buttons.Count);
                var button = buttons[index];
                buttons.RemoveAt(index);
                buttonImageMap[button] = image;
            }
        }

        private void Card_Click(object sender, RoutedEventArgs e)
        {
            if (!canClickCards)
            {
                MessageBox.Show("Za mało kart (potrzeba 8). Należy załadować zdjęcia poprzez manager w menu.");
                return;
            }

            if (firstClicked != null && secondClicked != null)
                return;

            Button clickedButton = sender as Button;
            if (clickedButton == null || !buttonImageMap.ContainsKey(clickedButton) || clickedButton == firstClicked || clickedButton.IsEnabled == false)
                return;

            DisplayImageOnButton(clickedButton);

            if (firstClicked == null)
            {
                firstClicked = clickedButton;
                return;
            }

            secondClicked = clickedButton;
            CheckForMatch();
        }

        private void DisplayImageOnButton(Button button)
        {
            button.Content = new Image { Source = buttonImageMap[button] };
        }

        private void CheckForMatch()
        {
            if (buttonImageMap[firstClicked] == buttonImageMap[secondClicked])
            {
                HandleMatchFound();
            }
            else
            {
                HideImagesAfterDelay();
            }
        }

        private async void HideImagesAfterDelay()
        {
            await Task.Delay(1000);
            firstClicked.Content = null;
            secondClicked.Content = null;
            firstClicked = null;
            secondClicked = null;
        }

        private void AddCardImageToMovesList(BitmapImage cardImage)
        {
            MovesList.Items.Add(new { Image = cardImage });
        }

        private void BackToMenuButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenu());
        }

        private void StartGameTimer()
        {
            if (gameTimer != null)
            {
                gameTimer.Stop();
                gameTimer.Tick -= GameTimer_Tick;
            }

            secondsElapsed = 0;
            gameTimer = new DispatcherTimer();
            gameTimer.Interval = TimeSpan.FromSeconds(1);
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();
        }

        private void StopGameTimer()
        {
            if (gameTimer != null)
            {
                gameTimer.Stop();
                gameTimer.Tick -= GameTimer_Tick;
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            secondsElapsed++;
            TimeLabel.Content = $"Czas: {secondsElapsed} s";
        }
    }
}
