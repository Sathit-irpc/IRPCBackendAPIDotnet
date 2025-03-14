using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendAPI.Models
{
    public class Component : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(50)]
        public string PartNumber { get; set; } = string.Empty;
        
        [MaxLength(500)]
        public string? Description { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        
        public int LeadTime { get; set; } // ระยะเวลาในการจัดหา (วัน)
        
        public int MinimumStock { get; set; } // จำนวนขั้นต่ำที่ควรมีในสต็อก
        
        [MaxLength(255)]
        public string? ImageUrl { get; set; }
        
        // Foreign keys
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        
        public int? UnitOfMeasureId { get; set; }
        public UnitOfMeasure? UnitOfMeasure { get; set; }
        
        public int? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
        
        // Navigation properties
        public ICollection<BillOfMaterial> ParentBOMs { get; set; } = new List<BillOfMaterial>();
        public ICollection<BillOfMaterial> ChildBOMs { get; set; } = new List<BillOfMaterial>();
    }
} 