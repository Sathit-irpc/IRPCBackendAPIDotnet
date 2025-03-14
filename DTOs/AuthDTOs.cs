using System.ComponentModel.DataAnnotations;

namespace BackendAPI.DTOs
{
    public class RegisterDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public required string Username { get; set; }
        
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public required string Email { get; set; }
        
        [Required]
        [StringLength(100, MinimumLength = 6)]
        public required string Password { get; set; }
        
        [Required]
        [Compare("Password")]
        public required string ConfirmPassword { get; set; }
        
        [StringLength(100)]
        public required string FullName { get; set; }
        
        [StringLength(20)]
        public string Role { get; set; } = "User"; // Default role
    }
    
    public class LoginDTO
    {
        [Required]
        public required string Username { get; set; }
        
        [Required]
        public required string Password { get; set; }
    }
    
    public class AuthResponseDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public AuthResponseData? Data { get; set; }
        public object? Errors { get; set; }
    }

    public class AuthResponseData
    {
        public required string Token { get; set; }
        public required UserDTO User { get; set; }
    }

    public class UserDTO
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string FullName { get; set; }
        public required string Role { get; set; }
    }
    
    public class RefreshTokenDTO
    {
        [Required]
        public required string RefreshToken { get; set; }
    }
} 