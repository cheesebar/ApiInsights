using Cheers.NLog.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
namespace Cheers.ApiInsights.NLog.Layouts
{
    /// <summary>
    ///     请求到达的时间
    /// </summary>
    public class StartLayout : LayoutFieldBase
    {
        public override string ProviderFieldName => "start";

        public async override Task<string> ProviderField()
        {
            if (httpContext != null)
            {
                var _apiInsightsKeys = httpContext.RequestServices.GetService<IApiInsightsKeys>();

                if (httpContext != null)
                {
                    if (httpContext.Items.TryGetValue(_apiInsightsKeys.StartTimeName, out var start) == true)
                    {
                        return ((DateTime)start).ToString("yyyy/MM/dd hh:mm:ss");
                    }
                }
            }
            return string.Empty;
        }
    }
}
