using FullstackProjectWeek2.Data.DAL.IRepository;
using FullstackProjectWeek2.Data.DAL.Pagination;
using FullstackProjectWeek2.Domain;
using Microsoft.EntityFrameworkCore;

namespace FullstackProjectWeek2.Data.DAL
{
    public class CourseDAL : ICourse
    {
        private readonly AppDbContext _context;

        public CourseDAL(AppDbContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            try
            {
                var deleteCourse = await _context.Courses.FirstOrDefaultAsync(c => c.CourseID == id);
                if (deleteCourse == null)
                {
                    throw new Exception($"Course ID: {id} tidak ditemuan");
                }

                _context.Courses.Remove(deleteCourse);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            try
            {
                var results = await _context.Courses.OrderBy(c => c.Title).ToListAsync();
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task<Course> GetById(int id)
        {
            try
            {
                var result = await _context.Courses.FirstOrDefaultAsync(c => c.CourseID == id);
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

        public async Task<Course> Insert(Course entity)
        {
            try
            {
                await _context.Courses.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Course>> Paging(PaginationParams @params)
        {
            var results = await _context.Courses
                .OrderBy(c => c.Title)
                .Skip((@params.Page - 1) * @params.ItemsPerPage)
                .Take(@params.ItemsPerPage)
                .ToArrayAsync();
            return results;
        }

        public async Task<IEnumerable<Course>> SearchByTitle(string title)
        {
            try
            {
                var results = await _context.Courses.Where(c => c.Title.Contains(title)).ToListAsync();
                if (results == null)
                {
                    throw new Exception($"Course {title} tidak ditemukan");
                }

                return results;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<Course> Update(Course entity)
        {
            try
            {
                var updateCourse = await _context.Courses.FirstOrDefaultAsync(c => c.CourseID == entity.CourseID);
                if (updateCourse == null)
                {
                    throw new Exception($"Course dengan ID: {entity.CourseID} tidak ditemukan");
                }
                updateCourse.Title = entity.Title;
                updateCourse.Credits = entity.Credits;

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