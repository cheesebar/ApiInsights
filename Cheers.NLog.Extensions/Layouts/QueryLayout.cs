using System.Threading.Tasks;

namespace Cheers.NLog.Extensions.Layouts
{
    /// <summary>
    ///     查询字符串
    /// </summary>
    public class QueryLayout : LayoutFieldBase
    {
        public override string ProviderFieldName => "query";
        public async override Task<string> ProviderField()
        {
            if (httpContext != null)
            {
                return httpContext?.Request?.QueryString.ToString();
            }
            return string.Empty;
        }
    }
}
