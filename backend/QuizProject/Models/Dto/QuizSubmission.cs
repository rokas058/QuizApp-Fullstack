
namespace QuizProject.Models.Dto
{
    public class QuizSubmission
    {
        public string Email { get; set; } = string.Empty;
        public List<Answer> Answers { get; set; } = [];
    }
}
