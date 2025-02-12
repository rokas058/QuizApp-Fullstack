using Microsoft.AspNetCore.Mvc;
using QuizProject.Application.Interfaces;

namespace QuizProject.API.Controllers
{
    [Route("api/questions")]
    [ApiController]
    public class QuestionController(IQuizService quizService) : ControllerBase
    {
        private readonly IQuizService _quizService = quizService;

        [HttpGet]
        public async Task<IActionResult> GetAllQuestions()
        {
            var questions = await _quizService.GetAllQuestionsAsync();
            return Ok(questions);
        }
    }
}
