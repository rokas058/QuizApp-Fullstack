using FluentAssertions.Execution;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using QuizProject.Infrastructure.Data;
using QuizProject.Infrastructure.Repositories;
using QuizProject.Domain.Entities;
using QuizProject.Domain.Enum;



namespace QuizProject.Tests.Repositories
{
    public class QuestionRepositoryTests : IDisposable
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly QuestionRepository _repository;

        public QuestionRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _dbContext = new ApplicationDBContext(options);
            _repository = new QuestionRepository(_dbContext);
        }

        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
        }

        [Fact]
        public async Task AddQuestion_ShouldAddQuestion()
        {
            // Arrange
            var question = new Question
            {
                QuestionText = "What is the capital of France?",
                QuestionType = QuestionType.Radio,
                Options = ["Paris", "London", "Berlin", "Madrid"],
                CorrectAnswers = ["Paris"]
            };

            // Act
            var result = await _repository.AddQuestionAsync(question);

            // Assert
            using (new AssertionScope())  
            {
                result.Should().NotBeNull();
                result.QuestionText.Should().Be("What is the capital of France?");
            }
        }

        [Fact]
        public async Task GetAllQuestions_ShouldReturnAllQuestions()
        {
            // Arrange
            var question1 = new Question
            {
                QuestionText = "What is 2 + 2?",
                QuestionType = QuestionType.Radio,
                Options = ["3", "4", "5"],
                CorrectAnswers = ["4"]
            };
            var question2 = new Question
            {
                QuestionText = "What is 5 + 5?",
                QuestionType = QuestionType.Radio,
                Options = ["8", "9", "10"],
                CorrectAnswers = ["10"]
            };

            await _repository.AddQuestionAsync(question1);
            await _repository.AddQuestionAsync(question2);

            // Act
            var questions = await _repository.GetAllQuestionsAsync();

            // Assert
            using (new AssertionScope())
            {
                questions.Should().NotBeEmpty();
                questions.Count.Should().Be(2);
            }
        }

        [Fact]
        public async Task GetQuestionById_ShouldReturnCorrectQuestion()
        {
            // Arrange
            var question = new Question
            {
                QuestionText = "What is 3 + 3?",
                QuestionType = QuestionType.Radio,
                Options = ["5", "6", "7"],
                CorrectAnswers = ["6"]
            };

            var addedQuestion = await _repository.AddQuestionAsync(question);

            // Act
            var result = await _repository.GetQuestionByIdAsync(addedQuestion.Id);

            // Assert
            using(new AssertionScope())
            {
                result.Should().NotBeNull();
                result.Id.Should().Be(addedQuestion.Id);
                result.QuestionText.Should().Be("What is 3 + 3?");
            }
        }
    }
}

