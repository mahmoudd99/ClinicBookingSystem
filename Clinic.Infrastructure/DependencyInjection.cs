using Clinic.Application.Configurations;
using Clinic.Application.Interfaces.Authentication;
using Clinic.Application.Interfaces.Persistence;
using Clinic.Domain.Identity;
using Clinic.Infrastructure.Authentication;
using Clinic.Infrastructure.Persistence.Context;
using Clinic.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationService = Clinic.Infrastructure.Authentication.AuthenticationService;
using IAuthenticationService = Clinic.Application.Interfaces.Authentication.IAuthenticationService;

namespace Clinic.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure( this IServiceCollection services , IConfiguration configuration)
        {

            services.AddDbContext<ClinicDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;

                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<ClinicDbContext>()
                .AddDefaultTokenProviders();
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IMedicalRecordRepository, MedicalRecordRepository>();
            services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();

            return services;
        }



    }
}
