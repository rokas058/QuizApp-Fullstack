using QuizProject.Domain.Enum;
using System.Text.Json.Serialization;

namespace QuizProject.Domain.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public QuestionType QuestionType { get; set; }
        public ICollection<QuestionOption>? Options { get; set; } = [];
        public ICollection<CorrectAnswer> CorrectAnswers { get; set; } = [];

    }
}
