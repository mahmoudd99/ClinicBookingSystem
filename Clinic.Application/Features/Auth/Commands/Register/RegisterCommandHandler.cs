using AutoMapper;
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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public RegisterCommandHandler(UserManager<ApplicationUser> userManager , IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {

            var existingUser = await _userManager.FindByEmailAsync(request.Request.Email);

            if (existingUser != null)
            {
                throw new Exception("Email already exists.");
            }

            //var user = new ApplicationUser
            //{
            //    FirstName = request.Request.FirstName,
            //    LastName = request.Request.LastName,
            //    Email = request.Request.Email,
            //    UserName = request.Request.UserName
            //};
            var user = _mapper.Map<ApplicationUser>(request.Request);

            var result = await _userManager.CreateAsync(user, request.Request.Password);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(", ", result.Errors.Select(x => x.Description)));
            }

            return "User registered successfully.";


        }
    }
}
