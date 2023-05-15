using attendaceAppWebApi.DTOs;
using attendaceAppWebApi.Interfaces;
using attendanceAppWebApi.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace attendaceAppWebApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepository studentRepository, IUserRepository userRepository,IMapper mapper)
        {
            _studentRepository = studentRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<StudentShowDto>> GetAllStudents()
        {
            var students = await _studentRepository.GetAllStudentsAsync();
            var studentShowDtos = _mapper.Map<IEnumerable<StudentShowDto>>(students);
            return studentShowDtos;

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {

            var student = await _studentRepository.GetStudentByIdAsync(id);           
            
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentRegisterDto studentRegisterDto)
        {
            
            if (await _userRepository.UserExists(studentRegisterDto.Username))
                return BadRequest("Username already exists");


            return await _studentRepository.AddStudentAsync(studentRegisterDto);
        }

       
        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(int RollNumber)
        {
            var existingStudent = await _studentRepository.GetStudentByRollNumberAsync(RollNumber);

            if (existingStudent == null)
            {
                return NotFound();
            }

            await _studentRepository.DeleteStudentAsync(RollNumber);

            return NoContent();
        }

    }
}
