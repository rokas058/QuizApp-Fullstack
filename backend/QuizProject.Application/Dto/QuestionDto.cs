using QuizProject.Domain.Enum;
using System.Text.Json.Serialization;

namespace QuizProject.Application.Dto
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public QuestionType QuestionType { get; set; }
        public List<string>? Options { get; set; }
        public List<string> CorrectAnswers { get; set; } = [];
    }
}
