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
    public class SupplierController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SupplierController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Supplier
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierDto>>> GetSuppliers()
        {
            var suppliers = await _context.Suppliers
                .Where(s => !s.IsDeleted)
                .Select(s => new SupplierDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    ContactPerson = s.ContactPerson,
                    Phone = s.Phone,
                    Email = s.Email,
                    Address = s.Address,
                    Notes = s.Notes
                })
                .ToListAsync();

            return Ok(suppliers);
        }

        // GET: api/Supplier/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierDto>> GetSupplier(int id)
        {
            var supplier = await _context.Suppliers
                .Where(s => s.Id == id && !s.IsDeleted)
                .Select(s => new SupplierDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    ContactPerson = s.ContactPerson,
                    Phone = s.Phone,
                    Email = s.Email,
                    Address = s.Address,
                    Notes = s.Notes
                })
                .FirstOrDefaultAsync();

            if (supplier == null)
            {
                return NotFound();
            }

            return Ok(supplier);
        }

        // POST: api/Supplier
        [HttpPost]
        public async Task<ActionResult<SupplierDto>> CreateSupplier(CreateSupplierDto createSupplierDto)
        {
            var supplier = new Supplier
            {
                Name = createSupplierDto.Name,
                ContactPerson = createSupplierDto.ContactPerson,
                Phone = createSupplierDto.Phone,
                Email = createSupplierDto.Email,
                Address = createSupplierDto.Address,
                Notes = createSupplierDto.Notes,
                CreatedAt = DateTime.UtcNow
            };

            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();

            var supplierDto = new SupplierDto
            {
                Id = supplier.Id,
                Name = supplier.Name,
                ContactPerson = supplier.ContactPerson,
                Phone = supplier.Phone,
                Email = supplier.Email,
                Address = supplier.Address,
                Notes = supplier.Notes
            };

            return CreatedAtAction(nameof(GetSupplier), new { id = supplier.Id }, supplierDto);
        }

        // PUT: api/Supplier/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupplier(int id, UpdateSupplierDto updateSupplierDto)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null || supplier.IsDeleted)
            {
                return NotFound();
            }

            supplier.Name = updateSupplierDto.Name;
            supplier.ContactPerson = updateSupplierDto.ContactPerson;
            supplier.Phone = updateSupplierDto.Phone;
            supplier.Email = updateSupplierDto.Email;
            supplier.Address = updateSupplierDto.Address;
            supplier.Notes = updateSupplierDto.Notes;
            supplier.UpdatedAt = DateTime.UtcNow;

            _context.Entry(supplier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierExists(id))
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

        // DELETE: api/Supplier/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null || supplier.IsDeleted)
            {
                return NotFound();
            }

            // Soft delete
            supplier.IsDeleted = true;
            supplier.UpdatedAt = DateTime.UtcNow;

            _context.Entry(supplier).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SupplierExists(int id)
        {
            return _context.Suppliers.Any(e => e.Id == id && !e.IsDeleted);
        }
    }
} 