using Microsoft.EntityFrameworkCore;
using QuizProject.Data;
using QuizProject.Models.Entities;

namespace QuizProject.Repositories
{
    public class QuizResultRepository(AplicationDBContext dbContext) : IQuizResultRepository
    {
        private readonly AplicationDBContext _dBContext = dbContext;

        public async Task<QuizResult> AddQuizResult(QuizResult quizResult)
        {
            await _dBContext.QuizResults.AddAsync(quizResult);
            await _dBContext.SaveChangesAsync();
            return quizResult;
        }

        public async Task<List<QuizResult>> GetHighScores()
        {
            return await _dBContext.QuizResults
                .OrderByDescending(q => q.Score)
                .ThenBy(q => q.DateTime)
                .Take(10)
                .ToListAsync();
        }
    }
}
