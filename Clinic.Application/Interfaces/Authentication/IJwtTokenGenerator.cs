using Clinic.Application.Features.Auth.DTOs;
using Clinic.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        Task<JwtResponse> GenerateToken(ApplicationUser user);
    }
}
