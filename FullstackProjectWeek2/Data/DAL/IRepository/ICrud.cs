namespace FullstackProjectWeek2.Data.DAL.IRepository
{
    public interface ICrud<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task Delete(int id);
    }
}
