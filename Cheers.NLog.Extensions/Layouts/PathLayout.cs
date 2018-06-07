using System.Threading.Tasks;

namespace Cheers.NLog.Extensions.Layouts
{
    /// <summary>
    ///     请求路径
    /// </summary>
    public class PathLayout : LayoutFieldBase
    {
        public override string ProviderFieldName => "path";
        public async override Task<string> ProviderField()
        {
            if (httpContext != null)
            {
                return httpContext?.Request?.Path;
            }
            return string.Empty;
        }
    }
}
