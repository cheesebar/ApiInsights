using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cheers.ApiInsights
{
    public static class HttpContextProvider
    {
        private static IHttpContextAccessor _accessor;
        private static IServiceScopeFactory _serviceScopeFactory;

        public static Microsoft.AspNetCore.Http.HttpContext Current
        {
            get
            {
                var context = _accessor?.HttpContext;

                if (context != null)
                {
                    var replacementFeature = new RequestServicesFeature(_serviceScopeFactory);
                    context.Features.Set<IServiceProvidersFeature>(replacementFeature);

                    return context;
                }

                return null;
            }
        }

        internal static void ConfigureAccessor(IHttpContextAccessor accessor, IServiceScopeFactory serviceScopeFactory)
        {
            _accessor = accessor;
            _serviceScopeFactory = serviceScopeFactory;
        }
    }
    public static class HttpContextExtenstion
    {
        public static void AddHttpContextAccessor(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public static IApplicationBuilder UseGlobalHttpContext(this IApplicationBuilder app)
        {
            var httpContextAccessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
            var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            HttpContextProvider.ConfigureAccessor(httpContextAccessor, serviceScopeFactory);
            return app;
        }
    }
}
