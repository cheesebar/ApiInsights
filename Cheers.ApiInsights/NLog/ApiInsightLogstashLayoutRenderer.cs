using Cheers.ApiInsights.NLog.Layouts;
using Cheers.NLog.Extensions;
using Cheers.NLog.Extensions.Internal;
using Cheers.NLog.Extensions.Layouts;
using Microsoft.Extensions.DependencyInjection;
using NLog.LayoutRenderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheers.ApiInsights.NLog
{
    /// <summary>
    ///     在 NLog 配置文件中，Network 我们只需要注册一个 Layout，名称就是 logstash-apiinsight
    /// </summary>
    [LayoutRenderer("logstash-apiinsight")]
    public class ApiInsightLogstashLayoutRenderer : LogstashLayoutRenderer
    {
        static readonly Type[] LayoutTypes = new[] {
            typeof(StartLayout),
            typeof(TimeLayout),
            typeof(ProtocolLayout),
            typeof(HostLayout),
            typeof(PortLayout),
            typeof(PathLayout),
            typeof(QueryLayout),
            typeof(ClientIPLayout),
            typeof(ServerIPLayout),
            typeof(AuthLayout),
            typeof(HttpStatusLayout),
            typeof(AppLayout),
            typeof(MethodLayout),
        };

        static LayoutFieldBase[] Layouts;

        void Init(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<LayoutFieldBase>();

            Layouts = services.Where(t => LayoutTypes.Contains(t.GetType())).ToArray();

            if (Layouts.Length != LayoutTypes.Length)
            {
                throw new Exception(nameof(ApiInsightLogstashLayoutRenderer) + " 的 Layouts 和预定义数目的不匹配");
            }
        }

        protected async override Task<string> ProviderJson()
        {
            if (Layouts == null)
            {
                Init(httpContext.RequestServices);
            }
            var dic = new Dictionary<string, string>();

            foreach (var item in Layouts)
            {
                dic.Add(item.ProviderFieldName, await item.ProviderField());
            }

            var json = JObjectHelper.CreateSimpleJson(dic).Replace(Environment.NewLine, string.Empty);

            return json;
        }
    }
}