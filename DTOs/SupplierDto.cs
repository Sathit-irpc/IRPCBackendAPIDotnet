using System.ComponentModel.DataAnnotations;

namespace BackendAPI.DTOs
{
    public class SupplierDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ContactPerson { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Notes { get; set; }
    }
    
    public class CreateSupplierDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [MaxLength(100)]
        public string? ContactPerson { get; set; }
        
        [MaxLength(50)]
        public string? Phone { get; set; }
        
        [MaxLength(100)]
        [EmailAddress]
        public string? Email { get; set; }
        
        [MaxLength(200)]
        public string? Address { get; set; }
        
        [MaxLength(500)]
        public string? Notes { get; set; }
    }
    
    public class UpdateSupplierDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [MaxLength(100)]
        public string? ContactPerson { get; set; }
        
        [MaxLength(50)]
        public string? Phone { get; set; }
        
        [MaxLength(100)]
        [EmailAddress]
        public string? Email { get; set; }
        
        [MaxLength(200)]
        public string? Address { get; set; }
        
        [MaxLength(500)]
        public string? Notes { get; set; }
    }
} 