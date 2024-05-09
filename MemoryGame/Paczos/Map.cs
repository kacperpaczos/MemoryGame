using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace Paczos
{
    internal class Map : IMap
    {
        // Deklaracja tablicy dwuwymiarowej do przechowywania stanów obrazów
        private ImageState[,] imageStates = new ImageState[4, 4];
        private string[] files;
        private int[,] imageAssignments = new int[4, 4];

        // Konstruktor klasy Map, który ładuje obrazy z folderu
        public Map()
        {
            LoadImagesFromFolder(".\\images");
            InitializeImageStates();
            AssignImages();
        }

        private void InitializeImageStates()
        {
            for (int x = 0; x < imageStates.GetLength(0); x++)
            {
                for (int y = 0; y < imageStates.GetLength(1); y++)
                {
                    imageStates[x, y] = ImageState.Revealed;
                }
            }
        }

        public ImageState[,] GetImageStates()
        {
            return imageStates;
        }

        // Metoda prywatna do ładowania obrazów z określonego folderu
        private void LoadImagesFromFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                string fullPath = Path.GetFullPath(folderPath);
                MessageBox.Show($"Nie znaleziono folderu: {fullPath}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Pobieranie wszystkich plików z folderu
            files = Directory.GetFiles(folderPath);

            if (files.Length == 0)
            {
                MessageBox.Show("Folder jest pusty.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        // Przypisanie obrazów do stanów w sposób zapewniający równomierne rozłożenie
        private void AssignImages()
        {
            List<int> availableIndices = Enumerable.Range(0, 8).ToList();
            List<int> imagePool = new List<int>();

            // Każdy indeks obrazu dodajemy dwa razy do puli
            foreach (var index in availableIndices)
            {
                imagePool.Add(index);
                imagePool.Add(index);
            }

            Random random = new Random();
            for (int x = 0; x < imageAssignments.GetLength(0); x++)
            {
                for (int y = 0; y < imageAssignments.GetLength(1); y++)
                {
                    int randomIndex = random.Next(imagePool.Count);
                    imageAssignments[x, y] = imagePool[randomIndex];
                    imagePool.RemoveAt(randomIndex);
                }
            }
        }

        // Załadowanie obrazu dla danego stanu
        public Image LoadImageForState(int x, int y)
        {
            int imageIndex = imageAssignments[x, y];
            return Image.FromFile(files[imageIndex]);
        }
    }
}

