using System.Threading.Tasks;

namespace Cheers.NLog.Extensions.Layouts
{
    /// <summary>
    ///     状态码
    /// </summary>
    public class HttpStatusLayout : LayoutFieldBase
    {
        public override string ProviderFieldName => "statusCode";
        public async override Task<string> ProviderField()
        {
            if (httpContext != null)
            {
                return httpContext.Response.StatusCode.ToString();
            }
            return string.Empty;
        }
    }
}
