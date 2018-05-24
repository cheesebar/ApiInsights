using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Cheers.ApiInsights
{
    public class RequestApiInsightBeginStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return builder =>
            {
                builder.UseMiddleware<ApiInsightMiddleware>();
                next(builder);
            };
        }
    }
}
