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
    public class ComponentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ComponentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Component
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComponentDto>>> GetComponents()
        {
            var components = await _context.Components
                .Where(c => !c.IsDeleted)
                .Include(c => c.Category)
                .Include(c => c.UnitOfMeasure)
                .Include(c => c.Supplier)
                .Select(c => new ComponentDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    PartNumber = c.PartNumber,
                    Description = c.Description,
                    Price = c.Price,
                    LeadTime = c.LeadTime,
                    MinimumStock = c.MinimumStock,
                    ImageUrl = c.ImageUrl,
                    CategoryId = c.CategoryId,
                    CategoryName = c.Category != null ? c.Category.Name : null,
                    UnitOfMeasureId = c.UnitOfMeasureId,
                    UnitOfMeasureName = c.UnitOfMeasure != null ? c.UnitOfMeasure.Name : null,
                    UnitOfMeasureAbbreviation = c.UnitOfMeasure != null ? c.UnitOfMeasure.Abbreviation : null,
                    SupplierId = c.SupplierId,
                    SupplierName = c.Supplier != null ? c.Supplier.Name : null
                })
                .ToListAsync();

            return Ok(components);
        }

        // GET: api/Component/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComponentDetailDto>> GetComponent(int id)
        {
            var component = await _context.Components
                .Where(c => c.Id == id && !c.IsDeleted)
                .Include(c => c.Category)
                .Include(c => c.UnitOfMeasure)
                .Include(c => c.Supplier)
                .Select(c => new ComponentDetailDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    PartNumber = c.PartNumber,
                    Description = c.Description,
                    Price = c.Price,
                    LeadTime = c.LeadTime,
                    MinimumStock = c.MinimumStock,
                    ImageUrl = c.ImageUrl,
                    CategoryId = c.CategoryId,
                    CategoryName = c.Category != null ? c.Category.Name : null,
                    UnitOfMeasureId = c.UnitOfMeasureId,
                    UnitOfMeasureName = c.UnitOfMeasure != null ? c.UnitOfMeasure.Name : null,
                    UnitOfMeasureAbbreviation = c.UnitOfMeasure != null ? c.UnitOfMeasure.Abbreviation : null,
                    SupplierId = c.SupplierId,
                    SupplierName = c.Supplier != null ? c.Supplier.Name : null,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                })
                .FirstOrDefaultAsync();

            if (component == null)
            {
                return NotFound();
            }

            // Get components where this component is used (parent relationships)
            var usedInComponents = await _context.BillOfMaterials
                .Where(b => b.ChildComponentId == id && !b.IsDeleted)
                .Include(b => b.ParentComponent)
                .Include(b => b.ChildComponent.UnitOfMeasure)
                .Select(b => new ComponentBomDto
                {
                    Id = b.Id,
                    ComponentId = b.ParentComponentId,
                    ComponentName = b.ParentComponent.Name,
                    PartNumber = b.ParentComponent.PartNumber,
                    Quantity = b.Quantity,
                    UnitOfMeasureAbbreviation = b.ChildComponent.UnitOfMeasure != null ? b.ChildComponent.UnitOfMeasure.Abbreviation : null
                })
                .ToListAsync();

            component.UsedInComponents = usedInComponents;

            // Get components that this component contains (child relationships)
            var containsComponents = await _context.BillOfMaterials
                .Where(b => b.ParentComponentId == id && !b.IsDeleted)
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

            component.ContainsComponents = containsComponents;

            return Ok(component);
        }

        // POST: api/Component
        [HttpPost]
        public async Task<ActionResult<ComponentDto>> CreateComponent(CreateComponentDto createComponentDto)
        {
            var component = new Component
            {
                Name = createComponentDto.Name,
                PartNumber = createComponentDto.PartNumber,
                Description = createComponentDto.Description,
                Price = createComponentDto.Price,
                LeadTime = createComponentDto.LeadTime,
                MinimumStock = createComponentDto.MinimumStock,
                ImageUrl = createComponentDto.ImageUrl,
                CategoryId = createComponentDto.CategoryId,
                UnitOfMeasureId = createComponentDto.UnitOfMeasureId,
                SupplierId = createComponentDto.SupplierId,
                CreatedAt = DateTime.UtcNow
            };

            _context.Components.Add(component);
            await _context.SaveChangesAsync();

            var componentDto = new ComponentDto
            {
                Id = component.Id,
                Name = component.Name,
                PartNumber = component.PartNumber,
                Description = component.Description,
                Price = component.Price,
                LeadTime = component.LeadTime,
                MinimumStock = component.MinimumStock,
                ImageUrl = component.ImageUrl,
                CategoryId = component.CategoryId,
                UnitOfMeasureId = component.UnitOfMeasureId,
                SupplierId = component.SupplierId
            };

            return CreatedAtAction(nameof(GetComponent), new { id = component.Id }, componentDto);
        }

        // PUT: api/Component/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComponent(int id, UpdateComponentDto updateComponentDto)
        {
            var component = await _context.Components.FindAsync(id);
            if (component == null || component.IsDeleted)
            {
                return NotFound();
            }

            component.Name = updateComponentDto.Name;
            component.PartNumber = updateComponentDto.PartNumber;
            component.Description = updateComponentDto.Description;
            component.Price = updateComponentDto.Price;
            component.LeadTime = updateComponentDto.LeadTime;
            component.MinimumStock = updateComponentDto.MinimumStock;
            component.ImageUrl = updateComponentDto.ImageUrl;
            component.CategoryId = updateComponentDto.CategoryId;
            component.UnitOfMeasureId = updateComponentDto.UnitOfMeasureId;
            component.SupplierId = updateComponentDto.SupplierId;
            component.UpdatedAt = DateTime.UtcNow;

            _context.Entry(component).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComponentExists(id))
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

        // DELETE: api/Component/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComponent(int id)
        {
            var component = await _context.Components.FindAsync(id);
            if (component == null || component.IsDeleted)
            {
                return NotFound();
            }

            // Check if component is used in any BOM
            var isUsedInBom = await _context.BillOfMaterials
                .AnyAsync(b => (b.ParentComponentId == id || b.ChildComponentId == id) && !b.IsDeleted);

            if (isUsedInBom)
            {
                return BadRequest("Cannot delete component because it is used in a Bill of Materials");
            }

            // Soft delete
            component.IsDeleted = true;
            component.UpdatedAt = DateTime.UtcNow;

            _context.Entry(component).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComponentExists(int id)
        {
            return _context.Components.Any(e => e.Id == id && !e.IsDeleted);
        }
    }
} 