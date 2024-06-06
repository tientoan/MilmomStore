﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Milmom_Repository.BaseRepository;
using Milmom_Repository.IBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Milmom_Repository.IRepository;
using Milmom_Repository.Repository;
using MilmomStore_DataAccessObject;

namespace Milmom_Repository
{
    public static  class ConfigureService
    {
        public static IServiceCollection ConfigureRepositoryService(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddScoped<IAccountAppRepository, AccountAppRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IImageProductRepository, ImageProductRepository>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<AccountDAO>();
            services.AddScoped<ProductDAO>();
            services.AddScoped<ImageProductDAO>();
            //
            
            return services;
        }
    }
}