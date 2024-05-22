using System;
using System.Windows.Forms;
using Paczos.Models;
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
        public static Paczos.Views.EditUserForm editUserForm;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            mainMenu = new Paczos.Views.MainMenu();
            userPanel = new Paczos.Views.UsersPanel();
            gameBoard = new Paczos.Views.GameBoard();
            editUserForm = new Paczos.Views.EditUserForm();

            Application.Run(mainMenu);
        }

        private static void checkUsers()
        {
            MemoryGameUsersManager userManager = MemoryGameUsersManager.Instance;
            MemoryGameUser mainUser = userManager.GetMainUser();

            if (mainUser != null)
            {
                MessageBox.Show($"Aktualny główny użytkownik: {mainUser.GetNickname()}");
                mainMenu.GameButton.Enabled = true;
            }
            else
            {
                MessageBox.Show("Nie zaznaczono żadnego głównego użytkownika.");
            }
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
            editUserForm.Hide();
            checkUsers();
        }

        public static void ShowGameBoard()
        {
            gameBoard.Show();
            mainMenu.Hide();
        }

        public static void ShowEditUserForm()
        {
            editUserForm.Show();
            mainMenu.Hide();
            userPanel.Hide();
            gameBoard.Hide();
        }

        public static void HideEditUserForm()
        {
            editUserForm.Hide();
            userPanel.Show();
        }
    }


}
