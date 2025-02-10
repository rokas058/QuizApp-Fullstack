using Microsoft.EntityFrameworkCore;
using QuizProject.Data;
using QuizProject.Models.Entities;

namespace QuizProject.Repositories
{
    public class QuestionRepository(AplicationDBContext dbContext) : IQuestionRepository
    {
        private readonly AplicationDBContext _dBContext = dbContext;

        public async Task<List<Question>> GetAllQuestions()
        {
            return await _dBContext.Questions.ToListAsync();
        }

        public async Task<Question> AddQuestion(Question question)
        {
            await _dBContext.Questions.AddAsync(question);
            await _dBContext.SaveChangesAsync();
            return question;
        }

        public async Task<Question?> GetQuestionById(int id)
        {
            return await _dBContext.Questions.FindAsync(id);
        }

    }
}
