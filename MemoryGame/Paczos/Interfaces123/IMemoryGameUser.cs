public interface IMemoryGameUser
{
    string Nickname { get; set; }
    int Points { get; set; }

    // Tutaj możesz dodać metody, które będą wymagane od każdego użytkownika, np.:
    void UpdateScore(int points);
}