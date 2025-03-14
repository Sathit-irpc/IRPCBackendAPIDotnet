using System.ComponentModel.DataAnnotations;

namespace BackendAPI.Models
{
    public class UnitOfMeasure : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(10)]
        public string Abbreviation { get; set; } = string.Empty;
        
        // Navigation properties
        public ICollection<Component> Components { get; set; } = new List<Component>();
    }
} 