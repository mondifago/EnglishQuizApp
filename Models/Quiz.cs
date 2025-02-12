using System.ComponentModel.DataAnnotations;

namespace EnglishQuizApp.Models
{
    public class Quiz
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Quiz title is required")]
        [StringLength(20, ErrorMessage = "Title can't exceed 20 characters")]
        public string Title { get; set; }

        public List<Question> QuestionPool { get; set; } = new();

        [Range(10, 3600, ErrorMessage = "Time limit must be between 10 seconds and 1 hour")]
        public int TimeLimitSeconds { get; set; }
    }
}
