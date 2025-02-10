using QuizProject.Models.Entities;

namespace QuizProject.Repositories
{
    public interface IQuestionRepository
    {
        Task<List<Question>> GetAllQuestions();
        Task<Question> AddQuestion(Question question);
        Task<Question?> GetQuestionById(int id);
    }
}
