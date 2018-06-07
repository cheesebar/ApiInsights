using Cheers.NLog.Extensions;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace Cheers.ApiInsights.NLog.Layouts
{
    /// <summary>
    ///     请求消耗的时间
    /// </summary>
    public class TimeLayout : LayoutFieldBase
    {
        public override string ProviderFieldName => "interval";

        public async override Task<string> ProviderField()
        {
            if (httpContext != null)
            {
                var _apiInsightsKeys = httpContext.RequestServices.GetService<IApiInsightsKeys>();

                if (httpContext != null)
                {
                    if (httpContext.Items.TryGetValue(_apiInsightsKeys.StopWatchName, out var stopWatch) == true)
                    {
                        return (stopWatch as Stopwatch).ElapsedMilliseconds.ToString();
                    }
                }
            }
            return string.Empty;
        }
    }
}
