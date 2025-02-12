using System.ComponentModel.DataAnnotations;

namespace EnglishQuizApp.Models
{
    public class Question
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Question text is required")]
        public string Text { get; set; }

        public List<AnswerOption> Options { get; set; } = new();

        [Required(ErrorMessage = "Correct answer is required")]
        public Guid CorrectAnswerId { get; set; }
    }
}
