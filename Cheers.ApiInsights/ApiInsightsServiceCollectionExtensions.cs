using Cheers.ApiInsights;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApiInsightsServiceCollectionExtensions
    {
        static readonly string stopWatchName = "__stopwatch__";
        static readonly string startTimeName = "__start__";

        /// <summary>
        ///     注册和 API 监控相关的服务，中间件
        /// </summary>
        /// <param name="services"></param>
        public static void AddApiInsights(this IServiceCollection services)
        {
            services.AddSingleton<IApiInsightsKeys>(
                    new ApiInsightsKeys(stopWatchName, startTimeName)
                );

            services.FirstRegister<IStartupFilter, RequestApiInsightBeginStartupFilter>(ServiceCollectionServiceExtensions.AddTransient<IStartupFilter, RequestApiInsightBeginStartupFilter>);
     
            services.AddSingleton<IRequestIsAuthenticate, DefaultRequestIsAuthenticate>();
        }
    }

    public static class ServiceCollectionExcenstions
    {
        public static void FirstRegister<TService, TImplementation>(this IServiceCollection services, RegisterService<TService, TImplementation> registerService)
            where TService : class
            where TImplementation : class, TService
        {
            IServiceCollection newServicesCollection = new ServiceCollection();
            int first = -1;

            for (int i = 0; i < services.Count; i++)
            {
                if (services[i].ServiceType == typeof(TService))
                {
                    first = i;
                    break;
                }
            }

            if(first == -1)
            {
                registerService(services);
            }
            else
            {
                foreach (var item in services)
                {
                    if(first-- == 0)
                    {
                        registerService(newServicesCollection);
                    }
                    newServicesCollection.Add(item);
                }

                services.Clear();

                foreach (var service in newServicesCollection)
                {
                    services.Add(service);
                }
            }
        }

        public delegate IServiceCollection RegisterService<TService, TImplementation>(IServiceCollection services)
            where TService : class
            where TImplementation : class, TService
            ;
    }
}
