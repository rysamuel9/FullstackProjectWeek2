using FullstackProjectWeek2.Data.DAL.IRepository;
using FullstackProjectWeek2.Domain;

namespace FullstackProjectWeek2.Data.DAL
{
    public class EnrollmentDAL : IEnrollment
    {
        private readonly AppDbContext _context;

        public EnrollmentDAL(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Enrollment> Insert(Enrollment entity)
        {
            try
            {
                await _context.Enrollments.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }
    }
}
