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
    public class BillOfMaterialController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BillOfMaterialController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BillOfMaterial
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillOfMaterialDto>>> GetBillOfMaterials()
        {
            var boms = await _context.BillOfMaterials
                .Where(b => !b.IsDeleted)
                .Include(b => b.Machine)
                .Include(b => b.ParentComponent)
                .Include(b => b.ChildComponent)
                .Include(b => b.ChildComponent.UnitOfMeasure)
                .Select(b => new BillOfMaterialDto
                {
                    Id = b.Id,
                    MachineId = b.MachineId,
                    MachineName = b.Machine != null ? b.Machine.Name : null,
                    ParentComponentId = b.ParentComponentId,
                    ParentComponentName = b.ParentComponent.Name,
                    ParentComponentPartNumber = b.ParentComponent.PartNumber,
                    ChildComponentId = b.ChildComponentId,
                    ChildComponentName = b.ChildComponent.Name,
                    ChildComponentPartNumber = b.ChildComponent.PartNumber,
                    Quantity = b.Quantity,
                    UnitOfMeasureAbbreviation = b.ChildComponent.UnitOfMeasure != null ? b.ChildComponent.UnitOfMeasure.Abbreviation : null,
                    Notes = b.Notes,
                    Level = b.Level
                })
                .ToListAsync();

            return Ok(boms);
        }

        // GET: api/BillOfMaterial/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BillOfMaterialDto>> GetBillOfMaterial(int id)
        {
            var bom = await _context.BillOfMaterials
                .Where(b => b.Id == id && !b.IsDeleted)
                .Include(b => b.Machine)
                .Include(b => b.ParentComponent)
                .Include(b => b.ChildComponent)
                .Include(b => b.ChildComponent.UnitOfMeasure)
                .Select(b => new BillOfMaterialDto
                {
                    Id = b.Id,
                    MachineId = b.MachineId,
                    MachineName = b.Machine != null ? b.Machine.Name : null,
                    ParentComponentId = b.ParentComponentId,
                    ParentComponentName = b.ParentComponent.Name,
                    ParentComponentPartNumber = b.ParentComponent.PartNumber,
                    ChildComponentId = b.ChildComponentId,
                    ChildComponentName = b.ChildComponent.Name,
                    ChildComponentPartNumber = b.ChildComponent.PartNumber,
                    Quantity = b.Quantity,
                    UnitOfMeasureAbbreviation = b.ChildComponent.UnitOfMeasure != null ? b.ChildComponent.UnitOfMeasure.Abbreviation : null,
                    Notes = b.Notes,
                    Level = b.Level
                })
                .FirstOrDefaultAsync();

            if (bom == null)
            {
                return NotFound();
            }

            return Ok(bom);
        }

        // GET: api/BillOfMaterial/Machine/5
        [HttpGet("Machine/{machineId}")]
        public async Task<ActionResult<IEnumerable<BillOfMaterialDto>>> GetBillOfMaterialsByMachine(int machineId)
        {
            var boms = await _context.BillOfMaterials
                .Where(b => b.MachineId == machineId && !b.IsDeleted)
                .Include(b => b.Machine)
                .Include(b => b.ParentComponent)
                .Include(b => b.ChildComponent)
                .Include(b => b.ChildComponent.UnitOfMeasure)
                .Select(b => new BillOfMaterialDto
                {
                    Id = b.Id,
                    MachineId = b.MachineId,
                    MachineName = b.Machine != null ? b.Machine.Name : null,
                    ParentComponentId = b.ParentComponentId,
                    ParentComponentName = b.ParentComponent.Name,
                    ParentComponentPartNumber = b.ParentComponent.PartNumber,
                    ChildComponentId = b.ChildComponentId,
                    ChildComponentName = b.ChildComponent.Name,
                    ChildComponentPartNumber = b.ChildComponent.PartNumber,
                    Quantity = b.Quantity,
                    UnitOfMeasureAbbreviation = b.ChildComponent.UnitOfMeasure != null ? b.ChildComponent.UnitOfMeasure.Abbreviation : null,
                    Notes = b.Notes,
                    Level = b.Level
                })
                .ToListAsync();

            return Ok(boms);
        }

        // GET: api/BillOfMaterial/Component/5
        [HttpGet("Component/{componentId}")]
        public async Task<ActionResult<IEnumerable<BillOfMaterialDto>>> GetBillOfMaterialsByComponent(int componentId)
        {
            var boms = await _context.BillOfMaterials
                .Where(b => (b.ParentComponentId == componentId || b.ChildComponentId == componentId) && !b.IsDeleted)
                .Include(b => b.Machine)
                .Include(b => b.ParentComponent)
                .Include(b => b.ChildComponent)
                .Include(b => b.ChildComponent.UnitOfMeasure)
                .Select(b => new BillOfMaterialDto
                {
                    Id = b.Id,
                    MachineId = b.MachineId,
                    MachineName = b.Machine != null ? b.Machine.Name : null,
                    ParentComponentId = b.ParentComponentId,
                    ParentComponentName = b.ParentComponent.Name,
                    ParentComponentPartNumber = b.ParentComponent.PartNumber,
                    ChildComponentId = b.ChildComponentId,
                    ChildComponentName = b.ChildComponent.Name,
                    ChildComponentPartNumber = b.ChildComponent.PartNumber,
                    Quantity = b.Quantity,
                    UnitOfMeasureAbbreviation = b.ChildComponent.UnitOfMeasure != null ? b.ChildComponent.UnitOfMeasure.Abbreviation : null,
                    Notes = b.Notes,
                    Level = b.Level
                })
                .ToListAsync();

            return Ok(boms);
        }

        // GET: api/BillOfMaterial/Tree/Machine/5
        [HttpGet("Tree/Machine/{machineId}")]
        public async Task<ActionResult<List<BomTreeDto>>> GetBomTreeByMachine(int machineId)
        {
            var machine = await _context.Machines.FindAsync(machineId);
            if (machine == null || machine.IsDeleted)
            {
                return NotFound();
            }

            // Get all BOMs for this machine
            var allBoms = await _context.BillOfMaterials
                .Where(b => b.MachineId == machineId && !b.IsDeleted)
                .Include(b => b.ParentComponent)
                .Include(b => b.ChildComponent)
                .Include(b => b.ChildComponent.UnitOfMeasure)
                .ToListAsync();

            // Get root level components (Level = 0)
            var rootBoms = allBoms.Where(b => b.Level == 0).ToList();

            var result = new List<BomTreeDto>();

            foreach (var rootBom in rootBoms)
            {
                var rootNode = new BomTreeDto
                {
                    ComponentId = rootBom.ChildComponentId,
                    ComponentName = rootBom.ChildComponent.Name,
                    PartNumber = rootBom.ChildComponent.PartNumber,
                    Quantity = rootBom.Quantity,
                    UnitOfMeasureAbbreviation = rootBom.ChildComponent.UnitOfMeasure?.Abbreviation,
                    Level = rootBom.Level
                };

                // Build the tree recursively
                BuildBomTree(rootNode, allBoms);

                result.Add(rootNode);
            }

            return Ok(result);
        }

        // GET: api/BillOfMaterial/Tree/Component/5
        [HttpGet("Tree/Component/{componentId}")]
        public async Task<ActionResult<BomTreeDto>> GetBomTreeByComponent(int componentId)
        {
            var component = await _context.Components.FindAsync(componentId);
            if (component == null || component.IsDeleted)
            {
                return NotFound();
            }

            // Get all BOMs where this component is a parent
            var allBoms = await _context.BillOfMaterials
                .Where(b => b.ParentComponentId == componentId && !b.IsDeleted)
                .Include(b => b.ParentComponent)
                .Include(b => b.ChildComponent)
                .Include(b => b.ChildComponent.UnitOfMeasure)
                .ToListAsync();

            var rootNode = new BomTreeDto
            {
                ComponentId = componentId,
                ComponentName = component.Name,
                PartNumber = component.PartNumber,
                Quantity = 1, // Root component has quantity 1
                UnitOfMeasureAbbreviation = component.UnitOfMeasure?.Abbreviation,
                Level = 0
            };

            // Build the tree recursively
            BuildBomTree(rootNode, allBoms);

            return Ok(rootNode);
        }

        // POST: api/BillOfMaterial
        [HttpPost]
        public async Task<ActionResult<BillOfMaterialDto>> CreateBillOfMaterial(CreateBillOfMaterialDto createBillOfMaterialDto)
        {
            // Validate parent and child components
            var parentComponent = await _context.Components.FindAsync(createBillOfMaterialDto.ParentComponentId);
            if (parentComponent == null || parentComponent.IsDeleted)
            {
                return BadRequest("Parent component not found");
            }

            var childComponent = await _context.Components.FindAsync(createBillOfMaterialDto.ChildComponentId);
            if (childComponent == null || childComponent.IsDeleted)
            {
                return BadRequest("Child component not found");
            }

            // Validate machine if provided
            if (createBillOfMaterialDto.MachineId.HasValue)
            {
                var machine = await _context.Machines.FindAsync(createBillOfMaterialDto.MachineId.Value);
                if (machine == null || machine.IsDeleted)
                {
                    return BadRequest("Machine not found");
                }
            }

            // Check for circular reference
            if (createBillOfMaterialDto.ParentComponentId == createBillOfMaterialDto.ChildComponentId)
            {
                return BadRequest("Cannot add a component to itself");
            }

            // Check if this relationship already exists
            var existingBom = await _context.BillOfMaterials
                .AnyAsync(b => b.ParentComponentId == createBillOfMaterialDto.ParentComponentId &&
                               b.ChildComponentId == createBillOfMaterialDto.ChildComponentId &&
                               b.MachineId == createBillOfMaterialDto.MachineId &&
                               !b.IsDeleted);

            if (existingBom)
            {
                return BadRequest("This relationship already exists");
            }

            var bom = new BillOfMaterial
            {
                MachineId = createBillOfMaterialDto.MachineId,
                ParentComponentId = createBillOfMaterialDto.ParentComponentId,
                ChildComponentId = createBillOfMaterialDto.ChildComponentId,
                Quantity = createBillOfMaterialDto.Quantity,
                Notes = createBillOfMaterialDto.Notes,
                Level = createBillOfMaterialDto.Level,
                CreatedAt = DateTime.UtcNow
            };

            _context.BillOfMaterials.Add(bom);
            await _context.SaveChangesAsync();

            // Load related entities for the response
            await _context.Entry(bom).Reference(b => b.Machine).LoadAsync();
            await _context.Entry(bom).Reference(b => b.ParentComponent).LoadAsync();
            await _context.Entry(bom).Reference(b => b.ChildComponent).LoadAsync();
            if (bom.ChildComponent.UnitOfMeasureId.HasValue)
            {
                await _context.Entry(bom.ChildComponent).Reference(c => c.UnitOfMeasure).LoadAsync();
            }

            var bomDto = new BillOfMaterialDto
            {
                Id = bom.Id,
                MachineId = bom.MachineId,
                MachineName = bom.Machine?.Name,
                ParentComponentId = bom.ParentComponentId,
                ParentComponentName = bom.ParentComponent.Name,
                ParentComponentPartNumber = bom.ParentComponent.PartNumber,
                ChildComponentId = bom.ChildComponentId,
                ChildComponentName = bom.ChildComponent.Name,
                ChildComponentPartNumber = bom.ChildComponent.PartNumber,
                Quantity = bom.Quantity,
                UnitOfMeasureAbbreviation = bom.ChildComponent.UnitOfMeasure?.Abbreviation,
                Notes = bom.Notes,
                Level = bom.Level
            };

            return CreatedAtAction(nameof(GetBillOfMaterial), new { id = bom.Id }, bomDto);
        }

        // PUT: api/BillOfMaterial/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBillOfMaterial(int id, UpdateBillOfMaterialDto updateBillOfMaterialDto)
        {
            var bom = await _context.BillOfMaterials.FindAsync(id);
            if (bom == null || bom.IsDeleted)
            {
                return NotFound();
            }

            bom.Quantity = updateBillOfMaterialDto.Quantity;
            bom.Notes = updateBillOfMaterialDto.Notes;
            bom.Level = updateBillOfMaterialDto.Level;
            bom.UpdatedAt = DateTime.UtcNow;

            _context.Entry(bom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillOfMaterialExists(id))
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

        // DELETE: api/BillOfMaterial/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBillOfMaterial(int id)
        {
            var bom = await _context.BillOfMaterials.FindAsync(id);
            if (bom == null || bom.IsDeleted)
            {
                return NotFound();
            }

            // Soft delete
            bom.IsDeleted = true;
            bom.UpdatedAt = DateTime.UtcNow;

            _context.Entry(bom).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BillOfMaterialExists(int id)
        {
            return _context.BillOfMaterials.Any(e => e.Id == id && !e.IsDeleted);
        }

        private void BuildBomTree(BomTreeDto parentNode, List<BillOfMaterial> allBoms)
        {
            // Find all child components of the current parent
            var childBoms = allBoms.Where(b => b.ParentComponentId == parentNode.ComponentId).ToList();

            foreach (var childBom in childBoms)
            {
                var childNode = new BomTreeDto
                {
                    ComponentId = childBom.ChildComponentId,
                    ComponentName = childBom.ChildComponent.Name,
                    PartNumber = childBom.ChildComponent.PartNumber,
                    Quantity = childBom.Quantity,
                    UnitOfMeasureAbbreviation = childBom.ChildComponent.UnitOfMeasure?.Abbreviation,
                    Level = childBom.Level
                };

                // Recursively build the tree for this child
                BuildBomTree(childNode, allBoms);

                // Add the child to the parent's children list
                parentNode.Children.Add(childNode);
            }
        }
    }
} 