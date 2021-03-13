using Microsoft.Extensions.DependencyInjection;
using NotificatUtility.Factories;
using NotificatUtility.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotificatUtility.Module
{
    /// <summary>
    /// Module for adding dependencies for libary
    /// </summary>
    public static class NotificationConfigs
    {
        /// <summary>
        /// Method for adding notification dependencies
        /// </summary>
        /// <param name="services">service collection</param>
        /// <returns>collection with added services</returns>
        public static IServiceCollection AddNotificationService(
             this IServiceCollection services)
        {
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<ISmtpService, SmtpService>();
            services.AddScoped<INotificationBuilder, NotificationBuilder>();

            return services;
        }
    }
}