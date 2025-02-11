using AutoMapper;
using QuizProject.Application.Dto;
using QuizProject.Domain.Entities;

namespace QuizProject.API.Profiles
{
    public class QuizScoreProfiles : Profile
    {
        public QuizScoreProfiles()
        {
            CreateMap<QuizResult, QuizResultDto>();
            CreateMap<QuizResultDto, QuizResult>();
        }
    }
}
