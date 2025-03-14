using System.ComponentModel.DataAnnotations;

namespace BackendAPI.DTOs
{
    public class BillOfMaterialDto
    {
        public int Id { get; set; }
        public int? MachineId { get; set; }
        public string? MachineName { get; set; }
        
        public int ParentComponentId { get; set; }
        public string ParentComponentName { get; set; } = string.Empty;
        public string ParentComponentPartNumber { get; set; } = string.Empty;
        
        public int ChildComponentId { get; set; }
        public string ChildComponentName { get; set; } = string.Empty;
        public string ChildComponentPartNumber { get; set; } = string.Empty;
        
        public decimal Quantity { get; set; }
        public string? UnitOfMeasureAbbreviation { get; set; }
        
        public string? Notes { get; set; }
        public int Level { get; set; }
    }
    
    public class CreateBillOfMaterialDto
    {
        public int? MachineId { get; set; }
        
        [Required]
        public int ParentComponentId { get; set; }
        
        [Required]
        public int ChildComponentId { get; set; }
        
        [Required]
        [Range(0.01, 9999999.99)]
        public decimal Quantity { get; set; }
        
        [MaxLength(500)]
        public string? Notes { get; set; }
        
        public int Level { get; set; }
    }
    
    public class UpdateBillOfMaterialDto
    {
        [Required]
        [Range(0.01, 9999999.99)]
        public decimal Quantity { get; set; }
        
        [MaxLength(500)]
        public string? Notes { get; set; }
        
        public int Level { get; set; }
    }
    
    public class BomTreeDto
    {
        public int ComponentId { get; set; }
        public string ComponentName { get; set; } = string.Empty;
        public string PartNumber { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public string? UnitOfMeasureAbbreviation { get; set; }
        public int Level { get; set; }
        public List<BomTreeDto> Children { get; set; } = new List<BomTreeDto>();
    }
} 