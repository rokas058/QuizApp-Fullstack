using Microsoft.AspNetCore.Mvc;
using QuizProject.Application.Dto;
using QuizProject.Application.Interfaces;



namespace QuizProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController(IQuizService questionService) : ControllerBase
    {
        private readonly IQuizService _questionService = questionService;

        [HttpGet("questions")]
        public async Task<IActionResult> GetAllQuestions()
        {
            var questions = await _questionService.GetAllQuestionsAsync();
            return Ok(questions);
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitQuiz([FromBody] QuizSubmission submission)
        {
            var quizResult = await _questionService.SubmitQuizAsync(submission);
            return Ok(quizResult);
        }

        [HttpGet("scores")]
        public async Task<IActionResult> GetAllScores()
        {
            var scores = await _questionService.GetAllScoresAsync();
            return Ok(scores);
        }

    }
}
