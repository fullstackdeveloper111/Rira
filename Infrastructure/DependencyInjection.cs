using Application.Caching;
using Domain.Users;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static void RegisterDependency(this IServiceCollection services)
        {
            services.AddSingleton<IConnectionMultiplexer>(
    ConnectionMultiplexer.Connect("localhost:6379"));
            services.AddScoped<ICacheManager, RedisCacheManager>();

        }
    }
}
