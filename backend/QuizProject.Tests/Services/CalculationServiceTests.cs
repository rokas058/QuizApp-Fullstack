using QuizProject.Models.Dto;
using QuizProject.Models.Entities;
using QuizProject.Models.Enum;
using QuizProject.Services;
using Xunit;
using System.Collections.Generic;

namespace QuizProject.Tests.Services
{
    public class CalculationServiceTests
    {
        private readonly CalculationService _calculationService;

        public CalculationServiceTests()
        {
            _calculationService = new CalculationService();
        }

        [Fact]
        public void CalculateCheckboxScore_ShouldReturnCorrectScore()
        {
            // Arrange
            var question = new Question
            {
                CorrectAnswers = ["C#", "Python"],
                QuestionType = QuestionType.Checkbox
            };

            var answer = new Answer
            {
                SelectedOptions = ["C#", "Python"]
            };

            // Act
            var result = _calculationService.CalculateCheckboxScore(question, answer);

            // Assert
            Assert.Equal(100, result); 
        }

        [Fact]
        public void CalculateCheckboxScore_ShouldReturnZeroForIncorrectAnswer()
        {
            // Arrange
            var question = new Question
            {
                CorrectAnswers = ["C#", "Python"],
                QuestionType = QuestionType.Checkbox
            };

            var answer = new Answer
            {
                SelectedOptions = ["C#", "JavaScript"]
            };

            // Act
            var result = _calculationService.CalculateCheckboxScore(question, answer);

            // Assert
            Assert.Equal(0, result); 
        }

        [Fact]
        public void CalculateRadioScore_ShouldReturnCorrectScore()
        {
            // Arrange
            var question = new Question
            {
                CorrectAnswers = ["Paris"],
                QuestionType = QuestionType.Radio
            };

            var answer = new Answer
            {
                SelectedOptions = ["Paris"]
            };

            // Act
            var result = _calculationService.CalculateRadioScore(question, answer);

            // Assert
            Assert.Equal(100, result); 
        }

        [Fact]
        public void CalculateRadioScore_ShouldReturnZeroForIncorrectAnswer()
        {
            // Arrange
            var question = new Question
            {
                CorrectAnswers = [ "Paris" ],
                QuestionType = QuestionType.Radio
            };

            var answer = new Answer
            {
                SelectedOptions = [ "London" ]
            };

            // Act
            var result = _calculationService.CalculateRadioScore(question, answer);

            // Assert
            Assert.Equal(0, result); 
        }

        [Fact]
        public void CalculateTextBoxScore_ShouldReturnCorrectScore()
        {
            // Arrange
            var question = new Question
            {
                CorrectAnswers = [ "10" ],
                QuestionType = QuestionType.TextBox
            };

            var answer = new Answer
            {
                TextAnswer = "10"
            };

            // Act
            var result = _calculationService.CalculateTextBoxScore(question, answer);

            // Assert
            Assert.Equal(100, result); 
        }

        [Fact]
        public void CalculateTextBoxScore_ShouldReturnZeroForIncorrectAnswer()
        {
            // Arrange
            var question = new Question
            {
                CorrectAnswers = [ "10" ],
                QuestionType = QuestionType.TextBox
            };

            var answer = new Answer
            {
                TextAnswer = "5"
            };

            // Act
            var result = _calculationService.CalculateTextBoxScore(question, answer);

            // Assert
            Assert.Equal(0, result); 
        }
    }
}

