namespace TriviaTech.Components.domain;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    // Navigation property for User's games
    public ICollection<UserGame> UserGames { get; set; } = new List<UserGame>();
}