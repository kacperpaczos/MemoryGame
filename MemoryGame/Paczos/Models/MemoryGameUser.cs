using System;

namespace Paczos.Models
{
    internal class MemoryGameUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string KeyData { get; set; }
        public int Points { get; set; }
        public int GamesPlayed { get; set; }

        // Konstruktor bezparametrowy
        public MemoryGameUser()
        {
        }

        // Konstruktor z parametrami
        public MemoryGameUser(string firstName, string lastName, string keyData, int points, int gamesPlayed)
        {
            FirstName = firstName;
            LastName = lastName;
            KeyData = keyData;
            Points = points;
            GamesPlayed = gamesPlayed;
        }

        // Metoda do dodawania punktów
        public void AddPoints(int pointsToAdd)
        {
            Points += pointsToAdd;
        }

        // Metoda do zwiększenia liczby rozegranych gier
        public void IncrementGamesPlayed()
        {
            GamesPlayed++;
        }
    }
}