using Cheers.NLog.Extensions.Layouts;
using NLog.LayoutRenderers;
using System;

namespace Cheers.NLog.Extensions.Renderers
{
    [LayoutRenderer("apiinsight-serverip")]
    public class ServerIPApiInsightRenderer : LayoutRendererBase
    {
        public override Type LayoutType => typeof(ServerLayout);
    }
}
