using QuizProject.Application.Dto;
using QuizProject.Application.Interfaces;
using QuizProject.Domain.Entities;

namespace QuizProject.Application.Services
{
    public class CalculationService : ICalculationService
    {
        private const int FullScore = 100;
        private const int NoScore = 0;

        public int CalculateCheckboxScore(Question question, Answer answer)
        {
            int correctAnswersCount = question.CorrectAnswers.Count;
            int correctSelectedCount = answer.SelectedOptions.Intersect(question.CorrectAnswers.Select(ca => ca.Answer)).Count();
            int incorrectSelectedCount = answer.SelectedOptions.Except(question.CorrectAnswers.Select(ca => ca.Answer)).Count();

            if (incorrectSelectedCount > 0)
            {
                return NoScore;
            }

            if (correctAnswersCount > 0)
            {
                return (int)Math.Ceiling(FullScore / (double)correctAnswersCount * correctSelectedCount);
            }
            return NoScore;
        }

        public int CalculateRadioScore(Question question, Answer answer)
        {
            if (question.CorrectAnswers.Any(ca => ca.Answer.Equals(answer.SelectedOptions.FirstOrDefault(), StringComparison.OrdinalIgnoreCase)))
            {
                return FullScore;
            }
            return NoScore;
        }

        public int CalculateTextBoxScore(Question question, Answer answer)
        {
            if (answer.TextAnswer?.Trim().Equals(
            question.CorrectAnswers.FirstOrDefault()?.Answer,
            StringComparison.OrdinalIgnoreCase) == true)
            {
                return FullScore;
            }
            return NoScore;
        }
    }
}

