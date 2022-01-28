using HRLeaveManagement.Application.Profiles;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application
{
    // For Dependency injection.
    // When client calls a method, services will be registered
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            // Another way:
            // Registers MappingProfile as the AutoMapper configuration.
            // But for every mapping profile, this has to be repeated.
            // services.AddAutoMapper(typeof(MappingProfile));

            // Better way:
            // Will traverse through every mapping profile that has its inheritance
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
