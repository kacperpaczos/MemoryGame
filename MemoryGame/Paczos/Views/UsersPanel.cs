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
    public partial class UsersPanel : Form
    {
        public UsersPanel()
        {
            InitializeComponent();
            FillUsersList();
        }

        private void backToMenu_Click(object sender, EventArgs e)
        {
            Program.ShowMainMenu();
        }

        private void FillUsersList()
    {
        // Lista ksywek użytkowników
        List<string> userNicknames = new List<string> { "User1", "User2", "User3", "User4", "User5" };

        // Czyszczenie istniejących elementów
        usersList.Items.Clear();

        // Dodawanie ksywek do ListView
        foreach (var nickname in userNicknames)
        {
            usersList.Items.Add(nickname);
        }
    }
    }
}
