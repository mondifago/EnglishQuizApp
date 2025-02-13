using EnglishQuizApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EnglishQuizApp.Data
{
    public class EnglishQuizAppContext : DbContext
    {
        public EnglishQuizAppContext(DbContextOptions<EnglishQuizAppContext> options) : base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<GameSession> GameSessions { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswerOption> AnswerOptions { get; set; }
        public DbSet<PlayerAnswer> PlayerAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerAnswer>()
                .HasOne(pa => pa.Question)
                .WithMany() // Avoid navigation loop
                .HasForeignKey(pa => pa.QuestionId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<PlayerAnswer>()
                .HasOne(pa => pa.SelectedAnswer)
                .WithMany() // Avoid navigation loop
                .HasForeignKey(pa => pa.SelectedAnswerId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<PlayerAnswer>()
                .HasOne(pa => pa.GameSession)
                .WithMany()
                .HasForeignKey(pa => pa.GameSessionId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete
        }


    }
}
