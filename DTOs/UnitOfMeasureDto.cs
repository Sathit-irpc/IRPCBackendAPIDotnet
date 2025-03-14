using System.ComponentModel.DataAnnotations;

namespace BackendAPI.DTOs
{
    public class UnitOfMeasureDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Abbreviation { get; set; } = string.Empty;
    }
    
    public class CreateUnitOfMeasureDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(10)]
        public string Abbreviation { get; set; } = string.Empty;
    }
    
    public class UpdateUnitOfMeasureDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(10)]
        public string Abbreviation { get; set; } = string.Empty;
    }
} 