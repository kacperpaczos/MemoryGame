using Paczos.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace Paczos
{
    internal class MemoryGameUsersManager
    {
        private static MemoryGameUsersManager instance;
        private string filePath = "users.json";
        private List<MemoryGameUser> users;
        private MemoryGameUser mainUser; // Dodane pole dla głównego użytkownika
        private MemoryGameUser secondUser;

        private MemoryGameUsersManager()
        {
            LoadUsers();
            mainUser = null; // Inicjalizacja głównego użytkownika jako null
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
            var jsonString = JsonSerializer.Serialize(users);
            File.WriteAllText(filePath, jsonString);
        }

        private void LoadUsers()
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Brak pliku z danymi użytkowników. Inicjalizacja pustej listy użytkowników.");
                users = new List<MemoryGameUser>();
            }
            else
            {
                var jsonString = File.ReadAllText(filePath);
                users = JsonSerializer.Deserialize<List<MemoryGameUser>>(jsonString) ?? new List<MemoryGameUser>();
            }
        }

        public List<MemoryGameUser> GetUsers()
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
            SaveUsers(); // Możesz również zdecydować się na zapisanie stanu głównego użytkownika w pliku
        }
    }
}