public class MemoryGameUser : IMemoryGameUser
{
    public string Nickname { get; set; }
    public int Points { get; set; }
    // Możesz dodać więcej pól zgodnie z potrzebami gry, np. poziom, liczba gier itp.

    public User(string nickname, int points)
    {
        Nickname = nickname;
        Points = points;
    }

    public void UpdateScore(int points)
    {
        Points += points;
    }
}