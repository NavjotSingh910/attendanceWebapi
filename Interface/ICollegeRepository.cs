using attendaceAppWebApi.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace attendaceAppWebApi.Interfaces
{
    public interface ICollegeRepository
    {
        Task<IEnumerable<CollegeDto>> GetAllCollegesAsync();
        Task<CollegeDto> GetCollegeByIdAsync(int id);
        Task<CollegeDto> CreateCollegeAsync(CollegeDto collegeDto);
        Task<CollegeDto> UpdateCollegeAsync(int id, CollegeDto collegeDto);
        Task DeleteCollegeAsync(int id);
    }
}
