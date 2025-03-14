using System.Security.Claims;
using BackendAPI.Data;
using BackendAPI.DTOs;
using BackendAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BackendAPI.Services
{
    public class AuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtService _jwtService;
        private readonly JwtSettings _jwtSettings;
        
        public AuthService(ApplicationDbContext context, JwtService jwtService, IOptions<JwtSettings> jwtSettings)
        {
            _context = context;
            _jwtService = jwtService;
            _jwtSettings = jwtSettings.Value;
        }
        
        public async Task<AuthResponseDTO> RegisterAsync(RegisterDTO registerDto)
        {
            try
            {
                // Check if username already exists
                if (await _context.Users.AnyAsync(u => u.Username == registerDto.Username))
                {
                    return new AuthResponseDTO
                    {
                        Success = false,
                        Message = "Username already exists",
                        Errors = new { Username = "Username already exists" }
                    };
                }
                
                // Check if email already exists
                if (await _context.Users.AnyAsync(u => u.Email == registerDto.Email))
                {
                    return new AuthResponseDTO
                    {
                        Success = false,
                        Message = "Email already exists",
                        Errors = new { Email = "Email already exists" }
                    };
                }
                
                // Create new user
                var user = new User
                {
                    Username = registerDto.Username,
                    Email = registerDto.Email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password),
                    FullName = registerDto.FullName,
                    Role = registerDto.Role,
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                };
                
                // Add user to database
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                
                // Generate tokens
                var token = _jwtService.GenerateJwtToken(user);
                var refreshToken = _jwtService.GenerateRefreshToken();
                
                // Save refresh token
                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenValidityInDays);
                await _context.SaveChangesAsync();
                
                // Return response
                return new AuthResponseDTO
                {
                    Success = true,
                    Message = "Registration successful",
                    Data = new AuthResponseData
                    {
                        Token = token,
                        User = new UserDTO
                        {
                            Id = user.Id,
                            Username = user.Username,
                            Email = user.Email,
                            FullName = user.FullName,
                            Role = user.Role
                        }
                    }
                };
            }
            catch (Exception ex)
            {
                return new AuthResponseDTO
                {
                    Success = false,
                    Message = "Registration failed",
                    Errors = new { Error = ex.Message }
                };
            }
        }
        
        public async Task<AuthResponseDTO> LoginAsync(LoginDTO loginDto)
        {
            try
            {
                // Find user by username
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == loginDto.Username);
                
                // Check if user exists
                if (user == null)
                {
                    return new AuthResponseDTO
                    {
                        Success = false,
                        Message = "Invalid username or password",
                        Errors = new { Credentials = "Invalid username or password" }
                    };
                }
                
                // Check if user is active
                if (!user.IsActive)
                {
                    return new AuthResponseDTO
                    {
                        Success = false,
                        Message = "User account is disabled",
                        Errors = new { Account = "User account is disabled" }
                    };
                }
                
                // Verify password
                if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
                {
                    return new AuthResponseDTO
                    {
                        Success = false,
                        Message = "Invalid username or password",
                        Errors = new { Credentials = "Invalid username or password" }
                    };
                }
                
                // Generate tokens
                var token = _jwtService.GenerateJwtToken(user);
                var refreshToken = _jwtService.GenerateRefreshToken();
                
                // Save refresh token
                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenValidityInDays);
                await _context.SaveChangesAsync();
                
                // Return response
                return new AuthResponseDTO
                {
                    Success = true,
                    Message = "Login successful",
                    Data = new AuthResponseData
                    {
                        Token = token,
                        User = new UserDTO
                        {
                            Id = user.Id,
                            Username = user.Username,
                            Email = user.Email,
                            FullName = user.FullName,
                            Role = user.Role
                        }
                    }
                };
            }
            catch (Exception ex)
            {
                return new AuthResponseDTO
                {
                    Success = false,
                    Message = "Login failed",
                    Errors = new { Error = ex.Message }
                };
            }
        }
        
        public async Task<AuthResponseDTO> RefreshTokenAsync(string token, string refreshToken)
        {
            try
            {
                var principal = _jwtService.GetPrincipalFromExpiredToken(token);
                var userId = int.Parse(principal.FindFirstValue(ClaimTypes.NameIdentifier)!);
                
                var user = await _context.Users.FindAsync(userId);
                
                if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
                {
                    return new AuthResponseDTO
                    {
                        Success = false,
                        Message = "Invalid refresh token",
                        Errors = new { Token = "Invalid refresh token" }
                    };
                }
                
                var newToken = _jwtService.GenerateJwtToken(user);
                var newRefreshToken = _jwtService.GenerateRefreshToken();
                
                user.RefreshToken = newRefreshToken;
                user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenValidityInDays);
                await _context.SaveChangesAsync();
                
                return new AuthResponseDTO
                {
                    Success = true,
                    Message = "Token refreshed successfully",
                    Data = new AuthResponseData
                    {
                        Token = newToken,
                        User = new UserDTO
                        {
                            Id = user.Id,
                            Username = user.Username,
                            Email = user.Email,
                            FullName = user.FullName,
                            Role = user.Role
                        }
                    }
                };
            }
            catch (Exception ex)
            {
                return new AuthResponseDTO
                {
                    Success = false,
                    Message = "Token refresh failed",
                    Errors = new { Error = ex.Message }
                };
            }
        }
        
        public async Task RevokeTokenAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            
            if (user == null)
            {
                throw new Exception("User not found");
            }
            
            user.RefreshToken = null;
            user.RefreshTokenExpiryTime = null;
            await _context.SaveChangesAsync();
        }
    }
} 