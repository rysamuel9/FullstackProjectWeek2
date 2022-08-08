using AutoMapper;
using FullstackProjectWeek2.Domain;
using FullstackProjectWeek2.DTO;

namespace FullstackProjectWeek2.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseCreateDTO>();
            CreateMap<CourseCreateDTO, Course>();

            CreateMap<Course, CourseReadDTO>();
            CreateMap<CourseReadDTO, Course>();
        }
    }
}
