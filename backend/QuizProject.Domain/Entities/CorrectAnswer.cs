namespace QuizProject.Domain.Entities
{
    public class CorrectAnswer
    {
        public int Id { get; set; }
        public string Answer { get; set; } = string.Empty;
        public int QuestionId { get; set; }
        public Question Question { get; set; } = null!;
    }
}
