using QuizProject.Domain.Entities;

namespace QuizProject.Application.Interfaces
{
    public interface IQuestionRepository
    {
        Task<List<Question>> GetAllQuestionsAsync();
        Task<Question> AddQuestionAsync(Question question);
        Task<Question?> GetQuestionByIdAsync(int id);
    }
}
