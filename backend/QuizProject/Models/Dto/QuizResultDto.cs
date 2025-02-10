using System.Text.Json.Serialization;

namespace QuizProject.Models.Dto
{
    public class QuizResultDto
    {
        public string Email { get; set; } = string.Empty;
        public int Score { get; set; }
        public DateTime DateTime { get; set; }
    }
}
