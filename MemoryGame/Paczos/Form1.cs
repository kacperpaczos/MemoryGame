using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paczos
{
    public partial class Form1 : Form
    {
        private Map map;
        //private PictureBox[,] pictureBoxes = new PictureBox[4, 4];
        public Form1()
        {
            InitializeComponent();
            //InitializePictureBoxes();
            map = new Map();
            Draw();
        }

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
                        //MessageBox.Show(pictureBoxName);
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

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(600, 600);
            this.Text = "MemoGame Kacper Paczos";
        }
    }
}
