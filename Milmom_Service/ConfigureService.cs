﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Milmom_Service.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Milmom_Service.IService;
using Milmom_Service.Service;

namespace Milmom_Service
{
    public static class ConfigureService
    {
        public static IServiceCollection ConfigureServiceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IAccountApplicationService, AccountApplicationService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IImageProductService, ImageProductService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICheckoutService, CheckoutService>();
            services.AddScoped<IVnPayService, VnPayService>();
            services.AddScoped<IRatingService, RatingService>();
            return services;
        }
    }
}
