using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YogaStudio.Dtos;
using YogaStudio.Login;
using YogaStudio.Models;

namespace YogaStudio.Mapper
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<Week, WeekToReturn>();
            CreateMap<RegisterDto, User>();
            CreateMap<YogaLessonDto, YogaLesson>().ForMember(dest => dest.StartingTime,
                opt => opt.MapFrom(src => Convert.ToDateTime(src.StartingTime))).
                ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => Convert.ToDateTime(src.EndTime)));
        }
    }
}
