using System.ComponentModel.DataAnnotations;

namespace EnglishQuizApp.Models
{
    public class AnswerOption
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Answer text is required")]
        public string Text { get; set; }

        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
    }
}