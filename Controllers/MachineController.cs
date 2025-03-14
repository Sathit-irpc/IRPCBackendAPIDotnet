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
    public class MachineController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MachineController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Machine
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MachineDto>>> GetMachines()
        {
            var machines = await _context.Machines
                .Where(m => !m.IsDeleted)
                .Select(m => new MachineDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    ModelNumber = m.ModelNumber,
                    SerialNumber = m.SerialNumber,
                    Description = m.Description,
                    Manufacturer = m.Manufacturer,
                    ManufactureDate = m.ManufactureDate,
                    InstallationDate = m.InstallationDate,
                    Location = m.Location,
                    ImageUrl = m.ImageUrl
                })
                .ToListAsync();

            return Ok(machines);
        }

        // GET: api/Machine/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MachineDetailDto>> GetMachine(int id)
        {
            var machine = await _context.Machines
                .Where(m => m.Id == id && !m.IsDeleted)
                .Select(m => new MachineDetailDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    ModelNumber = m.ModelNumber,
                    SerialNumber = m.SerialNumber,
                    Description = m.Description,
                    Manufacturer = m.Manufacturer,
                    ManufactureDate = m.ManufactureDate,
                    InstallationDate = m.InstallationDate,
                    Location = m.Location,
                    ImageUrl = m.ImageUrl,
                    CreatedAt = m.CreatedAt,
                    UpdatedAt = m.UpdatedAt
                })
                .FirstOrDefaultAsync();

            if (machine == null)
            {
                return NotFound();
            }

            // Get components for this machine
            var components = await _context.BillOfMaterials
                .Where(b => b.MachineId == id && !b.IsDeleted)
                .Include(b => b.ChildComponent)
                .Include(b => b.ChildComponent.UnitOfMeasure)
                .Select(b => new ComponentBomDto
                {
                    Id = b.Id,
                    ComponentId = b.ChildComponentId,
                    ComponentName = b.ChildComponent.Name,
                    PartNumber = b.ChildComponent.PartNumber,
                    Quantity = b.Quantity,
                    UnitOfMeasureAbbreviation = b.ChildComponent.UnitOfMeasure != null ? b.ChildComponent.UnitOfMeasure.Abbreviation : null
                })
                .ToListAsync();

            machine.Components = components;

            return Ok(machine);
        }

        // POST: api/Machine
        [HttpPost]
        public async Task<ActionResult<MachineDto>> CreateMachine(CreateMachineDto createMachineDto)
        {
            var machine = new Machine
            {
                Name = createMachineDto.Name,
                ModelNumber = createMachineDto.ModelNumber,
                SerialNumber = createMachineDto.SerialNumber,
                Description = createMachineDto.Description,
                Manufacturer = createMachineDto.Manufacturer,
                ManufactureDate = createMachineDto.ManufactureDate,
                InstallationDate = createMachineDto.InstallationDate,
                Location = createMachineDto.Location,
                ImageUrl = createMachineDto.ImageUrl,
                CreatedAt = DateTime.UtcNow
            };

            _context.Machines.Add(machine);
            await _context.SaveChangesAsync();

            var machineDto = new MachineDto
            {
                Id = machine.Id,
                Name = machine.Name,
                ModelNumber = machine.ModelNumber,
                SerialNumber = machine.SerialNumber,
                Description = machine.Description,
                Manufacturer = machine.Manufacturer,
                ManufactureDate = machine.ManufactureDate,
                InstallationDate = machine.InstallationDate,
                Location = machine.Location,
                ImageUrl = machine.ImageUrl
            };

            return CreatedAtAction(nameof(GetMachine), new { id = machine.Id }, machineDto);
        }

        // PUT: api/Machine/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMachine(int id, UpdateMachineDto updateMachineDto)
        {
            var machine = await _context.Machines.FindAsync(id);
            if (machine == null || machine.IsDeleted)
            {
                return NotFound();
            }

            machine.Name = updateMachineDto.Name;
            machine.ModelNumber = updateMachineDto.ModelNumber;
            machine.SerialNumber = updateMachineDto.SerialNumber;
            machine.Description = updateMachineDto.Description;
            machine.Manufacturer = updateMachineDto.Manufacturer;
            machine.ManufactureDate = updateMachineDto.ManufactureDate;
            machine.InstallationDate = updateMachineDto.InstallationDate;
            machine.Location = updateMachineDto.Location;
            machine.ImageUrl = updateMachineDto.ImageUrl;
            machine.UpdatedAt = DateTime.UtcNow;

            _context.Entry(machine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MachineExists(id))
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

        // DELETE: api/Machine/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMachine(int id)
        {
            var machine = await _context.Machines.FindAsync(id);
            if (machine == null || machine.IsDeleted)
            {
                return NotFound();
            }

            // Check if machine is used in any BOM
            var isUsedInBom = await _context.BillOfMaterials
                .AnyAsync(b => b.MachineId == id && !b.IsDeleted);

            if (isUsedInBom)
            {
                return BadRequest("Cannot delete machine because it has Bill of Materials associated with it");
            }

            // Soft delete
            machine.IsDeleted = true;
            machine.UpdatedAt = DateTime.UtcNow;

            _context.Entry(machine).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MachineExists(int id)
        {
            return _context.Machines.Any(e => e.Id == id && !e.IsDeleted);
        }
    }
} 