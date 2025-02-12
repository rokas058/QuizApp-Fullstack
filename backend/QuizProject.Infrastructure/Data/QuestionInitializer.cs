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
                    Options =
                    [
                        new QuestionOption { Option = "Paris" },
                        new QuestionOption { Option = "London" },
                        new QuestionOption { Option = "Berlin" },
                        new QuestionOption { Option = "Madrid" }
                    ],
                    CorrectAnswers =
                    [
                        new CorrectAnswer { Answer = "Paris" }
                    ]
                },
                new Question
                {
                    QuestionText = "Select the programming languages:",
                    QuestionType = QuestionType.Checkbox,
                    Options =
                    [
                        new QuestionOption { Option = "C#" },
                        new QuestionOption { Option = "HTML" },
                        new QuestionOption { Option = "CSS" },
                        new QuestionOption { Option = "Python" }
                    ],
                    CorrectAnswers =
                    [
                        new CorrectAnswer { Answer = "C#" },
                        new CorrectAnswer { Answer = "Python" }
                    ]
                },
                new Question
                {
                    QuestionText = "What is 5 + 5?",
                    QuestionType = QuestionType.TextBox,
                    CorrectAnswers =
                    [
                        new CorrectAnswer { Answer = "10" }
                    ]
                },
                new Question
                {
                    QuestionText = "What is the largest planet in our solar system?",
                    QuestionType = QuestionType.Radio,
                    Options =
                    [
                        new QuestionOption { Option = "Earth" },
                        new QuestionOption { Option = "Jupiter" },
                        new QuestionOption { Option = "Mars" },
                        new QuestionOption { Option = "Saturn" }
                    ],
                    CorrectAnswers =
                    [
                        new CorrectAnswer { Answer = "Jupiter" }
                    ]
                },
                new Question
                {
                    QuestionText = "Which one is the largest continent?",
                    QuestionType = QuestionType.Radio,
                    Options =
                    [
                        new QuestionOption { Option = "Asia" },
                        new QuestionOption { Option = "Africa" },
                        new QuestionOption { Option = "Europe" },
                        new QuestionOption { Option = "North America" }
                    ],
                    CorrectAnswers =
                    [
                        new CorrectAnswer { Answer = "Asia" }
                    ]
                },
                new Question
                {
                    QuestionText = "Select the fruits:",
                    QuestionType = QuestionType.Checkbox,
                    Options =
                    [
                        new QuestionOption { Option = "Apple" },
                        new QuestionOption { Option = "Banana" },
                        new QuestionOption { Option = "Carrot" },
                        new QuestionOption { Option = "Orange" }
                    ],
                    CorrectAnswers =
                    [
                        new CorrectAnswer { Answer = "Apple" },
                        new CorrectAnswer { Answer = "Banana" },
                        new CorrectAnswer { Answer = "Orange" }
                    ]
                },
                new Question
                {
                    QuestionText = "Which of the following are programming languages?",
                    QuestionType = QuestionType.Checkbox,
                    Options =
                    [
                        new QuestionOption { Option = "Java" },
                        new QuestionOption { Option = "Python" },
                        new QuestionOption { Option = "HTML" },
                        new QuestionOption { Option = "Banana" }
                    ],
                    CorrectAnswers =
                    [
                        new CorrectAnswer { Answer = "Java" },
                        new CorrectAnswer { Answer = "Python" }
                    ]
                },
                new Question
                {
                    QuestionText = "What is the capital of Germany?",
                    QuestionType = QuestionType.TextBox,
                    CorrectAnswers =
                    [
                        new CorrectAnswer { Answer = "Berlin" }
                    ]
                },
                new Question
                {
                    QuestionText = "Which one is the largest ocean?",
                    QuestionType = QuestionType.Radio,
                    Options =
                    [
                        new QuestionOption { Option = "Atlantic Ocean" },
                        new QuestionOption { Option = "Indian Ocean" },
                        new QuestionOption { Option = "Pacific Ocean" },
                        new QuestionOption { Option = "Arctic Ocean" }
                    ],
                    CorrectAnswers =
                    [
                        new CorrectAnswer { Answer = "Pacific Ocean" }
                    ]
                },
                new Question
                {
                    QuestionText = "Select the web development technologies:",
                    QuestionType = QuestionType.Checkbox,
                    Options =
                    [
                        new QuestionOption { Option = "React" },
                        new QuestionOption { Option = "Vue" },
                        new QuestionOption { Option = "CSS" },
                        new QuestionOption { Option = "Java" }
                    ],
                    CorrectAnswers =
                    [
                        new CorrectAnswer { Answer = "React" },
                        new CorrectAnswer { Answer = "Vue" },
                        new CorrectAnswer { Answer = "CSS" }
                    ]
                }
            );

            context.SaveChanges();
        }
    }
}

