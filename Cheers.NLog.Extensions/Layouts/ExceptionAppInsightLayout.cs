using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;

namespace Cheers.NLog.Extensions.Layouts
{
    /// <summary>
    ///     异常
    /// </summary>
    public class ExceptionLayout : LayoutFieldBase
    {
        public override string ProviderFieldName => "exception";
        public async override Task<string> ProviderField()
        {
            if (httpContext != null)
            {
                var exception = httpContext?.Features?.Get<IExceptionHandlerFeature>()?.Error?.ToString();
                return exception;
            }
            return string.Empty;
        }
    }
}
