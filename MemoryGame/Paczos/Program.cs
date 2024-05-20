using System;
using System.Windows.Forms;
using Paczos.Views;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Paczos
{
    internal static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        /// 
        public static Paczos.Views.MainMenu mainMenu;
        public static Paczos.Views.UsersPanel userPanel;
        public static Paczos.Views.GameBoard gameBoard;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            mainMenu = new Paczos.Views.MainMenu();
            userPanel = new Paczos.Views.UsersPanel();
            gameBoard = new Paczos.Views.GameBoard();

            Application.Run(mainMenu);
        }

        public static void ShowUserPanel()
        {
            userPanel.Show();
            mainMenu.Hide();
        }

        public static void ShowMainMenu()
        {
            mainMenu.Show();
            userPanel.Hide();
            gameBoard.Hide();
        }

        public static void ShowGameBoard()
        {
            gameBoard.Show();
            mainMenu.Hide();
        }
    }


}
