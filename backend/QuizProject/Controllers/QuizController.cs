using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizProject.Models.Dto;
using QuizProject.Models.Entities;
using QuizProject.Services;

namespace QuizProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController(IQuizService questionService) : ControllerBase
    {
        private readonly IQuizService _questionService = questionService;

        [HttpGet("questions")]
        public async Task<IActionResult> GetAllQuestions()
        {
            var questions = await _questionService.GetAllQuestions();
            return Ok(questions);
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitQuiz([FromBody] QuizSubmission submission)
        { 
            var quizResult = await _questionService.SubmitQuiz(submission);
            return Ok(quizResult);
        }

        [HttpGet("scores")]
        public async Task<IActionResult> GetAllScores()
        {
            var scores = await _questionService.GetAllScores();
            return Ok(scores);
        }

    }
}
