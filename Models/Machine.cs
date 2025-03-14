using System.ComponentModel.DataAnnotations;

namespace BackendAPI.Models
{
    public class Machine : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(50)]
        public string ModelNumber { get; set; } = string.Empty;
        
        [MaxLength(50)]
        public string? SerialNumber { get; set; }
        
        [MaxLength(500)]
        public string? Description { get; set; }
        
        [MaxLength(100)]
        public string? Manufacturer { get; set; }
        
        public DateTime? ManufactureDate { get; set; }
        
        public DateTime? InstallationDate { get; set; }
        
        [MaxLength(100)]
        public string? Location { get; set; }
        
        [MaxLength(255)]
        public string? ImageUrl { get; set; }
        
        // Navigation properties
        public ICollection<BillOfMaterial> BillOfMaterials { get; set; } = new List<BillOfMaterial>();
    }
} 