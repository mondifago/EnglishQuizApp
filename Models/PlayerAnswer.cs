namespace EnglishQuizApp.Models
{
    public class PlayerAnswer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Question Question { get; set; }
        public AnswerOption SelectedAnswer { get; set; }
    }
}
