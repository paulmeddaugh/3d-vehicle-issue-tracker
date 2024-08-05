using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _3d_vehicle_issue_tracker.Models.CarIssue;

// To generate controller:
// dotnet aspnet-codegenerator controller -name CarIssuesController -async -api -m CarIssue -dc CarIssueContext -outDir Controllers

// from tutorial: https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio-code

namespace _3d_vehicle_issue_tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarIssuesController : ControllerBase
    {
        private readonly CarIssueContext _context;

        public CarIssuesController(CarIssueContext context)
        {
            _context = context;
        }

        // GET: api/CarIssues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarIssueDTO>>> GetCarIssues()
        {
            return await _context.CarIssues
                .Select(issue => CarIssueDTO.From(issue))
                .ToListAsync();
        }

        // GET: api/CarIssues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarIssueDTO>> GetCarIssue(long id)
        {
            var carIssue = await _context.CarIssues.FindAsync(id);

            if (carIssue == null)
            {
                return NotFound();
            }

            return CarIssueDTO.From(carIssue);
        }

        // PUT: api/CarIssues/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("update/{id}")]
        public async Task<IActionResult> UpdateCarIssue(long id, CarIssueDTO carIssueDTO)
        {
            if (id != carIssueDTO.Id)
            {
                return BadRequest();
            }

            var carIssue = await _context.CarIssues.FindAsync(id);
            if (carIssue == null) {
                return NotFound();
            }
            // _context.Entry(carIssueDTO).State = EntityState.Modified;
            carIssue.UpdateFromDTO(carIssueDTO);

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) when (!CarIssueExists(id)) {
                return NotFound();
            } catch (DbUpdateConcurrencyException) {
                throw;
            }

            return NoContent();
        }

        // POST: api/CarIssues
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarIssueDTO>> NewCarIssue(CarIssueDTO carIssueDTO)
        {
            var carIssue = CarIssue.From(carIssueDTO);
            _context.CarIssues.Add(carIssue);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCarIssue), new { id = carIssue.Id }, CarIssueDTO.From(carIssue));
        }

        // DELETE: api/CarIssues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarIssue(long id)
        {
            var carIssue = await _context.CarIssues.FindAsync(id);
            if (carIssue == null)
            {
                return NotFound();
            }

            _context.CarIssues.Remove(carIssue);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarIssueExists(long id)
        {
            return _context.CarIssues.Any(e => e.Id == id);
        }
    }
}
