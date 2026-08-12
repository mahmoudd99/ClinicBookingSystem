using Clinic.Application.Features.Auth.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommand
        : IRequest<RefreshTokenResponseDto>
    {
        public string RefreshToken { get; set; } = string.Empty;
    }
}
