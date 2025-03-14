using System.ComponentModel.DataAnnotations;

namespace BackendAPI.Models
{
    public class Category : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [MaxLength(500)]
        public string? Description { get; set; }
        
        // Navigation properties
        public ICollection<Component> Components { get; set; } = new List<Component>();
    }
} 