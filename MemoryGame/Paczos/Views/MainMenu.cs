using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paczos.Views
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        public Button GameButton
        {
            get { return gameButton; }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void userButton_Click(object sender, EventArgs e)
        {
            Program.ShowUserPanel();
        }

        private void gameButton_Click(object sender, EventArgs e)
        {
            Program.ShowGameBoard();
        }
    }
}
