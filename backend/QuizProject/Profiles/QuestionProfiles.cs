using AutoMapper;
using QuizProject.Application.Dto;
using QuizProject.Domain.Entities;

namespace QuizProject.API.Profiles
{
    public class QuestionProfiles : Profile
    {
        public QuestionProfiles()
        {
            //CreateMap<Question, QuestionDto>();
            //CreateMap<QuestionDto, Question>();

            CreateMap<Question, QuestionDto>()
                .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.Options))
                .ForMember(dest => dest.CorrectAnswers, opt => opt.MapFrom(src => src.CorrectAnswers));

            CreateMap<QuestionDto, Question>();

            CreateMap<QuestionOption, QuestionOptionDto>();

            CreateMap<CorrectAnswer, CorrectAnswerDto>();
        }
    }
}
