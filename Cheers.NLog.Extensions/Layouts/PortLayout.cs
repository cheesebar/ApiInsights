using System.Threading.Tasks;

namespace Cheers.NLog.Extensions.Layouts
{
    /// <summary>
    ///     请求端口
    /// </summary>
    public class PortLayout : LayoutFieldBase
    {
        public override string ProviderFieldName => "serverPort";
        public async override Task<string> ProviderField()
        {
            if (httpContext != null)
            {
                return httpContext?.Request?.Host.Port?.ToString();
            }
            return string.Empty;
        }
    }
}
