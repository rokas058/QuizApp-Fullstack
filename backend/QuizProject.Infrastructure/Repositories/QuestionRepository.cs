using Microsoft.EntityFrameworkCore;
using QuizProject.Application.Interfaces;
using QuizProject.Domain.Entities;
using QuizProject.Infrastructure.Data;

namespace QuizProject.Infrastructure.Repositories
{
    public class QuestionRepository(ApplicationDBContext dbContext) : IQuestionRepository
    {
        private readonly ApplicationDBContext _dBContext = dbContext;

        public async Task<List<Question>> GetAllQuestionsAsync()
        {
            return await _dBContext.Questions
                .AsNoTracking()
                .Include(q => q.Options)
                .Include(q => q.CorrectAnswers)
                .ToListAsync();
        }

        public async Task<Question> AddQuestionAsync(Question question)
        {
            await _dBContext.Questions.AddAsync(question);
            await _dBContext.SaveChangesAsync();
            return question;
        }

        public async Task<Question?> GetQuestionByIdAsync(int id)
        {
            return await _dBContext.Questions
                .Include(q => q.Options)
                .Include(q => q.CorrectAnswers)
                .FirstOrDefaultAsync(q => q.Id == id);

        }

    }
}
