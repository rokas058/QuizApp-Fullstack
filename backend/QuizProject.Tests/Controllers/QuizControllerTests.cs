using Moq;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions.Execution;
using FluentAssertions;
using QuizProject.Application.Interfaces;
using QuizProject.API.Controllers;
using QuizProject.Application.Dto;


namespace QuizProject.Tests.Controllers
{
    public class QuizControllerTests
    {
        private readonly Mock<IQuizService> _mockQuizService;
        private readonly QuizSubmissionController _quizController;

        public QuizControllerTests()
        {
            _mockQuizService = new Mock<IQuizService>();
            _quizController = new QuizSubmissionController(_mockQuizService.Object);
        }

        [Fact]
        public async Task GetAllQuestions_ReturnsOkResult_WithQuestions()
        {
            // Arrange
            var expectedQuestions = new List<QuestionDto>
            {
                new() { Id = 1, QuestionText = "What is 2 + 2?" },
                new() { Id = 2, QuestionText = "What is the capital of France?" }
            };

            _mockQuizService.Setup(service => service.GetAllQuestionsAsync()).ReturnsAsync(expectedQuestions);

            // Act
            var result = await _quizController.GetAllQuestions();

            // Assert
            using (new AssertionScope())
            {
                var okResult = Assert.IsType<OkObjectResult>(result);
                var returnValue = Assert.IsType<IEnumerable<QuestionDto>>(okResult.Value, exactMatch: false);
                returnValue.Count().Should().Be(2);
            }
        }

        [Fact]
        public async Task SubmitQuiz_ReturnsOkResult_WithQuizResult()
        {
            // Arrange
            var submission = new QuizSubmission
            {
                Email = "test@example.com",
                Answers =
                [
                    new Answer
                    {
                        QuestionId = 1,
                        SelectedOptions = ["4"],
                        TextAnswer = null
                    },
                    new Answer
                    {
                        QuestionId = 2,
                        SelectedOptions = [ "Paris" ], 
                        TextAnswer = null
                    }
                ]
            };

            var expectedResult = new QuizResultDto
            {
                Email = "test@example.com",
                Score = 10,
                DateTime = DateTime.Now
            };

            _mockQuizService.Setup(service => service.SubmitQuizAsync(submission)).ReturnsAsync(expectedResult);

            // Act
            var result = await _quizController.SubmitQuiz(submission);

            // Assert
            using (new AssertionScope()) 
            {
                var okResult = Assert.IsType<OkObjectResult>(result);
                var returnValue = Assert.IsType<QuizResultDto>(okResult.Value);
                returnValue.Score.Should().Be(10);  
                returnValue.Email.Should().Be("test@example.com"); 
            }
        }

        [Fact]
        public async Task GetAllScores_ReturnsOkResult_WithScores()
        {
            // Arrange
            var expectedScores = new List<QuizResultDto>
            {
                new() { Email = "test@example.com", Score = 10 },
                new() { Email = "user2@example.com", Score = 8 }
            };

            _mockQuizService.Setup(service => service.GetAllScoresAsync()).ReturnsAsync(expectedScores);

            // Act
            var result = await _quizController.GetAllScores();

            // Assert
            using (new AssertionScope())  
            {
                var okResult = Assert.IsType<OkObjectResult>(result);
                var returnValue = Assert.IsType<IEnumerable<QuizResultDto>>(okResult.Value, exactMatch: false);
                returnValue.Count().Should().Be(2);  
            }
        }
    }
}




