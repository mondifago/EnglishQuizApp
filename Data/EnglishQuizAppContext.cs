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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ensures CorrectAnswerId is a foreign key (optional but recommended)
            modelBuilder.Entity<Question>()
                .HasOne<AnswerOption>()
                .WithMany()
                .HasForeignKey(q => q.CorrectAnswerId);
        }
    }
}
