using Cheers.NLog.Extensions;
using System;
using System.Linq;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    ///     配合 NLog （Target Network） 注入自定义字段
    ///     自定义字段都继承自 <see cref="LayoutFieldBase"/>
    /// </summary>
    public static class LogstashLayoutBaseServiceCollectionExtensions
    {
        public static void AddLayoutBase(this IServiceCollection services)
        {
            var layouts = AppDomain.CurrentDomain.GetAssemblies().SelectMany(t => t.GetTypes())
                .Where(t => typeof(LayoutFieldBase).IsAssignableFrom(t) && !t.IsAbstract);

            foreach (var item in layouts)
            {
                services.AddSingleton(typeof(LayoutFieldBase), item);
            }
        }
    }
}
