using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Security.Claims;
using Cheers.AspNetCore;
using Microsoft.AspNetCore.Authentication;

namespace Cheers.AspNetCore.Auth
{
    /// <summary>
    ///     验证请求用户是否已经认证
    /// </summary>
    public interface IRequestIsAuthenticate
    {
        /// <summary>
        ///     返回已经认证的 scheme
        /// </summary>
        /// <returns></returns>
        Task<string> IsAuthenticateAsync();
        /// <summary>
        ///     返回已经认证的 用户名
        /// </summary>
        /// <returns></returns>
        Task<string> AuthenticatedUserName();
    }
    /// <summary>
    ///     在 <see cref="AuthenticationMiddleware"/> 进行权限控制下的一个 <see cref="IRequestIsAuthenticate"/> 实现
    /// </summary>
    public class DefaultRequestIsAuthenticate : IRequestIsAuthenticate
    {
        private readonly List<AuthenticationScheme> _authenticationSchemes;
        public DefaultRequestIsAuthenticate(IAuthenticationSchemeProvider authenticationService)
        {
            _authenticationSchemes = authenticationService.GetAllSchemesAsync().GetAwaiter().GetResult().ToList();
        }

        public async Task<string> AuthenticatedUserName()
        {
            var httpContext = HttpContextProvider.Current;

            var authenticates = new List<string>();

            if (httpContext != null)
            {
                foreach (var scheme in _authenticationSchemes)
                {
                    var result = await httpContext.AuthenticateAsync(scheme.Name);

                    if (result.Succeeded)
                    {
                        var userName = result.Principal?.Claims?.FirstOrDefault(t => t.Type == ClaimTypes.Name)?.Value;
                        if (!string.IsNullOrEmpty(userName))
                        {
                            authenticates.Add(userName);
                        }
                    }
                }
            }

            return string.Join(",", authenticates);
        }

        public async Task<string> IsAuthenticateAsync()
        {
            var httpContext = HttpContextProvider.Current;

            var authenticates = new List<string>();

            if (httpContext != null)
            {
                foreach (var scheme in _authenticationSchemes)
                {
                    var result = await httpContext.AuthenticateAsync(scheme.Name);

                    if (result.Succeeded)
                    {
                        authenticates.Add(scheme.Name);
                    }
                }
            }

            return string.Join(",", authenticates);
        }
    }
}
