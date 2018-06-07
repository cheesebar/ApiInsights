using Cheers.NLog.Extensions.Layouts;
using NLog.LayoutRenderers;
using System;

namespace Cheers.NLog.Extensions.Renderers
{
    [LayoutRenderer("apiinsight-request-url")]
    public class UrlLayoutRenderer : LayoutRendererBase
    {
        public override Type LayoutType => typeof(ServerLayout);
    }
}
