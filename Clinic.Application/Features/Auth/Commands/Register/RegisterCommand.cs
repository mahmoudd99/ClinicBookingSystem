using Clinic.Application.Features.Auth.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Auth.Commands.Register
{
    public class RegisterCommand : IRequest<string>
    {
        public RegisterRequest Request { get; set; } = new();
    }
}
