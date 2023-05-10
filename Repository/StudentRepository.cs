using attendaceAppWebApi.Interfaces;
using attendaceAppWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace attendaceAppWebApi.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly MyDbContext _context;

        public StudentRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Student> AddStudentAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
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

        public async Task DeleteStudentAsync(int rollId)
        {
            var studentToDelete = await _context.Students
                                       .Where(r => r.RollNumber == rollId)
                                       .FirstOrDefaultAsync();

            if (studentToDelete == null)
            {
                return;
            }

            _context.Students.Remove(studentToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> StudentExistsAsync(int id)
        {
            return await _context.Students.AnyAsync(s => s.StudentId == id);
        }
    }
}
