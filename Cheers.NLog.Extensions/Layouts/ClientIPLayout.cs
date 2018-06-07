using Cheers.NLog.Extensions.Internal;
using System.Threading.Tasks;

namespace Cheers.NLog.Extensions.Layouts
{
    /// <summary>
    ///     客户端IP
    /// </summary>
    public class ClientIPLayout : LayoutFieldBase
    {
        public override string ProviderFieldName => "clientIP";
        public async override Task<string> ProviderField()
        {
            if (httpContext != null)
            {
                var features = httpContext.Features;

                var clientIp = ReflectorHelper.GetProp<System.Net.IPAddress>(features, "RemoteIpAddress");

                return clientIp.ToString();
            }
            return string.Empty;
        }
    }
}
