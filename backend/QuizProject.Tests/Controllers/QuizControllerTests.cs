using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using QuizProject.Controllers;
using QuizProject.Services;
using QuizProject.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizProject.Tests.Controllers
{
    public class QuizControllerTests
    {
        private readonly Mock<IQuizService> _mockQuizService;
        private readonly QuizController _quizController;

        public QuizControllerTests()
        {
            _mockQuizService = new Mock<IQuizService>();
            _quizController = new QuizController(_mockQuizService.Object);
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

            _mockQuizService.Setup(service => service.GetAllQuestions()).ReturnsAsync(expectedQuestions);

            // Act
            var result = await _quizController.GetAllQuestions();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<IEnumerable<QuestionDto>>(okResult.Value, exactMatch: false);
            Assert.Equal(2, returnValue.Count());
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

            _mockQuizService.Setup(service => service.SubmitQuiz(submission)).ReturnsAsync(expectedResult);

            // Act
            var result = await _quizController.SubmitQuiz(submission);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<QuizResultDto>(okResult.Value);
            Assert.Equal(10, returnValue.Score);
            Assert.Equal("test@example.com", returnValue.Email);
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

            _mockQuizService.Setup(service => service.GetAllScores()).ReturnsAsync(expectedScores);

            // Act
            var result = await _quizController.GetAllScores();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<IEnumerable<QuizResultDto>>(okResult.Value, exactMatch: false);
            Assert.Equal(2, returnValue.Count());
        }
    }
}




