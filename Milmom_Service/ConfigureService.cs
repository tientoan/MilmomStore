using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Milmom_Service.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service
{
    public static class ConfigureService
    {
        public static IServiceCollection ConfigureServiceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<ISlotService, SlotService>();
            return services;
        }
    }
}
