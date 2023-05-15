using attendaceAppWebApi.DTOs;
using attendaceAppWebApi.Interfaces;
using attendaceAppWebApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace attendaceAppWebApi.Repositories
{
    public class CollegeRepository : ICollegeRepository
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public CollegeRepository(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CollegeDto>> GetAllCollegesAsync()
        {
            var colleges = await _context.Colleges.ToListAsync();
            return _mapper.Map<IEnumerable<CollegeDto>>(colleges);
        }

        public async Task<CollegeDto> GetCollegeByIdAsync(int id)
        {
            var college = await _context.Colleges.FindAsync(id);
            return _mapper.Map<CollegeDto>(college);
        }

        public async Task<CollegeDto> CreateCollegeAsync(CollegeDto collegeDto)
        {
            var college = _mapper.Map<College>(collegeDto);
            _context.Colleges.Add(college);
            await _context.SaveChangesAsync();
            return _mapper.Map<CollegeDto>(college);
        }

        public async Task<CollegeDto> UpdateCollegeAsync(int id, CollegeDto collegeDto)
        {
            var existingCollege = await _context.Colleges.FindAsync(id);

            if (existingCollege == null)
            {
                return null;
            }

            existingCollege.CollegeName = collegeDto.CollegeName;
            existingCollege.Location = collegeDto.Location;
            existingCollege.PhoneNumber = collegeDto.PhoneNumber;

            _context.Colleges.Update(existingCollege);
            await _context.SaveChangesAsync();

            return _mapper.Map<CollegeDto>(existingCollege);
        }

        public async Task DeleteCollegeAsync(int id)
        {
            var collegeToDelete = await _context.Colleges.FindAsync(id);

            if (collegeToDelete == null)
            {
                return;
            }

            _context.Colleges.Remove(collegeToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
