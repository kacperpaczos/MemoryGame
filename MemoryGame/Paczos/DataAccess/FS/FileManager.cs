using Paczos.DataAccess.FS.Loaders;
using Paczos.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Text.Json;
using System.IO;
using Paczos.Interfaces;
using Paczos.Models;
using System.Windows.Forms;

namespace Paczos.DataAccess.FS
{
    internal class FileManager : IFileManager
    {
        private TextFileLoader textLoader = new TextFileLoader();
        private ImageFileLoader imageLoader = new ImageFileLoader();

        public void SaveText(string path, string data)
        {
            textLoader.Save(path, data);
        }

        public string LoadText(string path)
        {
            return (string)textLoader.Load(path);
        }

        public void SaveImage(string path, Image image)
        {
            imageLoader.Save(path, image);
        }

        public Image LoadImage(string path)
        {
            return (Image)imageLoader.Load(path);
        }

        public void SaveJson<T>(string path, T data)
        {
            string jsonData = JsonSerializer.Serialize(data);
            SaveText(path, jsonData);
        }

        public T LoadJson<T>(string path)
        {
            string jsonData = LoadText(path);
            return JsonSerializer.Deserialize<T>(jsonData);
        }

        public void SaveUsersToFile(string filePath, List<Paczos.Interfaces.IMemoryGameUser> users)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var user in users)
                {
                    writer.WriteLine($"{user.GetFirstName()},{user.GetLastName()},{user.GetNickname()},{user.GetKeyData()},{user.GetPoints()},{user.GetGamesPlayed()}");
                }
            }
        }

        public List<Paczos.Interfaces.IMemoryGameUser> LoadUsersFromFile(string filePath)
        {
            List<IMemoryGameUser> users = new List<IMemoryGameUser>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(',');
                    if (data.Length == 6)
                    {
                        MemoryGameUser user = new MemoryGameUser(data[0], data[1], data[2], data[3], int.Parse(data[4]), int.Parse(data[5]));
                        users.Add(user);
                        MessageBox.Show($"Imię: {user.GetFirstName()}\nNazwisko: {user.GetLastName()}\nPseudonim: {user.GetNickname()}\nKlucz: {user.GetKeyData()}\nPunkty: {user.GetPoints()}\nRozegrane gry: {user.GetGamesPlayed()}", "Załadowano użytkownika");
                    }
                }
            }
            return users;
        }
    }


}
