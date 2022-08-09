using FullstackProjectWeek2.Data.DAL.IRepository;
using FullstackProjectWeek2.Domain;
using Microsoft.EntityFrameworkCore;

namespace FullstackProjectWeek2.Data.DAL
{
    public class StudentDAL : IStudent
    {
        private readonly AppDbContext _context;

        public StudentDAL(AppDbContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            try
            {
                var deleteStudent = await _context.Students.FirstOrDefaultAsync(s => s.ID == id);
                if (deleteStudent == null)
                {
                    throw new Exception($"Student ID: {id} tidak ditemuan");
                }

                _context.Students.Remove(deleteStudent);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            try
            {
                var results = await _context.Students.OrderBy(s => s.FirstMidName).ToListAsync();
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task<Student> GetById(int id)
        {
            try
            {
                var result = await _context.Students.FirstOrDefaultAsync(s => s.ID == id);
                if (result == null)
                {
                    throw new Exception($"Course ID {id} tidak ditemukan");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<Student> Insert(Student entity)
        {
            try
            {
                await _context.Students.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task<Student> Update(Student entity)
        {
            try
            {
                var updateStudent = await _context.Students.FirstOrDefaultAsync(s => s.ID == entity.ID);
                if (updateStudent == null)
                {
                    throw new Exception($"Student ID: {entity.ID} tidak ditemukan");
                }
                updateStudent.LastName = entity.LastName;
                updateStudent.FirstMidName = entity.FirstMidName;

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
