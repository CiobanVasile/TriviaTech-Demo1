namespace TriviaTech.Components.domain;

public class Question
{
    public int Id { get; set; }
    public string Text { get; set; }
    public string CorrectAnswer { get; set; }
    public string WrongAnswer1 { get; set; }
    public string WrongAnswer2 { get; set; }
    public string WrongAnswer3 { get; set; }

    // Navigation property for games associated with this question
    public ICollection<GameQuestion> GameQuestions { get; set; } = new List<GameQuestion>();
}