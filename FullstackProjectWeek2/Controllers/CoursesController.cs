using AutoMapper;
using FullstackProjectWeek2.Data.DAL.IRepository;
using FullstackProjectWeek2.Data.DAL.Pagination;
using FullstackProjectWeek2.Domain;
using FullstackProjectWeek2.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullstackProjectWeek2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourse _course;
        private readonly IMapper _mapper;

        public CoursesController(ICourse course, IMapper mapper)
        {
            _course = course;
            _mapper = mapper;
        }

        [HttpGet("Paging")]
        public async Task<IEnumerable<CourseReadDTO>> Paging([FromQuery] PaginationParams @params)
        {
            var results = await _course.Paging(@params);
            var courseReadDTOs = _mapper.Map<IEnumerable<CourseReadDTO>>(results);
            return courseReadDTOs;
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<CourseReadDTO>> GetAll()
        {
            var results = await _course.GetAll();
            var courseReadDTOs = _mapper.Map<IEnumerable<CourseReadDTO>>(results);
            return courseReadDTOs;
        }

        [HttpGet("SearchCourse")]
        public async Task<ActionResult> Search(string title)
        {
            var results = await _course.SearchByTitle(title);
            if (results != null)
            {
                var readResults = _mapper.Map<IEnumerable<CourseReadDTO>>(results);
                return Ok(readResults);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<CourseReadDTO> Get(int id)
        {
            var result = await _course.GetById(id);
            if (result == null) throw new Exception($"Course ID: {id} tidak ditemukan");
            var courseDTO = _mapper.Map<CourseReadDTO>(result);

            return courseDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Insert(CourseCreateDTO courseUpdateDTO)
        {
            try
            {
                var newCourse = _mapper.Map<Course>(courseUpdateDTO);
                var result = await _course.Insert(newCourse);
                var courseReadDTO = _mapper.Map<CourseReadDTO>(result);

                return CreatedAtAction("Get", new { id = result.CourseID }, courseReadDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(CourseCreateDTO courseUpdateDTO, int id)
        {
            try
            {
                var updateCourse = new Course
                {
                    CourseID = id,
                    Title = courseUpdateDTO.Title,
                    Credits = courseUpdateDTO.Credits,
                };

                var result = await _course.Update(updateCourse);
                return Ok(courseUpdateDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _course.Delete(id);
                return Ok($"Course dengan ID: {id} berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}