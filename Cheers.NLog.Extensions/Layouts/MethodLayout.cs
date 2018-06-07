using System.Threading.Tasks;

namespace Cheers.NLog.Extensions.Layouts
{
    /// <summary>
    ///     请求方法
    /// </summary>
    public class MethodLayout : LayoutFieldBase
    {
        public override string ProviderFieldName => "method";
        public async override Task<string> ProviderField()
        {
            if (httpContext != null)
            {
                return httpContext.Request?.Method;
            }
            return string.Empty;
        }
    }
}
