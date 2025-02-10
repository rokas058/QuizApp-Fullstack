using QuizProject.Models.Dto;
using QuizProject.Models.Entities;

namespace QuizProject.Services
{
    public interface ICalculationService
    {
        int CalculateCheckboxScore(Question question, Answer answer);
        int CalculateRadioScore(Question question, Answer answer);
        int CalculateTextBoxScore(Question question, Answer answer);
    }
}
