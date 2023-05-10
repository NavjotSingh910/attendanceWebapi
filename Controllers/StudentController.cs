using attendaceAppWebApi.DTOs;
using attendaceAppWebApi.Interfaces;
using attendaceAppWebApi.Models;
using attendanceAppWebApi.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            if (student == null)
                return NotFound();
            var studentShowDtos = _mapper.Map<IEnumerable<StudentShowDto>>(student);
            return Ok(studentShowDtos);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentRegisterDto studentRegisterDto)
        {
            UserRegistrationDto userForRegistrationDto=new UserRegistrationDto();
            userForRegistrationDto = _mapper.Map<UserRegistrationDto>(studentRegisterDto);
            userForRegistrationDto.RoleId = 3;
            if (await _userRepository.UserExists(userForRegistrationDto.Username))
                return BadRequest("Username already exists");

            // Create new user object
            var user = new User
            {
                Username = userForRegistrationDto.Username,
                RoleId = userForRegistrationDto.RoleId
            };

            // Register user with repository
            var registeredUser = await _userRepository.Register(user, userForRegistrationDto.Password);



            Student student = _mapper.Map<Student>(studentRegisterDto);
            student.UserId=registeredUser.UserId;
            

            await _studentRepository.AddStudentAsync(student);

            return CreatedAtAction(nameof(GetStudentById), new { id = student.StudentId }, student);
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int RollNumber)
        {
            var existingStudent = await _studentRepository.GetStudentByIdAsync(RollNumber);

            if (existingStudent == null)
            {
                return NotFound();
            }

            await _studentRepository.DeleteStudentAsync(RollNumber);

            return NoContent();
        }
    }
}
