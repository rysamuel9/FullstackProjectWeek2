using AutoMapper;
using FullstackProjectWeek2.Domain;
using FullstackProjectWeek2.DTO;

namespace FullstackProjectWeek2.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentCreateDTO>();
            CreateMap<StudentCreateDTO, Student>();

            CreateMap<Student, StudentReadDTO>();
            CreateMap<StudentReadDTO, Student>();

            CreateMap<Student, StudentsWithEnrollmentsDTO>();
            CreateMap<StudentsWithEnrollmentsDTO, Student>();

            CreateMap<Student, EnrollmentReadDTO>();
            CreateMap<EnrollmentReadDTO, Student>();
        }
    }
}
