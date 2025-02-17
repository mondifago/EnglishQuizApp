namespace EnglishQuizApp.Models
{
    public class PlayerAnswer
    {
        public Guid Id { get; set; }

        public Guid QuestionId { get; set; }
        public Question Question { get; set; }

        public Guid SelectedAnswerId { get; set; }
        public AnswerOption SelectedAnswer { get; set; }

        public Guid? GameSessionId { get; set; }
        public GameSession GameSession { get; set; }
    }

}
