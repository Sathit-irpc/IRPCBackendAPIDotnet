using System.ComponentModel.DataAnnotations;

namespace BackendAPI.Models
{
    public class User : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public required string Username { get; set; }
        
        [Required]
        [StringLength(100)]
        public required string PasswordHash { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public required string Email { get; set; }
        
        [StringLength(100)]
        public required string FullName { get; set; }
        
        [Required]
        [StringLength(20)]
        public required string Role { get; set; } // "Admin", "Manager", "User"
        
        public bool IsActive { get; set; } = true;
        
        [StringLength(255)]
        public string? RefreshToken { get; set; } = null;
        
        public DateTime? RefreshTokenExpiryTime { get; set; } = null;
    }
} 