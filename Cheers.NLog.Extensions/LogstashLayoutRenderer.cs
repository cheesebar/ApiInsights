using Cheers.AspNetCore;
using Microsoft.AspNetCore.Http;
using NLog;
using NLog.LayoutRenderers;
using System.Text;
using System.Threading.Tasks;

namespace Cheers.NLog.Extensions
{
    /// <summary>
    ///     由于 <see cref="NLog.Targets.NetworkTarget"/> 没有提供 parameter 字段
    ///     为了更好的把数据组织到 logstash，我们可以在这里自定义字段最终以 json 传输到 logstash
    /// </summary>
    public abstract class LogstashLayoutRenderer : LayoutRenderer
    {
        protected HttpContext httpContext => HttpContextProvider.Current;

        protected async override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            builder.Append(await ProviderJson());
        }

        protected abstract Task<string> ProviderJson();
    }
}
