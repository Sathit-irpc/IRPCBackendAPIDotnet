using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendAPI.Models
{
    public class BillOfMaterial : BaseEntity
    {
        // Foreign keys
        public int? MachineId { get; set; }
        public Machine? Machine { get; set; }
        
        public int ParentComponentId { get; set; }
        public Component ParentComponent { get; set; } = null!;
        
        public int ChildComponentId { get; set; }
        public Component ChildComponent { get; set; } = null!;
        
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Quantity { get; set; }
        
        [MaxLength(500)]
        public string? Notes { get; set; }
        
        // ระดับของชิ้นส่วนในโครงสร้าง BOM (Level 0 = เครื่องจักรหลัก, Level 1 = ชิ้นส่วนหลัก, Level 2+ = ชิ้นส่วนย่อย)
        public int Level { get; set; }
    }
} 