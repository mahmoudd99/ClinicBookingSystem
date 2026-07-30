using Clinic.Application.Interfaces.Persistence;
using Clinic.Infrastructure.Persistence.Context;
using Clinic.Infrastructure.Persistence.Repositories;
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

            services.AddScoped<IDoctorRepository, DoctorRepository>();

            return services;
        }



    }
}
