using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Cheers.AspNetCore
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
}
