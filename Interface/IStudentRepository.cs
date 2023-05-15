using attendaceAppWebApi.DTOs;
using attendaceAppWebApi.Models;
using attendanceAppWebApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace attendaceAppWebApi.Interfaces
{
    public interface IStudentRepository
    {
        Task<IActionResult> AddStudentAsync(StudentRegisterDto studentRegisterDto);
        Task<IEnumerable<StudentShowDto>> GetAllStudentsAsync();
        Task<StudentShowDto> GetStudentByIdAsync(int id);
        Task<StudentShowDto> GetStudentByRollNumberAsync(int rollNo);
        Task<IActionResult> DeleteStudentAsync(int rollNo);
        Task<bool> StudentExistsAsync(int id);
    }
}