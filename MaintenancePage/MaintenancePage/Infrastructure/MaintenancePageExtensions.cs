﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MaintenancePage.Infrastructure
{
    public static class MaintenancePageExtensions
    {
        public static IServiceCollection AddMaintenance(this IServiceCollection services, 
            MaintenancePage maintenancePage)
        {
            services.AddSingleton(maintenancePage);
            return services;
        }

        public static IServiceCollection AddMaintenance(this IServiceCollection services, 
            Func<bool> enabler, string handlerPath, string contentType = "text/html", 
            int retryAfterInSeconds = 3600)
        {
            AddMaintenance(services, new MaintenancePage(enabler, handlerPath)
            {
                ContentType = contentType,
                RetryAfterInSeconds = retryAfterInSeconds
            });

            return services;
        }

        public static IApplicationBuilder UseMaintenance(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MaintenanceMiddleware>();
        }
    }
}
