using Paczos.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Paczos
{
    internal class MemoryGameUsersManager
    {
        private string filePath = "users.json";
        private List<MemoryGameUser> users;

        public MemoryGameUsersManager()
        {
            LoadUsers();
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
            return users;
        }

        public void AddUser(MemoryGameUser user)
        {
            users.Add(user);
            SaveUsers();
        }
    }
}
