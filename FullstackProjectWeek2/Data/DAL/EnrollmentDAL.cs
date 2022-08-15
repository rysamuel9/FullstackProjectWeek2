using FullstackProjectWeek2.Data.DAL.IRepository;
using FullstackProjectWeek2.Domain;
using Microsoft.EntityFrameworkCore;

namespace FullstackProjectWeek2.Data.DAL
{
    public class EnrollmentDAL : IEnrollment
    {
        private readonly AppDbContext _context;

        public EnrollmentDAL(AppDbContext context)
        {
            _context = context;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Enrollment>> GetAll()
        {
            try
            {
                var results = await _context.Enrollments.OrderBy(e => e.StudentID).ToListAsync();
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task<Enrollment> GetById(int id)
        {
            try
            {
                var result = await _context.Enrollments.FirstOrDefaultAsync(e => e.EnrollmentID == id);
                if (result == null)
                {
                    throw new Exception($"Enrollment ID {id} tidak ditemukan");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
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

        public Task<Enrollment> Update(Enrollment entity)
        {
            throw new NotImplementedException();
        }
    }
}
