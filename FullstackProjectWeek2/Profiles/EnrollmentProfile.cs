using AutoMapper;
using FullstackProjectWeek2.Domain;
using FullstackProjectWeek2.DTO;

namespace FullstackProjectWeek2.Profiles
{
    public class EnrollmentProfile : Profile
    {
        public EnrollmentProfile()
        {
            CreateMap<Enrollment, EnrollmentDTO>();
            CreateMap<EnrollmentDTO, Enrollment>();
        }
    }
}
