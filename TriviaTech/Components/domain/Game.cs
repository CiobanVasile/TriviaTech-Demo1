namespace TriviaTech.Components.domain;

public enum DifficultyLevel
{
    Easy,
    Medium,
    Hard
}

public class Game
{
    public int Id { get; set; }
    public DifficultyLevel Difficulty { get; set; }

    // Navigation properties for questions and user scores
    public ICollection<GameQuestion> GameQuestions { get; set; } = new List<GameQuestion>();
    public ICollection<UserGame> UserGames { get; set; } = new List<UserGame>();
}