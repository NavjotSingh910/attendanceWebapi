using attendaceAppWebApi.DTOs;
using attendaceAppWebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace attendaceAppWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollegesController : ControllerBase
    {
        private readonly ICollegeRepository _collegeRepository;

        public CollegesController(ICollegeRepository collegeRepository)
        {
            _collegeRepository = collegeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CollegeDto>>> GetAllColleges()
        {
            var colleges = await _collegeRepository.GetAllCollegesAsync();
            return Ok(colleges);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CollegeDto>> GetCollegeById(int id)
        {
            var college = await _collegeRepository.GetCollegeByIdAsync(id);

            if (college == null)
            {
                return NotFound();
            }

            return Ok(college);
        }

        [HttpPost]
        public async Task<ActionResult<CollegeDto>> CreateCollege(CollegeDto collegeDto)
        {
            var createdCollege = await _collegeRepository.CreateCollegeAsync(collegeDto);
            return CreatedAtAction(nameof(GetCollegeById), new { id = createdCollege.CollegeId }, createdCollege);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCollege(int id, CollegeDto collegeDto)
        {
            if (id != collegeDto.CollegeId)
            {
                return BadRequest();
            }

            var updatedCollege = await _collegeRepository.UpdateCollegeAsync(id, collegeDto);

            if (updatedCollege == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollege(int id)
        {
            await _collegeRepository.DeleteCollegeAsync(id);
            return NoContent();
        }
    }
}
