namespace EnglishQuizApp.Models
{
    public class PlayerAnswer
    {
        public Guid Id { get; set; }

        public Guid QuestionId { get; set; }  // Ensure this is defined
        public Question Question { get; set; }  // Ensure navigation property exists

        public Guid SelectedAnswerId { get; set; }  // Ensure this is defined
        public AnswerOption SelectedAnswer { get; set; }  // Ensure navigation property exists

        public Guid? GameSessionId { get; set; }
        public GameSession GameSession { get; set; }
    }

}
