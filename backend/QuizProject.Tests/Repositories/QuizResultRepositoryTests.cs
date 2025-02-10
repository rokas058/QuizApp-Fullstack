using Microsoft.EntityFrameworkCore;
using QuizProject.Data;
using QuizProject.Models.Entities;
using QuizProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizProject.Tests.Repositories
{
    public class QuizResultRepositoryTests : IDisposable
    {
        private readonly AplicationDBContext _dbContext;
        private readonly QuizResultRepository _repository;

        public QuizResultRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<AplicationDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _dbContext = new AplicationDBContext(options);
            _repository = new QuizResultRepository(_dbContext);
        }

        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
        }

        [Fact]
        public async Task AddQuizResult_ShouldAddQuizResult()
        {
            var quizResult = new QuizResult
            {
                Email = "test@example.com",
                Score = 85,
                DateTime = System.DateTime.UtcNow
            };

            var result = await _repository.AddQuizResult(quizResult);

            Assert.NotNull(result);
            Assert.Equal("test@example.com", result.Email);
            Assert.Equal(85, result.Score);
        }

        [Fact]
        public async Task GetHighScores_ShouldReturnTop10Scores()
        {
            var quizResults = new List<QuizResult>
            {
                new () { Email = "user1@example.com", Score = 90, DateTime = System.DateTime.UtcNow },
                new () { Email = "user2@example.com", Score = 85, DateTime = System.DateTime.UtcNow.AddMinutes(-1) },
                new () { Email = "user3@example.com", Score = 80, DateTime = System.DateTime.UtcNow.AddMinutes(-2) },
                new () { Email = "user4@example.com", Score = 95, DateTime = System.DateTime.UtcNow.AddMinutes(-3) },
                new () { Email = "user5@example.com", Score = 70, DateTime = System.DateTime.UtcNow.AddMinutes(-4) },
                new () { Email = "user6@example.com", Score = 100, DateTime = System.DateTime.UtcNow.AddMinutes(-5) },
                new () { Email = "user7@example.com", Score = 65, DateTime = System.DateTime.UtcNow.AddMinutes(-6) },
                new () { Email = "user8@example.com", Score = 75, DateTime = System.DateTime.UtcNow.AddMinutes(-7) },
                new () { Email = "user9@example.com", Score = 60, DateTime = System.DateTime.UtcNow.AddMinutes(-8) },
                new () { Email = "user10@example.com", Score = 80, DateTime = System.DateTime.UtcNow.AddMinutes(-9) },
                new () { Email = "user11@example.com", Score = 55, DateTime = System.DateTime.UtcNow.AddMinutes(-10) }
            };

            foreach (var quizResult in quizResults)
            {
                await _repository.AddQuizResult(quizResult);
            }

            var highScores = await _repository.GetHighScores();

            Assert.Equal(10, highScores.Count);
            Assert.True(highScores.First().Score >= highScores.Last().Score);
        }
    }
}
