using Cheers.ApiInsights;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Cheers.AspNetCore.Auth;
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
}
