using FullstackProjectWeek2.Domain;

namespace FullstackProjectWeek2.Data.DAL.IRepository
{
    public interface IEnrollment
    {
        Task<Enrollment> Insert(Enrollment entity);
    }
}
