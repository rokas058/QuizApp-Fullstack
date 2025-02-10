using Microsoft.EntityFrameworkCore;
using QuizProject.Data;
using QuizProject.Models.Entities;
using QuizProject.Models.Enum;
using QuizProject.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace QuizProject.Tests.Repositories
{
    public class QuestionRepositoryTests : IDisposable
    {
        private readonly AplicationDBContext _dbContext;
        private readonly QuestionRepository _repository;

        public QuestionRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<AplicationDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _dbContext = new AplicationDBContext(options);
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
            var result = await _repository.AddQuestion(question);

            // Assert
            Assert.NotNull(result);  
            Assert.Equal("What is the capital of France?", result.QuestionText);  
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

            await _repository.AddQuestion(question1);
            await _repository.AddQuestion(question2);

            // Act
            var questions = await _repository.GetAllQuestions();

            // Assert
            Assert.NotEmpty(questions);  
            Assert.Equal(2, questions.Count);  
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

            var addedQuestion = await _repository.AddQuestion(question);

            // Act
            var result = await _repository.GetQuestionById(addedQuestion.Id);

            // Assert
            Assert.NotNull(result);  
            Assert.Equal(addedQuestion.Id, result?.Id);  
            Assert.Equal("What is 3 + 3?", result?.QuestionText);  
        }
    }
}

