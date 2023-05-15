using attendaceAppWebApi.DTOs;
using attendaceAppWebApi.Interfaces;
using attendaceAppWebApi.Models;
using attendanceAppWebApi.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace attendaceAppWebApi.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly MyDbContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public StudentRepository(MyDbContext context, IUserRepository userRepository, IMapper mapper)
        {
            _context = context;
            _userRepository = userRepository;
            _mapper = mapper;
        }

 

        public async Task<IEnumerable<StudentShowDto>> GetAllStudentsAsync()
        {
            List<Student> students = await _context.Students.ToListAsync();
            List<StudentShowDto> studentShowDto = _mapper.Map<List<StudentShowDto>>(students);

            return studentShowDto;
        }


        public async Task<StudentShowDto> GetStudentByIdAsync(int id)
        {
            
            return  _mapper.Map<StudentShowDto>(await _context.Students.FindAsync(id));
        }

        public async Task<Student> UpdateStudentAsync(int id, Student student)
        {
            var existingStudent = await _context.Students.FindAsync(id);

            if (existingStudent == null)
            {
                return null;
            }

            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.Email = student.Email;

            _context.Students.Update(existingStudent);
            await _context.SaveChangesAsync();

            return existingStudent;
        }

        public async Task<IActionResult> DeleteStudentAsync(int rollId)
        {
            var studentToDelete = await _context.Students.FirstOrDefaultAsync(s => s.RollNumber == rollId);

            if (studentToDelete == null)
            {
                return new NotFoundResult();
            }

            _context.Students.Remove(studentToDelete);
            await _context.SaveChangesAsync();

            return new OkResult(); // or any other appropriate IActionResult
        }


        public async Task<bool> StudentExistsAsync(int id)
        {
            return await _context.Students.AnyAsync(s => s.StudentId == id);
        }

        public async Task<IActionResult> AddStudentAsync(StudentRegisterDto studentRegisterDto)
        {
            UserRegistrationDto userForRegistrationDto = _mapper.Map<UserRegistrationDto>(studentRegisterDto);
            userForRegistrationDto.RoleId = 3;
            var registeredUser = await _userRepository.Register(userForRegistrationDto);

            Student student = _mapper.Map<Student>(studentRegisterDto);
            student.UserId = registeredUser.UserId;
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();

            return new OkResult(); // or any other appropriate IActionResult
        }

        public async Task<StudentShowDto> GetStudentByRollNumberAsync(int rollNo)
        {
            
            return _mapper.Map<StudentShowDto>(await _context.Students.FirstOrDefaultAsync(s => s.RollNumber == rollNo));
        }
    }
}
