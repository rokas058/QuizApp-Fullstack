using Microsoft.EntityFrameworkCore;
using QuizProject.Models.Entities;

namespace QuizProject.Data
{
    public class AplicationDBContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuizResult> QuizResults { get; set; }
    }
}
