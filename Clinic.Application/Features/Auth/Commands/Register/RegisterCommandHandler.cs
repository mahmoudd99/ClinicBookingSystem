using AutoMapper;
using Clinic.Application.Interfaces.Authentication;
using Clinic.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Auth.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, string>
    {
        private readonly IAuthenticationService _authenticationService;

        public RegisterCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            return await _authenticationService.RegisterAsync(request.Request);
        }
    }
}

