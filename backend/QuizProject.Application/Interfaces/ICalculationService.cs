using QuizProject.Application.Dto;
using QuizProject.Domain.Entities;

namespace QuizProject.Application.Interfaces
{
    public interface ICalculationService
    {
        int CalculateCheckboxScore(Question question, Answer answer);
        int CalculateRadioScore(Question question, Answer answer);
        int CalculateTextBoxScore(Question question, Answer answer);
    }
}
