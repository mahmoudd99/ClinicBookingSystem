using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Clinic.Application.Features.Auth.DTOs;

public class JwtResponse
{
    public string Token { get; set; } = string.Empty;

    public DateTime ExpiresAt { get; set; }
}
