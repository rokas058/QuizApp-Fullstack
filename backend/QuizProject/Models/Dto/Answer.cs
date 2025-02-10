namespace QuizProject.Models.Dto
{
    public class Answer
    {
        public int QuestionId { get; set; }
        public List<string> SelectedOptions { get; set; } = [];
        public string? TextAnswer { get; set; }
    }
}
