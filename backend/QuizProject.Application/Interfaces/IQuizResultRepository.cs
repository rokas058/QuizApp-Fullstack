using QuizProject.Domain.Entities;

namespace QuizProject.Application.Interfaces
{
    public interface IQuizResultRepository
    {
        Task<QuizResult> AddQuizResultAsync(QuizResult quizResult);
        Task<List<QuizResult>> GetHighScoresAsync();
    }
}
