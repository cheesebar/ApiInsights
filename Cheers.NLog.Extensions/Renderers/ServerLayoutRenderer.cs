using Cheers.NLog.Extensions.Layouts;
using NLog.LayoutRenderers;
using System;

namespace Cheers.NLog.Extensions.Renderers
{
    [LayoutRenderer("apiinsight-request-servername")]
    public class ServerLayoutRenderer : LayoutRendererBase
    {
        public override Type LayoutType => typeof(ServerLayout);
    }
}
