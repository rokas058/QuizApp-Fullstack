using QuizProject.Models.Dto;

namespace QuizProject.Services
{
    public interface IQuizService
    {
        Task<List<QuestionDto>> GetAllQuestions();
        Task<QuizResultDto> SubmitQuiz(QuizSubmission submission);
        Task<List<QuizResultDto>> GetAllScores();
    }
}
