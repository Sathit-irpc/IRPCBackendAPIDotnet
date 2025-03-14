using System.ComponentModel.DataAnnotations;

namespace BackendAPI.DTOs
{
    public class ComponentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PartNumber { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int LeadTime { get; set; }
        public int MinimumStock { get; set; }
        public string? ImageUrl { get; set; }
        
        // Related entities
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        
        public int? UnitOfMeasureId { get; set; }
        public string? UnitOfMeasureName { get; set; }
        public string? UnitOfMeasureAbbreviation { get; set; }
        
        public int? SupplierId { get; set; }
        public string? SupplierName { get; set; }
    }
    
    public class ComponentDetailDto : ComponentDto
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<ComponentBomDto> UsedInComponents { get; set; } = new List<ComponentBomDto>();
        public List<ComponentBomDto> ContainsComponents { get; set; } = new List<ComponentBomDto>();
    }
    
    public class ComponentBomDto
    {
        public int Id { get; set; }
        public int ComponentId { get; set; }
        public string ComponentName { get; set; } = string.Empty;
        public string PartNumber { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public string? UnitOfMeasureAbbreviation { get; set; }
    }
    
    public class CreateComponentDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(50)]
        public string PartNumber { get; set; } = string.Empty;
        
        [MaxLength(500)]
        public string? Description { get; set; }
        
        [Range(0, 9999999.99)]
        public decimal Price { get; set; }
        
        [Range(0, 999)]
        public int LeadTime { get; set; }
        
        [Range(0, 9999)]
        public int MinimumStock { get; set; }
        
        [MaxLength(255)]
        public string? ImageUrl { get; set; }
        
        public int? CategoryId { get; set; }
        public int? UnitOfMeasureId { get; set; }
        public int? SupplierId { get; set; }
    }
    
    public class UpdateComponentDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(50)]
        public string PartNumber { get; set; } = string.Empty;
        
        [MaxLength(500)]
        public string? Description { get; set; }
        
        [Range(0, 9999999.99)]
        public decimal Price { get; set; }
        
        [Range(0, 999)]
        public int LeadTime { get; set; }
        
        [Range(0, 9999)]
        public int MinimumStock { get; set; }
        
        [MaxLength(255)]
        public string? ImageUrl { get; set; }
        
        public int? CategoryId { get; set; }
        public int? UnitOfMeasureId { get; set; }
        public int? SupplierId { get; set; }
    }
} 