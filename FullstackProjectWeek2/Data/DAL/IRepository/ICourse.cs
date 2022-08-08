using FullstackProjectWeek2.Data.DAL.Pagination;
using FullstackProjectWeek2.Domain;

namespace FullstackProjectWeek2.Data.DAL.IRepository
{
    public interface ICourse : ICrud<Course>
    {
        Task<IEnumerable<Course>> SearchByTitle(string title);
        Task<IEnumerable<Course>> Paging(PaginationParams @params);
    }
}
