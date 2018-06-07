using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Cheers.NLog.Extensions.Layouts
{
    /// <summary>
    ///     应用程序名称
    /// </summary>
    public class AppLayout : LayoutFieldBase
    {
        public override string ProviderFieldName => "app";
        public async override Task<string> ProviderField()
        {
            if (httpContext != null)
            {
                var env = httpContext.RequestServices?.GetService<IHostingEnvironment>();
                return env.ApplicationName;
            }
            return string.Empty;
        }
    }
}
