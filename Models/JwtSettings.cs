namespace BackendAPI.Models
{
    public class JwtSettings
    {
        public required string Key { get; set; }
        public required string Issuer { get; set; }
        public required string Audience { get; set; }
        public int ExpiryMinutes { get; set; }
        public int RefreshTokenValidityInDays { get; set; }
    }
} 