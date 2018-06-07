using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Cheers.AspNetCore.Auth;
namespace Cheers.NLog.Extensions.Layouts
{
    /// <summary>
    ///     登陆的用户名
    /// </summary>
    public class UserLayout : LayoutFieldBase
    {
        public override string ProviderFieldName => "userName";
        public async override Task<string> ProviderField()
        {
            if (httpContext != null)
            {
                var authorize = httpContext.RequestServices.GetService<IRequestIsAuthenticate>();
                var userName = await authorize.AuthenticatedUserName();
                return userName;
            }
            return string.Empty;
        }
    }
}
