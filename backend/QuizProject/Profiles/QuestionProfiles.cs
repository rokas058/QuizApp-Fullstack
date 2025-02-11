using AutoMapper;
using QuizProject.Application.Dto;
using QuizProject.Domain.Entities;

namespace QuizProject.API.Profiles
{
    public class QuestionProfiles : Profile
    {
        public QuestionProfiles()
        {
            CreateMap<Question, QuestionDto>();
            CreateMap<QuestionDto, Question>();
        }
    }
}
