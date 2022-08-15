using AutoMapper;
using FullstackProjectWeek2.Data.DAL.IRepository;
using FullstackProjectWeek2.Domain;
using FullstackProjectWeek2.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullstackProjectWeek2.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollment _enrollment;
        private readonly IMapper _mapper;

        public EnrollmentsController(IEnrollment enrollment, IMapper mapper)
        {
            _enrollment = enrollment;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Insert(EnrollmentDTO EnrollmentDTO)
        {
            try
            {
                var enrol = _mapper.Map<Enrollment>(EnrollmentDTO);
                var result = await _enrollment.Insert(enrol);
                var EnrolmentDTO = _mapper.Map<EnrollmentDTO>(result);

                return CreatedAtAction(nameof(Insert), new { id = result.EnrollmentID }, EnrolmentDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<EnrollmentReadDTO>> GetAll()
        {
            var results = await _enrollment.GetAll();
            var enrollmentReadDTO = _mapper.Map<IEnumerable<EnrollmentReadDTO>>(results);
            return enrollmentReadDTO;
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<EnrollmentReadDTO> Get(int id)
        {
            var result = await _enrollment.GetById(id);
            if (result == null) throw new Exception($"Enrollment ID: {id} tidak ditemukan");
            var courseDTO = _mapper.Map<EnrollmentReadDTO>(result);

            return courseDTO;
        }
    }
}
