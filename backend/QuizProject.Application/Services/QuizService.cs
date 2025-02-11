using AutoMapper;
using QuizProject.Application.Dto;
using QuizProject.Application.Interfaces;
using QuizProject.Domain.Entities;
using QuizProject.Domain.Enum;

namespace QuizProject.Application.Services
{
    public class QuizService
        (
        IQuestionRepository questionRepository,
        ICalculationService calculationService,
        IQuizResultRepository quizResultRepository,
        IMapper mapper
        ) : IQuizService
    {
        private readonly IQuestionRepository _questionRepository = questionRepository;

        private readonly ICalculationService _calculationService = calculationService;

        private readonly IQuizResultRepository _quizResultRepository = quizResultRepository;

        private readonly IMapper _mapper = mapper;

        public async Task<List<QuestionDto>> GetAllQuestionsAsync()
        {
            var questions = await _questionRepository.GetAllQuestionsAsync();
            return _mapper.Map<List<QuestionDto>>(questions);
        }

        public async Task<QuizResultDto> SubmitQuizAsync(QuizSubmission submission)
        {
            int totalScore = 0;

            foreach (var answer in submission.Answers)
            {
                var question = await _questionRepository.GetQuestionByIdAsync(answer.QuestionId);

                if (question == null)
                {
                    continue;
                }

                switch (question.QuestionType)
                {
                    case QuestionType.Radio:
                        totalScore += _calculationService.CalculateRadioScore(question, answer);
                        break;

                    case QuestionType.Checkbox:
                        totalScore += _calculationService.CalculateCheckboxScore(question, answer);
                        break;

                    case QuestionType.TextBox:
                        totalScore += _calculationService.CalculateTextBoxScore(question, answer);
                        break;

                }
            }
            var score = await CreateQuizResultAsync(submission.Email, totalScore);
            return _mapper.Map<QuizResultDto>(score);
        }

        public async Task<List<QuizResultDto>> GetAllScoresAsync()
        {
            var scores = await _quizResultRepository.GetHighScoresAsync();
            return _mapper.Map<List<QuizResultDto>>(scores);
        }

        private async Task<QuizResult> CreateQuizResultAsync(string email, int totalScore)
        {
            var quizResult = new QuizResult
            {
                Email = email,
                Score = totalScore,
                DateTime = DateTime.UtcNow
            };

            return await _quizResultRepository.AddQuizResultAsync(quizResult);
        }

    }

}
