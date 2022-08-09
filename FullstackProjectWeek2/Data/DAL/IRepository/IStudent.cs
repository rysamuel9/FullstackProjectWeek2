using FullstackProjectWeek2.Data.DAL.Pagination;
using FullstackProjectWeek2.Domain;

namespace FullstackProjectWeek2.Data.DAL.IRepository
{
    public interface IStudent : ICrud<Student>
    {
        Task<IEnumerable<Student>> SearchByName(string name);
        Task<IEnumerable<Student>> Paging(PaginationParams @params);
        Task<IEnumerable<Student>> WithCourse();
    }
}
