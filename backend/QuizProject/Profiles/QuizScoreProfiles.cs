using AutoMapper;
using QuizProject.Models.Dto;
using QuizProject.Models.Entities;

namespace QuizProject.Profiles
{
    public class QuizScoreProfiles : Profile
    {
        public QuizScoreProfiles() 
        {
            CreateMap<QuizResult,QuizResultDto>();
            CreateMap<QuizResultDto, QuizResult>();
        }
    }
}
