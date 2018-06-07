using System.Threading.Tasks;

namespace Cheers.NLog.Extensions.Layouts
{
    /// <summary>
    ///     请求协议
    /// </summary>
    public class ProtocolLayout : LayoutFieldBase
    {
        public override string ProviderFieldName => "protocol";
        public async override Task<string> ProviderField()
        {
            if (httpContext != null)
            {
                return httpContext.Request?.Protocol;
            }
            return string.Empty;
        }
    }
}
