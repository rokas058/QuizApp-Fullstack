using QuizProject.Models.Dto;
using QuizProject.Models.Entities;

namespace QuizProject.Services
{
    public class CalculationService : ICalculationService
    {
        public int CalculateCheckboxScore(Question question, Answer answer)
        {
            int correctAnswersCount = question.CorrectAnswers.Count;
            int correctSelectedCount = answer.SelectedOptions.Intersect(question.CorrectAnswers).Count();
            int incorrectSelectedCount = answer.SelectedOptions.Except(question.CorrectAnswers).Count();

            if (incorrectSelectedCount > 0)
            {
                return 0;
            }

            if (correctAnswersCount > 0)
            {
                return (int)Math.Ceiling((100.0 / correctAnswersCount) * correctSelectedCount);
            }
            return 0;
        }

        public int CalculateRadioScore(Question question, Answer answer)
        {
            if (question.CorrectAnswers.Contains(answer.SelectedOptions.FirstOrDefault() ?? ""))
            {
                return 100;
            }
            return 0;
        }

        public int CalculateTextBoxScore(Question question, Answer answer)
        {
            if (answer.TextAnswer?.Trim().Equals(
            question.CorrectAnswers.FirstOrDefault(),
            StringComparison.OrdinalIgnoreCase) == true)
            {
                return 100;
            }
            return 0;
        }
    }
}
