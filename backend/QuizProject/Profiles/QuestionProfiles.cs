using AutoMapper;
using QuizProject.Models.Dto;
using QuizProject.Models.Entities;

namespace QuizProject.Profiles
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
