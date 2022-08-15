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

        public async Task Delete(int id)
        {
            try
            {
                var deleteEnrollment = await _context.Enrollments.FirstOrDefaultAsync(e => e.EnrollmentID == id);
                if (deleteEnrollment == null)
                {
                    throw new Exception($"Enrollment ID: {id} tidak ditemuan");
                }

                _context.Enrollments.Remove(deleteEnrollment);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
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

        public async Task<Enrollment> Update(Enrollment entity)
        {
            try
            {
                var updateEnrollment = await _context.Enrollments.FirstOrDefaultAsync(e => e.EnrollmentID == entity.EnrollmentID);
                if (updateEnrollment == null)
                {
                    throw new Exception($"Enrollment dengan ID: {entity.EnrollmentID} tidak ditemukan");
                }
                updateEnrollment.StudentID = entity.StudentID;
                updateEnrollment.CourseID = entity.CourseID;
                updateEnrollment.Grade = entity.Grade;

                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
    }
}
