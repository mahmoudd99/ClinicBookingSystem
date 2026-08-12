using Clinic.Application.Exceptions;
using Clinic.Application.Features.Auth.DTOs;
using Clinic.Application.Interfaces.Authentication;
using Clinic.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Auth.Commands.RefreshToken
{


    public class RefreshTokenCommandHandler
        : IRequestHandler<
            RefreshTokenCommand,
            RefreshTokenResponseDto>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public RefreshTokenCommandHandler(
            UserManager<ApplicationUser> userManager,
            IJwtTokenGenerator jwtTokenGenerator)
        {
            _userManager = userManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<RefreshTokenResponseDto> Handle(
            RefreshTokenCommand request,
            CancellationToken cancellationToken)
        {
            var user = _userManager.Users
                .FirstOrDefault(x =>
                    x.RefreshToken == request.RefreshToken);

            if (user == null)
                throw new BusinessException("Invalid refresh token.");

            if (user.RefreshTokenExpiryTime == null ||
                user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                throw new BusinessException("Refresh token has expired.");
            }

            // Generate new Access Token
            var jwtResponse =
                await _jwtTokenGenerator.GenerateToken(user);

            // Generate new Refresh Token
            var newRefreshToken =
                Guid.NewGuid().ToString();

            user.SetRefreshToken(
                newRefreshToken,
                DateTime.UtcNow.AddDays(7));

            await _userManager.UpdateAsync(user);

            return new RefreshTokenResponseDto
            {
                AccessToken = jwtResponse.Token,
                RefreshToken = newRefreshToken
            };
        }
    } }





