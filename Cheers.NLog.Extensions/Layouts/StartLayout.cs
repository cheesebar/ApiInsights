using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Cheers.NLog.Extensions.Layouts
{
    /// <summary>
    ///     请求到达的时间
    /// </summary>
    public class StartLayout : LayoutBase
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
                        return start.ToString();
                    }
                }
            }
            return string.Empty;
        }
    }
}
