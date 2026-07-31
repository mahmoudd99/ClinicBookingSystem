using AutoMapper;
using Clinic.Application.Features.Auth.DTOs;
using Clinic.Application.Interfaces.Authentication;
using Clinic.Domain.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IAuthenticationService = Clinic.Application.Interfaces.Authentication.IAuthenticationService;

namespace Clinic.Infrastructure.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IMapper _mapper;

        public AuthenticationService(
           UserManager<ApplicationUser> userManager,
           SignInManager<ApplicationUser> signInManager,
           IJwtTokenGenerator jwtTokenGenerator,
           IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenGenerator = jwtTokenGenerator;
            _mapper = mapper;
        }

        public async Task<string> RegisterAsync(RegisterRequest request)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.Email);

            if (existingUser is not null)
            {
                throw new Exception("Email already exists.");
            }

            var user = _mapper.Map<ApplicationUser>(request);

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(", ", result.Errors.Select(x => x.Description)));
            }

            return "User registered successfully.";
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null)
            {
                throw new Exception("Invalid email or password.");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(
                user,
                request.Password,
                false);

            if (!result.Succeeded)
            {
                throw new Exception("Invalid email or password.");
            }

            
            var jwt = await _jwtTokenGenerator.GenerateToken(user);

            var roles = await _userManager.GetRolesAsync(user);

            return new AuthResponse
            {
                Success = true,
                Message = "Login successful.",

                Token = jwt.Token,
               

                UserId = user.Id,
                UserName = user.UserName!,
                Email = user.Email!,

                Roles = roles,

                ExpiresAt = jwt.ExpiresAt,
            };
        }
    }
}
