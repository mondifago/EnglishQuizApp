using System.ComponentModel.DataAnnotations;

namespace EnglishQuizApp.Models
{
    public class GameSession
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Player Player { get; set; }

        [Required]
        public Quiz Quiz { get; set; }

        public List<Question> SelectedQuestions { get; private set; } = new();

        [Range(0, int.MaxValue, ErrorMessage = "Score cannot be negative")]
        public int Score { get; private set; }

        public Dictionary<Question, AnswerOption> AnswersGiven { get; set; } = new();

        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }

        public TimeSpan Duration { get; private set; }

        public bool IsCompleted { get; private set; }
    }
}
