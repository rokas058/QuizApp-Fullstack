

using QuizProject.Domain.Entities;
using QuizProject.Domain.Enum;

namespace QuizProject.Infrastructure.Data
{
    public class QuestionInitializer
    {
        public static void Initialize(ApplicationDBContext context)
        {
            if (context.Questions.Any()) return;

            context.Questions.AddRange(
                new Question
                {
                    QuestionText = "Which is the capital of France?",
                    QuestionType = QuestionType.Radio,
                    Options = ["Paris", "London", "Berlin", "Madrid"],
                    CorrectAnswers = ["Paris"]
                },
                new Question
                {
                    QuestionText = "Select the programming languages:",
                    QuestionType = QuestionType.Checkbox,
                    Options = ["C#", "HTML", "CSS", "Python"],
                    CorrectAnswers = ["C#", "Python"]
                },
                new Question
                {
                    QuestionText = "What is 5 + 5?",
                    QuestionType = QuestionType.TextBox,
                    CorrectAnswers = ["10"]
                },
                new Question
                {
                    QuestionText = "What is the largest planet in our solar system?",
                    QuestionType = QuestionType.Radio,
                    Options = ["Earth", "Jupiter", "Mars", "Saturn"],
                    CorrectAnswers = ["Jupiter"]
                },
                new Question
                {
                    QuestionText = "Which one is the largest continent?",
                    QuestionType = QuestionType.Radio,
                    Options = ["Asia", "Africa", "Europe", "North America"],
                    CorrectAnswers = ["Asia"]
                },
                new Question
                {
                    QuestionText = "Select the fruits:",
                    QuestionType = QuestionType.Checkbox,
                    Options = ["Apple", "Banana", "Carrot", "Orange"],
                    CorrectAnswers = ["Apple", "Banana", "Orange"]
                },
                new Question
                {
                    QuestionText = "Which of the following are programming languages?",
                    QuestionType = QuestionType.Checkbox,
                    Options = ["Java", "Python", "HTML", "Banana"],
                    CorrectAnswers = ["Java", "Python"]
                },
                new Question
                {
                    QuestionText = "What is the capital of Germany?",
                    QuestionType = QuestionType.TextBox,
                    CorrectAnswers = ["Berlin"]
                },
                new Question
                {
                    QuestionText = "Which one is the largest ocean?",
                    QuestionType = QuestionType.Radio,
                    Options = ["Atlantic Ocean", "Indian Ocean", "Pacific Ocean", "Arctic Ocean"],
                    CorrectAnswers = ["Pacific Ocean"]
                },
                new Question
                {
                    QuestionText = "Select the web development technologies:",
                    QuestionType = QuestionType.Checkbox,
                    Options = ["React", "Vue", "CSS", "Java"],
                    CorrectAnswers = ["React", "Vue", "CSS"]
                }
            );

            context.SaveChanges();
        }
    }
}
