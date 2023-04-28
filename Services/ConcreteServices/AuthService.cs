using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Data.Models;
using Data.RepositoriesAbstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.ServicesAbstractions;
using Utils.Dtos.Auth;

namespace Services.ConcreteServices
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly JwtSecurityTokenHandler _tokenHandler;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _tokenHandler = new JwtSecurityTokenHandler();
        }

        public string Login(LoginRequestDto loginRequestDto)
        {
            var user = _userRepository.GetByEmailAndPassword(loginRequestDto.Email, loginRequestDto.Password);

            if (user == null)
            {
                return string.Empty;
            }

            var token = GenerateToken(user);

            return token;
        }

        private string GenerateToken(User user)
        {
            var claims = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            });

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiresAt = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["Jwt:ExpireMinutes"]));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = expiresAt,
                SigningCredentials = credentials
            };

            var token = _tokenHandler.CreateToken(tokenDescriptor);

            return _tokenHandler.WriteToken(token);
        }
    }

}