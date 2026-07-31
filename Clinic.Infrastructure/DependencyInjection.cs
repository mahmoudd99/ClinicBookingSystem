using Clinic.Application.Interfaces.Persistence;
using Clinic.Domain.Identity;
using Clinic.Infrastructure.Persistence.Context;
using Clinic.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


            services.AddScoped<IDoctorRepository, DoctorRepository>();

            return services;
        }



    }
}
