using Cheers.NLog.Extensions.Internal;
using System.Threading.Tasks;

namespace Cheers.NLog.Extensions.Layouts
{
    /// <summary>
    ///     服务器IP
    /// </summary>
    public class ServerIPLayout : LayoutFieldBase
    {
        public override string ProviderFieldName => "serverIP";
        public async override Task<string> ProviderField()
        {
            if (httpContext != null)
            {
                var features = httpContext.Features;
                var serverIp = ReflectorHelper.GetProp<System.Net.IPAddress>(features, "LocalIpAddress");

                return serverIp.ToString();
            }
            return string.Empty;
        }
    }
}
