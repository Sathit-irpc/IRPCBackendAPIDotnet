using System.ComponentModel.DataAnnotations;

namespace BackendAPI.DTOs
{
    public class MachineDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ModelNumber { get; set; } = string.Empty;
        public string? SerialNumber { get; set; }
        public string? Description { get; set; }
        public string? Manufacturer { get; set; }
        public DateTime? ManufactureDate { get; set; }
        public DateTime? InstallationDate { get; set; }
        public string? Location { get; set; }
        public string? ImageUrl { get; set; }
    }
    
    public class MachineDetailDto : MachineDto
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<ComponentBomDto> Components { get; set; } = new List<ComponentBomDto>();
    }
    
    public class CreateMachineDto
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
    }
    
    public class UpdateMachineDto
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
    }
} 