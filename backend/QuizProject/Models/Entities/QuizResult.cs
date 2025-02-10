namespace QuizProject.Models.Entities
{
    public class QuizResult
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public int Score { get; set; }
        public DateTime DateTime { get; set; }
    }
}
