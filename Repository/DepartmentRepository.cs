using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using attendaceAppWebApi.DTOs;
using attendaceAppWebApi.Interfaces;
using attendaceAppWebApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace attendaceAppWebApi.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public DepartmentRepository(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync()
        {
            List<Department> departments = await _context.Departments.ToListAsync();
            List<DepartmentDto> departmentDtos = _mapper.Map<List<DepartmentDto>>(departments);

            return departmentDtos;
        }

        public async Task<DepartmentDto> GetDepartmentByIdAsync(int id)
        {
            Department department = await _context.Departments.FindAsync(id);
            DepartmentDto departmentDto = _mapper.Map<DepartmentDto>(department);

            return departmentDto;
        }

        public async Task<DepartmentDto> CreateDepartmentAsync(DepartmentDto departmentDto)
        {
            Department department = _mapper.Map<Department>(departmentDto);

            _context.Departments.Add(department);
            await _context.SaveChangesAsync();

            DepartmentDto createdDepartmentDto = _mapper.Map<DepartmentDto>(department);
            return createdDepartmentDto;
        }

        public async Task<DepartmentDto> UpdateDepartmentAsync(int id, DepartmentDto departmentDto)
        {
            Department existingDepartment = await _context.Departments.FindAsync(id);

            if (existingDepartment == null)
            {
                return null;
            }

            _mapper.Map(departmentDto, existingDepartment);

            _context.Departments.Update(existingDepartment);
            await _context.SaveChangesAsync();

            DepartmentDto updatedDepartmentDto = _mapper.Map<DepartmentDto>(existingDepartment);
            return updatedDepartmentDto;
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            Department departmentToDelete = await _context.Departments.FindAsync(id);

            if (departmentToDelete == null)
            {
                return;
            }

            _context.Departments.Remove(departmentToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DepartmentExistsAsync(int id)
        {
            return await _context.Departments.AnyAsync(d => d.DepartmentId == id);
        }
    }
}
