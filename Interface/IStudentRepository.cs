using attendaceAppWebApi.DTOs;
using attendaceAppWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace attendaceAppWebApi.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student> AddStudentAsync(Student student);
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task<Student> UpdateStudentAsync(int id, Student student);
        Task DeleteStudentAsync(int id);
        Task<bool> StudentExistsAsync(int id);
    }
}
