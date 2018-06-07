using System.Threading.Tasks;

namespace Cheers.NLog.Extensions.Layouts
{
    /// <summary>
    ///     服务器
    /// </summary>
    public class ServerLayout : LayoutFieldBase
    {
        public override string ProviderFieldName => "server";
        public async override Task<string> ProviderField()
        {
            if (httpContext != null)
            {
                return httpContext?.Request?.Host.ToString();
            }
            return string.Empty;
        }
    }
}
