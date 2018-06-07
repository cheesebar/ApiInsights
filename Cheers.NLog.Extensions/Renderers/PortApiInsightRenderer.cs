using Cheers.NLog.Extensions.Layouts;
using NLog.LayoutRenderers;
using System;

namespace Cheers.NLog.Extensions.Renderers
{
    [LayoutRenderer("apiinsight-port")]
    public class PortApiInsightRenderer : LayoutRendererBase
    {
        public override Type LayoutType => typeof(PortLayout);
    }
}
