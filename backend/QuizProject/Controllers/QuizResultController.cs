using Microsoft.AspNetCore.Mvc;
using QuizProject.Application.Interfaces;

namespace QuizProject.API.Controllers
{
    [Route("api/scores")]
    [ApiController]
    public class QuizResultController(IQuizService quizService) : ControllerBase
    {
        private readonly IQuizService _quizService = quizService;

        [HttpGet]
        public async Task<IActionResult> GetAllScores()
        {
            var scores = await _quizService.GetAllScoresAsync();
            return Ok(scores);
        }
    }
}
