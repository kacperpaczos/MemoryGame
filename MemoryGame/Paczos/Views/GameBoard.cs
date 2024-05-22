using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Paczos.Interfaces;

namespace Paczos.Views
{
    public partial class GameBoard : Form
    {
        public GameBoard()
        {
            InitializeComponent();
            map = new Map();
            memoryGameHistory = new MemoryGameHistory();
            Draw();
            
        }

        private MemoryGameHistory memoryGameHistory;
        private Map map;
        private PictureBox firstClickedPictureBox = null;
        private PictureBox secondClickedPictureBox = null;

        public void Draw()
        {
            for (int x = 0; x < map.GetImageStates().GetLength(0); x++)
            {
                for (int y = 0; y < map.GetImageStates().GetLength(1); y++)
                {
                    string pictureBoxName = $"pictureBox{x + 1}_{y + 1}";
                    PictureBox pictureBox = (PictureBox)this.Controls.Find(pictureBoxName, true).FirstOrDefault();
                    if (pictureBox != null)
                    {
                        pictureBox.Click += PictureBox_Click;
                        switch (map.GetImageStates()[x, y])
                        {
                            case ImageState.Hidden:
                                pictureBox.Image = null; // Można ustawić obraz zakrycia
                                break;
                            case ImageState.Revealed:
                                pictureBox.Image = map.LoadImageForState(x, y); // Załadowanie odpowiedniego obrazu
                                break;
                            case ImageState.Matched:
                                pictureBox.Image = map.LoadImageForState(x, y); // Załadowanie odpowiedniego obrazu, może być inny styl
                                break;
                        }
                    }
                }
            }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = sender as PictureBox;
            if (clickedPictureBox != null)
            {
                string PB_coordinates = clickedPictureBox.Name.Replace("pictureBox", "");
                string[] coordinates = PB_coordinates.Split('_');
                //MessageBox.Show("Liczba elementów w coordinates: " + coordinates.Length + "\nElementy: " + string.Join(", ", coordinates));
                int x = int.Parse(coordinates[0]);
                int y = int.Parse(coordinates[1]);
               // MessageBox.Show($"Współrzędne: x = {x}, y = {y}");
                

                map.Reveal(clickedPictureBox.Name);
                clickedPictureBox.Image = map.LoadImageForStateFromName(clickedPictureBox.Name);

                if (firstClickedPictureBox == null)
                {
                    firstClickedPictureBox = clickedPictureBox;
                    memoryGameHistory.RecordMove(x, y, ImageState.Hidden, ImageState.Revealed);
                }
                else if (secondClickedPictureBox == null)
                {
                    secondClickedPictureBox = clickedPictureBox;
                    memoryGameHistory.RecordMove(x, y, ImageState.Hidden, ImageState.Revealed);

                    if (map.Match(firstClickedPictureBox.Name, secondClickedPictureBox.Name))
                    {
                        MessageBox.Show("Dopasowano!");
                        memoryGameHistory.RecordMove(x, y, ImageState.Revealed, ImageState.Matched);
                    }
                    else
                    {
                        MessageBox.Show("Nie dopasowano!");
                        firstClickedPictureBox.Image = null;
                        secondClickedPictureBox.Image = null;
                    }
                    firstClickedPictureBox = null;
                    secondClickedPictureBox = null;
                }
            }
        }

        private void UpdateGameHistory()
        {
            memoryGameHistory.DrawMoves(listViewStory); // Aktualizuj ListView z historią ruchów
        }

        private void GameBoard_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(1200, 600);
            this.Name = "MemoGame GameBoard";
            this.Text = "MemoGame GameBoard Kacper Paczos";
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void stopGameButton_Click(object sender, EventArgs e)
        {
            Program.ShowMainMenu();
        }
    }
}
