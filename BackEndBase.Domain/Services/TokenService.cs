using BackEndBase.Domain.Bus;
using BackEndBase.Domain.Entities;
using BackEndBase.Domain.Interfaces.Services;
using BackEndBase.Domain.Services.Abstracts;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BackEndBase.Domain.Services
{
    public class TokenService : ServiceBase, ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration, IBus bus) : base(bus)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("JWT").GetSection("SecretKey").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.Name, user.Name),
                    new(ClaimTypes.Email, user.Email),
                    new(ClaimTypes.MobilePhone, user.Phone)
                }),

                Expires = DateTime.UtcNow.AddHours(Convert.ToDouble(_configuration.GetSection("JWT").GetSection("Expires").Value)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}