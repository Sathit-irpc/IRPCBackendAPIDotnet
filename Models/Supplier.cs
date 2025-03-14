using System.ComponentModel.DataAnnotations;

namespace BackendAPI.Models
{
    public class Supplier : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [MaxLength(100)]
        public string? ContactPerson { get; set; }
        
        [MaxLength(50)]
        public string? Phone { get; set; }
        
        [MaxLength(100)]
        public string? Email { get; set; }
        
        [MaxLength(200)]
        public string? Address { get; set; }
        
        [MaxLength(500)]
        public string? Notes { get; set; }
        
        // Navigation properties
        public ICollection<Component> Components { get; set; } = new List<Component>();
    }
} 