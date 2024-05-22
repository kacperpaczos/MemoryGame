using Paczos.Models;
using Paczos.DataAccess.FS; // Dodano do korzystania z FileManager
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using Paczos.Interfaces;

namespace Paczos
{
    internal class MemoryGameUsersManager
    {
        private static MemoryGameUsersManager instance;
        private string filePath = "users.txt";
        private FileManager fileManager = new FileManager();
        private List<Paczos.Interfaces.IMemoryGameUser> users;
        private MemoryGameUser mainUser; // Dodane pole dla głównego użytkownika
        private MemoryGameUser secondUser;

        private MemoryGameUsersManager()
        {
            LoadUsers();
            mainUser = null; // Inicjalizacja głównego użytkownika jako null
            secondUser = null;
        }

        public static MemoryGameUsersManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MemoryGameUsersManager();
                }
                return instance;
            }
        }

        public void SaveUsers()
        {
            //fileManager.SaveJson(filePath, users);

            // Zapis do pliku
            fileManager.SaveUsersToFile(filePath, users);
        }

        private void LoadUsers()
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Brak pliku z danymi użytkowników. Inicjalizacja pustej listy użytkowników.");
                users = new List<Paczos.Interfaces.IMemoryGameUser>();
            }
            else
            {
                users = fileManager.LoadUsersFromFile(filePath);
            }
        }

        public List<Paczos.Interfaces.IMemoryGameUser> GetUsers()
        {
            if (users.Count == 0)
            {
                MessageBox.Show("Brak graczy.");
            }
            return users;
        }

        public void AddUser(MemoryGameUser user)
        {
            users.Add(user);
            SaveUsers();
        }

        public MemoryGameUser GetMainUser()
        {
            return mainUser;
        }

        public void SetMainUser(MemoryGameUser user)
        {
            mainUser = user;
            SaveUsers(); // Możesz również zdecydować się na zapisanie stanu głównego użytkownika w pliku
        }

        public void SetSecondUser(MemoryGameUser user)
        {
            secondUser = user;
            SaveUsers(); // Możesz również zdecydować się na zapisanie stanu drugiego użytkownika w pliku
        }
    }
}