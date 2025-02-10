using AutoMapper;
using QuizProject.Models.Dto;
using QuizProject.Models.Entities;
using QuizProject.Models.Enum;
using QuizProject.Repositories;

namespace QuizProject.Services
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

        public async Task<List<QuestionDto>> GetAllQuestions()
        {
            var questions = await _questionRepository.GetAllQuestions();
            return _mapper.Map<List<QuestionDto>>(questions);
        }

        public async Task<QuizResultDto> SubmitQuiz(QuizSubmission submission)
        {
            int totalScore = 0;

            foreach (var answer in submission.Answers)
            {
                var question = await _questionRepository.GetQuestionById(answer.QuestionId);

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

        public async Task<List<QuizResultDto>> GetAllScores()
        {
            var scores = await _quizResultRepository.GetHighScores();
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

             return await _quizResultRepository.AddQuizResult(quizResult);
        }

    }

}
