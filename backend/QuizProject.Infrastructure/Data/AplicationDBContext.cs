using Microsoft.EntityFrameworkCore;
using QuizProject.Domain.Entities;


namespace QuizProject.Infrastructure.Data
{
    public class ApplicationDBContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuizResult> QuizResults { get; set; }
    }
}
