namespace TriviaTech.Components.domain;

public class GameQuestion
{
    public int GameId { get; set; }
    public Game Game { get; set; }

    public int QuestionId { get; set; }
    public Question Question { get; set; }
}