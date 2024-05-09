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

        // Konstruktor klasy Map, który ładuje obrazy z folderu
        public Map()
        {
            LoadImagesFromFolder(".\\images");
            InitializeImageStates();
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

        // Załadowanie obrazu dla danego stanu
        public Image LoadImageForState(int x, int y)
        {
            Random random = new Random();
            int imageIndex = random.Next(1, 9); // Losowanie liczby od 1 do 8
            return Image.FromFile(files[imageIndex - 1]); // Załadowanie wylosowanego obrazu
        }
    }
}

