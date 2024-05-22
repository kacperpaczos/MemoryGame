using Paczos.Interfaces;
using System;

namespace Paczos.Models
{
    internal class MemoryGameUser : IMemoryGameUser
    {
        private string firstName;
        private string lastName;
        private string nickname;
        private string keyData;
        private int points;
        private int gamesPlayed;
        private int id; // Dodanie pola ID

        public string GetFirstName() => firstName;
        public void SetFirstName(string value) => firstName = value;
        public string GetLastName() => lastName;
        public void SetLastName(string value) => lastName = value;
        public string GetNickname() => nickname;
        public void SetNickname(string value) => nickname = value;
        public string GetKeyData() => keyData;
        public void SetKeyData(string value) => keyData = value;
        public int GetPoints() => points;
        public void SetPoints(int value) => points = value;
        public int GetGamesPlayed() => gamesPlayed;
        public void SetGamesPlayed(int value) => gamesPlayed = value;
        public int GetId() => id;
        public void SetId(int value) => id = value;

        public MemoryGameUser() { }

        public MemoryGameUser(string firstName, string lastName, string nickname, string keyData, int points, int gamesPlayed, int id)
        {
            SetFirstName(firstName);
            SetLastName(lastName);
            SetNickname(nickname);
            SetKeyData(keyData);
            SetPoints(points);
            SetGamesPlayed(gamesPlayed);
            this.id = id; // Inicjalizacja ID
        }

        public void AddPoints(int pointsToAdd)
        {
            SetPoints(GetPoints() + pointsToAdd);
        }

        public void IncrementGamesPlayed()
        {
            SetGamesPlayed(GetGamesPlayed() + 1);
        }
    }
}