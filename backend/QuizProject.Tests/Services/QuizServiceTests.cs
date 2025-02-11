using AutoMapper;
using FluentAssertions.Execution;
using FluentAssertions;
using Moq;
using QuizProject.Application.Interfaces;
using QuizProject.Application.Services;
using QuizProject.Domain.Entities;
using QuizProject.Application.Dto;
using QuizProject.Domain.Enum;


namespace QuizProject.Tests.Services
{
    public class QuizServiceTests
    {
        private readonly Mock<IQuestionRepository> _questionRepoMock;
        private readonly Mock<ICalculationService> _calculationServiceMock;
        private readonly Mock<IQuizResultRepository> _quizResultRepoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly QuizService _quizService;

        public QuizServiceTests()
        {
            _questionRepoMock = new Mock<IQuestionRepository>();
            _calculationServiceMock = new Mock<ICalculationService>();
            _quizResultRepoMock = new Mock<IQuizResultRepository>();
            _mapperMock = new Mock<IMapper>();

            _quizService = new QuizService(
                _questionRepoMock.Object,
                _calculationServiceMock.Object,
                _quizResultRepoMock.Object,
                _mapperMock.Object
            );
        }

        [Fact]
        public async Task GetAllQuestions_ShouldReturnQuestions()
        {
            // Arrange
            var questions = new List<Question>
            {
                new() { Id = 1, QuestionText = "Question 1" },
                new() { Id = 2, QuestionText = "Question 2" }
            };

            _questionRepoMock.Setup(repo => repo.GetAllQuestionsAsync()).ReturnsAsync(questions);
            _mapperMock.Setup(mapper => mapper.Map<List<QuestionDto>>(questions))
                .Returns([new QuestionDto(), new QuestionDto()]);

            // Act
            var result = await _quizService.GetAllQuestionsAsync();

            // Assert
            using (new AssertionScope())
            {
                result.Should().NotBeNull();
                result.Count.Should().Be(2);
            }

            _questionRepoMock.Verify(repo => repo.GetAllQuestionsAsync(), Times.Once);
            _mapperMock.Verify(mapper => mapper.Map<List<QuestionDto>>(questions), Times.Once);
        }

        [Fact]
        public async Task SubmitQuiz_ShouldReturnQuizResultDto()
        {
            // Arrange
            var submission = new QuizSubmission
            {
                Email = "test@example.com",
                Answers =
                [
                    new Answer { QuestionId = 1, SelectedOptions = new List<string> { "Option 1" } }
                ]
            };

            var question = new Question
            {
                Id = 1,
                QuestionText = "Question 1",
                CorrectAnswers = ["Option 1"],
                QuestionType = QuestionType.Radio
            };

            _questionRepoMock.Setup(repo => repo.GetQuestionByIdAsync(It.IsAny<int>())).ReturnsAsync(question);
            _calculationServiceMock.Setup(service => service.CalculateRadioScore(question, It.IsAny<Answer>())).Returns(100);
            _quizResultRepoMock.Setup(repo => repo.AddQuizResultAsync(It.IsAny<QuizResult>())).ReturnsAsync(new QuizResult { Id = 1, Email = "test@example.com", Score = 100 });
            _mapperMock.Setup(mapper => mapper.Map<QuizResultDto>(It.IsAny<QuizResult>())).Returns(new QuizResultDto { Email = "test@example.com", Score = 100 });

            // Act
            var result = await _quizService.SubmitQuizAsync(submission);

            // Assert
            using (new AssertionScope())
            {
                result.Should().NotBeNull();
                result.Email.Should().Be("test@example.com");
                result.Score.Should().Be(100);
            }
            _questionRepoMock.Verify(repo => repo.GetQuestionByIdAsync(It.IsAny<int>()), Times.Once);
            _calculationServiceMock.Verify(service => service.CalculateRadioScore(It.IsAny<Question>(), It.IsAny<Answer>()), Times.Once);
        }

        [Fact]
        public async Task GetAllScores_ShouldReturnQuizResults()
        {
            // Arrange
            var quizResults = new List<QuizResult>
            {
                new() { Email = "test1@example.com", Score = 100 },
                new() { Email = "test2@example.com", Score = 90 }
            };

            _quizResultRepoMock.Setup(repo => repo.GetHighScoresAsync()).ReturnsAsync(quizResults);
            _mapperMock.Setup(mapper => mapper.Map<List<QuizResultDto>>(quizResults))
                .Returns([new QuizResultDto(), new QuizResultDto()]);

            // Act
            var result = await _quizService.GetAllScoresAsync();

            // Assert
            using (new AssertionScope())
            {
                result.Should().NotBeNull();
                result.Count.Should().Be(2);
            }

            _quizResultRepoMock.Verify(repo => repo.GetHighScoresAsync(), Times.Once);
            _mapperMock.Verify(mapper => mapper.Map<List<QuizResultDto>>(quizResults), Times.Once);
        }
    }
}

