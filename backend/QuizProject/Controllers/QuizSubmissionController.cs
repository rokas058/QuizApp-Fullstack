using Microsoft.AspNetCore.Mvc;
using QuizProject.Application.Dto;
using QuizProject.Application.Interfaces;

namespace QuizProject.API.Controllers
{
    [Route("api/submit")]
    [ApiController]
    public class QuizSubmissionController(IQuizService quizService) : ControllerBase
    {
        private readonly IQuizService _quizService = quizService;

        [HttpPost]
        public async Task<IActionResult> SubmitQuiz([FromBody] QuizSubmission submission)
        {
            var quizResult = await _quizService.SubmitQuizAsync(submission);
            return Ok(quizResult);
        }

    }
}
