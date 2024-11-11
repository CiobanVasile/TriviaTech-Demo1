namespace TriviaTech.Components.domain;

public class UserGame
{
    public int UserId { get; set; }
    public User User { get; set; }

    public int GameId { get; set; }
    public Game Game { get; set; }

    public int Points { get; set; }
}