using Cheers.AspNetCore;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using NLog.Targets;

namespace Cheers.NLog.Extensions
{
    /// <summary>
    ///     给 <see cref="NetworkTarget"/> 优雅的自定义字段
    /// </summary>
    public abstract class LayoutFieldBase
    {
        public abstract Task<string> ProviderField();
        public abstract string ProviderFieldName { get; }
        public HttpContext httpContext => HttpContextProvider.Current;
    }
}
