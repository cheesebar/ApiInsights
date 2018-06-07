using System.Threading.Tasks;

namespace Cheers.NLog.Extensions.Layouts
{
    /// <summary>
    ///     服务器主机
    /// </summary>
    public class HostLayout : LayoutFieldBase
    {
        public override string ProviderFieldName => "serverHost";
        public async override Task<string> ProviderField()
        {
            if (httpContext != null)
            {
                return httpContext?.Request?.Host.Host;
            }
            return string.Empty;
        }
    }
}
