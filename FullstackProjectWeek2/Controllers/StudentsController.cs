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
    public class StudentsController : ControllerBase
    {
        private readonly IStudent _student;
        private readonly IMapper _mapper;

        public StudentsController(IStudent student, IMapper mapper)
        {
            _student = student;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("Paging")]
        public async Task<IEnumerable<StudentReadDTO>> Paging([FromQuery] PaginationParams @params)
        {
            var results = await _student.Paging(@params);
            var studentReadDTO = _mapper.Map<IEnumerable<StudentReadDTO>>(results);
            return studentReadDTO;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<StudentReadDTO>> GetAll()
        {
            var results = await _student.GetAll();
            var studentReadDTOs = _mapper.Map<IEnumerable<StudentReadDTO>>(results);
            return studentReadDTOs;
        }

        [AllowAnonymous]
        [HttpGet("WithEnrollments")]
        public async Task<IEnumerable<StudentsWithEnrollmentsDTO>> GetStudentWithEnrollments()
        {
            var results = await _student.WithCourse();
            var studentsWithCourse = _mapper.Map<IEnumerable<StudentsWithEnrollmentsDTO>>(results);
            return studentsWithCourse;
        }

        [AllowAnonymous]
        [HttpGet("SearchStudent")]
        public async Task<ActionResult> Search(string name)
        {
            var results = await _student.SearchByName(name);
            if (results != null)
            {
                var readResults = _mapper.Map<IEnumerable<StudentReadDTO>>(results);
                return Ok(readResults);
            }
            else
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<StudentReadDTO> Get(int id)
        {
            var result = await _student.GetById(id);
            if (result == null) throw new Exception($"Student ID: {id} tidak ditemukan");
            var studentDTO = _mapper.Map<StudentReadDTO>(result);

            return studentDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Insert(StudentCreateDTO studentCreateDTO)
        {
            try
            {
                var newCourse = _mapper.Map<Student>(studentCreateDTO);
                var result = await _student.Insert(newCourse);
                var studentReadDTO = _mapper.Map<StudentReadDTO>(result);

                return CreatedAtAction("Get", new { id = result.ID }, studentReadDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(StudentCreateDTO studentCreateDTO, int id)
        {
            try
            {
                var updateStudent = new Student
                {
                    ID = id,
                    LastName = studentCreateDTO.LastName,
                    FirstMidName = studentCreateDTO.FirstMidName,
                };

                var result = await _student.Update(updateStudent);
                return Ok(studentCreateDTO);
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
                await _student.Delete(id);
                return Ok($"Student ID: {id} berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
