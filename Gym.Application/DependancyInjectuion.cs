using Gym.Application.Interfaces.Services;
using Gym.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<ITrainerService, TrainerService>();
            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IMembershipPlanService, MembershipPlanService>();

            return services;
        }
    }

}
