using System;

namespace Cheers.NLog.Extensions
{
    /// <summary>
    ///     在 <see cref="LayoutFieldBase"/> ， <see cref="LayoutRendererBase"/> 之间提供一个代理
    /// </summary>
    public interface ILayoutProxy
    {
        Type LayoutType { get; }
        LayoutFieldBase Layout { get; }
    }
}
