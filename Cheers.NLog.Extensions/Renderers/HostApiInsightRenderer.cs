using Cheers.NLog.Extensions.Layouts;
using NLog.LayoutRenderers;
using System;

namespace Cheers.NLog.Extensions.Renderers
{
    [LayoutRenderer("apiinsight-host")]
    public class HostApiInsightRenderer : LayoutRendererBase
    {
        public override Type LayoutType => typeof(HostLayout);
    }
}
