using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Transaction.Core.Interfaces;
using Transaction.Infrastructure.Persistence;
using Transaction.Infrastructure.Repositories;
using Transaction.Service.Mappers;
using Transaction.Service.Services;

namespace Transaction.Service.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddTransactionFramework(this IServiceCollection services, IConfiguration configuration)
        {
            // Service
            services.AddScoped<ITransactionService, TransactionService>();

            // Repository
            services.AddScoped<IAccountSummaryRepository, AccountSummaryRepository>();
            services.AddScoped<IAccountTransactionRepository, AccountTransactionRepository>();

            // Mappers
            services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));

            // Connection String
            services.AddDbContext<TransactionDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection")));

            return services;
        }
    }
}
