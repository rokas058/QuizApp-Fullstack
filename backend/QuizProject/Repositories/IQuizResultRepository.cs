using QuizProject.Models.Entities;

namespace QuizProject.Repositories
{
    public interface IQuizResultRepository
    {
        Task<QuizResult> AddQuizResult(QuizResult quizResult);
        Task<List<QuizResult>> GetHighScores();
    }
}
