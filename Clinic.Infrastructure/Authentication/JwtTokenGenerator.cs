using Clinic.Application.Configurations;
using Clinic.Application.Features.Auth.DTOs;
using Clinic.Application.Interfaces.Authentication;
using Clinic.Domain.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Infrastructure.Authentication
{

    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtSettings _jwtSettings;

        public JwtTokenGenerator(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public Task<JwtResponse> GenerateToken(ApplicationUser user)
        {
            var claims = new List<Claim>
{
    new Claim(JwtRegisteredClaimNames.Sub, user.Id),
    new Claim(JwtRegisteredClaimNames.Email, user.Email!),
    new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName!)
};

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            return Task.FromResult(new JwtResponse
            {
                Token = tokenHandler.WriteToken(token),
                ExpiresAt = token.ValidTo
            });

        }
    }
}
