using System.Threading.Tasks;

namespace Cheers.NLog.Extensions.Layouts
{
    /// <summary>
    ///     请求地址
    /// </summary>
    public class UrlLayout : LayoutFieldBase
    {
        public override string ProviderFieldName => "url";
        public async override Task<string> ProviderField()
        {
            if (httpContext != null)
            {
                var url = httpContext?.Request?.Host + httpContext?.Request?.Path + httpContext?.Request?.QueryString.ToString();
                return url;
            }
            return string.Empty;
        }
    }
}
