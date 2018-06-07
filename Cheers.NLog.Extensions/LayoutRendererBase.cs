using Cheers.AspNetCore;
using NLog;
using NLog.LayoutRenderers;
using System;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using NLog.Targets;
namespace Cheers.NLog.Extensions
{
    /// <summary>
    ///     已知的是这里通过 <see cref="LayoutFieldBase"/> 给 <see cref="NetworkTarget"/> 优雅的自定义字段
    ///     但是考虑到有些字段可能同事也要输入到 <see cref="DatabaseTarget"/>，但是相同字段的值获取方式是一样的
    ///     Append 方法通过代理接口 <see cref="ILayoutProxy"/> 提供的 <see cref="LayoutFieldBase"/> 取值
    /// </summary>
    public abstract class LayoutRendererBase : LayoutRenderer, ILayoutProxy
    {
        public abstract Type LayoutType { get; }

        private LayoutFieldBase _layout;

        public LayoutFieldBase Layout
        {
            get
            {
                if (_layout == null)
                {
                    if (HttpContextProvider.Current != null)
                    {
                        _layout = HttpContextProvider.Current.RequestServices.GetServices<LayoutFieldBase>().First(t => t.GetType() == LayoutType);
                    }
                }
  
                return _layout;
            }
        }

        protected async override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            builder.Append(await Layout?.ProviderField());
        }
    }
}
