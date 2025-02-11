using Microsoft.EntityFrameworkCore;
using QuizProject.Application.Interfaces;
using QuizProject.Domain.Entities;
using QuizProject.Infrastructure.Data;

namespace QuizProject.Infrastructure.Repositories
{
    public class QuizResultRepository(ApplicationDBContext dbContext) : IQuizResultRepository
    {
        private readonly ApplicationDBContext _dBContext = dbContext;

        private const int TopResultsCount = 10;

        public async Task<QuizResult> AddQuizResultAsync(QuizResult quizResult)
        {
            await _dBContext.QuizResults.AddAsync(quizResult);
            await _dBContext.SaveChangesAsync();
            return quizResult;
        }

        public async Task<List<QuizResult>> GetHighScoresAsync()
        {
            return await _dBContext.QuizResults
                .OrderByDescending(q => q.Score)
                .ThenBy(q => q.DateTime)
                .Take(TopResultsCount)
                .ToListAsync();
        }
    }
}
