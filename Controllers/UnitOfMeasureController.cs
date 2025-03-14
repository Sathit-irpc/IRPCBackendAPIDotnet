using BackendAPI.Data;
using BackendAPI.DTOs;
using BackendAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UnitOfMeasureController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UnitOfMeasureController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UnitOfMeasure
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitOfMeasureDto>>> GetUnitOfMeasures()
        {
            var unitOfMeasures = await _context.UnitOfMeasures
                .Where(u => !u.IsDeleted)
                .Select(u => new UnitOfMeasureDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Abbreviation = u.Abbreviation
                })
                .ToListAsync();

            return Ok(unitOfMeasures);
        }

        // GET: api/UnitOfMeasure/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnitOfMeasureDto>> GetUnitOfMeasure(int id)
        {
            var unitOfMeasure = await _context.UnitOfMeasures
                .Where(u => u.Id == id && !u.IsDeleted)
                .Select(u => new UnitOfMeasureDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Abbreviation = u.Abbreviation
                })
                .FirstOrDefaultAsync();

            if (unitOfMeasure == null)
            {
                return NotFound();
            }

            return Ok(unitOfMeasure);
        }

        // POST: api/UnitOfMeasure
        [HttpPost]
        public async Task<ActionResult<UnitOfMeasureDto>> CreateUnitOfMeasure(CreateUnitOfMeasureDto createUnitOfMeasureDto)
        {
            var unitOfMeasure = new UnitOfMeasure
            {
                Name = createUnitOfMeasureDto.Name,
                Abbreviation = createUnitOfMeasureDto.Abbreviation,
                CreatedAt = DateTime.UtcNow
            };

            _context.UnitOfMeasures.Add(unitOfMeasure);
            await _context.SaveChangesAsync();

            var unitOfMeasureDto = new UnitOfMeasureDto
            {
                Id = unitOfMeasure.Id,
                Name = unitOfMeasure.Name,
                Abbreviation = unitOfMeasure.Abbreviation
            };

            return CreatedAtAction(nameof(GetUnitOfMeasure), new { id = unitOfMeasure.Id }, unitOfMeasureDto);
        }

        // PUT: api/UnitOfMeasure/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUnitOfMeasure(int id, UpdateUnitOfMeasureDto updateUnitOfMeasureDto)
        {
            var unitOfMeasure = await _context.UnitOfMeasures.FindAsync(id);
            if (unitOfMeasure == null || unitOfMeasure.IsDeleted)
            {
                return NotFound();
            }

            unitOfMeasure.Name = updateUnitOfMeasureDto.Name;
            unitOfMeasure.Abbreviation = updateUnitOfMeasureDto.Abbreviation;
            unitOfMeasure.UpdatedAt = DateTime.UtcNow;

            _context.Entry(unitOfMeasure).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitOfMeasureExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/UnitOfMeasure/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnitOfMeasure(int id)
        {
            var unitOfMeasure = await _context.UnitOfMeasures.FindAsync(id);
            if (unitOfMeasure == null || unitOfMeasure.IsDeleted)
            {
                return NotFound();
            }

            // Soft delete
            unitOfMeasure.IsDeleted = true;
            unitOfMeasure.UpdatedAt = DateTime.UtcNow;

            _context.Entry(unitOfMeasure).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UnitOfMeasureExists(int id)
        {
            return _context.UnitOfMeasures.Any(e => e.Id == id && !e.IsDeleted);
        }
    }
} 