using QuizProject.Application.Dto;

namespace QuizProject.Application.Interfaces
{
    public interface IQuizService
    {
        Task<List<QuestionDto>> GetAllQuestionsAsync();
        Task<QuizResultDto> SubmitQuizAsync(QuizSubmission submission);
        Task<List<QuizResultDto>> GetAllScoresAsync();
    }
}
