using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Cheers.AspNetCore.Auth;
namespace Cheers.NLog.Extensions.Layouts
{
    /// <summary>
    ///     认证
    /// </summary>
    public class AuthLayout : LayoutFieldBase
    {
        public override string ProviderFieldName => "auth";
        public async override Task<string> ProviderField()
        {
            if (httpContext != null)
            {
                var authorize = httpContext.RequestServices.GetService<IRequestIsAuthenticate>();
                var authenticates = await authorize.IsAuthenticateAsync();
                return authenticates;
            }
            return string.Empty;
        }
    }
}
